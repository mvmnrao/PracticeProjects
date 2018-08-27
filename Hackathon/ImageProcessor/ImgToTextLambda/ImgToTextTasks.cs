using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Amazon;
using Amazon.Lambda.Core;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.S3;
using Amazon.S3.Model;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace ImgToTextLambda
{

    public class ImgToTextTasks
    {
        private static Dictionary<string, string> persons = new Dictionary<string, string>() {
            { "Ram", "He is chief software engineer at Epam" },
            { "Manik", "He is Lead engineer currently assigned to Ericsson project" },
            { "Pramod", "He is senior software engineer at epam systems" },
            { "Sandeep", "He is technology director at Epam Systems" },
            { "Murali", "He is solution architect at Epam Systems" },
            {"Saty", "He is a senior project manager at Epam Systems" },
            {"Lakshman", "He is solution architect at Epam Systems" },
            {"Krishna", "He is director of technology at Epam Systems" },
            {"Piyush", "He is project manager at Epam Systems" },
            {"Satish", "He is director at Epam Systems" },
            {"SandeepJoshi", "He is senior director at Epam Systems" },
            {"SrinivasaReddy", "He is managing director at Epam Systems" },
            {"Shanthi", "He is  director at Epam Systems" },
            {"Basha", "He is director delivery manager at Epam systems" }
        };

        RegionEndpoint regionEndpoint = RegionEndpoint.USEast1;

        public bool isDetectFace = false;
        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public ImgToTextTasks()
        {
        }

        public string TransformToText(State state, ILambdaContext context)
        {
            if(!string.IsNullOrEmpty(state.BucketName) && !string.IsNullOrEmpty(state.Key))
            {
                context.Logger.LogLine($"Test: Received request. Bucket Name: {state.BucketName}, Key: {state.Key}");
            }

            string finalMessage = string.Empty;
            List<string> responseText = new List<string>();

            try
            {
                GetObjectRequest imgRequest = new GetObjectRequest();
                imgRequest.BucketName = state.BucketName;
                imgRequest.Key = state.Key;

                using (IAmazonS3 s3Client = new AmazonS3Client())
                {
                    GetObjectResponse imgresponse = s3Client.GetObjectAsync(imgRequest).Result;

                    using (AmazonRekognitionClient rekognitionClient = new AmazonRekognitionClient(regionEndpoint))
                    {
                        using (Stream inputStream = imgresponse.ResponseStream as Stream)
                        {
                            MemoryStream memoryStream = inputStream as MemoryStream;
                            if (memoryStream == null)
                            {
                                memoryStream = new MemoryStream();
                                inputStream.CopyTo(memoryStream);
                            }

                            if (state.CaseId == 1)
                            {
                                finalMessage = this.DetectObjects(memoryStream, rekognitionClient, context).Result;
                            }
                            else if (state.CaseId == 2)
                            {
                                finalMessage = this.DetectFaces(memoryStream, rekognitionClient, context).Result;
                            }
                            else if (state.CaseId == 3)
                            {
                                finalMessage = this.DetectText(memoryStream, rekognitionClient, context).Result;
                            }
                            else
                            {
                                finalMessage = "Sorry, Nothing was Detected";
                            }
                        }
                    }
                    //s3Client.DeleteAsync(state.BucketName, state.Key, new Dictionary<string, object>());
                    context.Logger.LogLine($"Deleted: {state.Key}");
                }               
                context.Logger.LogLine(finalMessage);
            }
            catch (Exception ex)
            {
                context.Logger.LogLine(ex.Message);
                finalMessage = "Sorry, Nothing was Detected";
            }

            return finalMessage;
        }

        private async Task<string> DetectObjects(MemoryStream memoryStream, AmazonRekognitionClient client, ILambdaContext context)
        {
            List<string> responseText = new List<string>();
            string detectedResponse = "";
            isDetectFace = false;
            try
            {
                var detectResponses = await client.DetectLabelsAsync(new DetectLabelsRequest
                {
                    MinConfidence = 80,
                    Image = new Image
                    {
                        Bytes = memoryStream
                    },
                    MaxLabels = 10
                });
                if (detectResponses != null && detectResponses.HttpStatusCode == HttpStatusCode.OK && detectResponses.Labels.Count > 0)
                {
                    foreach (var item in detectResponses.Labels)
                    {
                        if (item.Name.Contains("Human") || item.Name.Contains("People") || item.Name.Contains("Person"))
                        {
                            isDetectFace = true;
                        }
                        else
                        {
                            responseText.Add(item.Name);
                        }
                    }
                    if (responseText.Count > 0)
                    {
                        detectedResponse = "you are seeing " + string.Join(", ", responseText.ToArray());
                        if (isDetectFace)
                        {
                            detectedResponse = detectedResponse + "  you also have people around you.";
                        }
                    }
                    else if (responseText.Count == 0 && isDetectFace)
                    {
                        detectedResponse = "  you have people around you.";
                    }
                    else
                    {
                        detectedResponse = "No objects Detected";
                    }
                }
                else
                {
                    detectedResponse = "No objects Detected";
                }
            }
            catch (Exception ex)
            {
                context.Logger.LogLine(ex.Message);
                detectedResponse = "No objects Detected";
            }
            return detectedResponse;
        }

        private async Task<string> DetectFaces(MemoryStream memoryStream, AmazonRekognitionClient client, ILambdaContext context)
        {
            string message = "";
            try
            {
                SearchFacesByImageResponse detectResponses = await client.SearchFacesByImageAsync(new SearchFacesByImageRequest
                {
                    Image = new Image
                    {
                        Bytes = memoryStream
                    },
                    CollectionId = "TrainedImages",
                    FaceMatchThreshold = 80,
                    MaxFaces = 1
                });

                if (detectResponses != null && detectResponses.HttpStatusCode == HttpStatusCode.OK && detectResponses.FaceMatches.Count > 0)
                {
                    var name = detectResponses.FaceMatches[0].Face.ExternalImageId;
                    message = "Hey, You have " + name + " with you. ";
                    string desc;
                    if (persons.TryGetValue(name, out desc))
                        {
                        message += desc;

                    }
                }
                else
                {
                    message = "You have a person with you but I couldn't recognize him.";
                }
            }
            catch (Exception ex)
            {
                context.Logger.LogLine(ex.Message);
                message = "Sorry, no persons detected. ";
            }
            return message;
        }

        private async Task<string> DetectText(MemoryStream memoryStream, AmazonRekognitionClient client, ILambdaContext context)
        {
            string message = "";
            List<string> lines = new List<string>();
            try
            {
                DetectTextResponse detecttextResponses = await client.DetectTextAsync(new DetectTextRequest
                {
                    Image = new Image
                    {
                        Bytes = memoryStream
                    }
                });

                if (detecttextResponses != null && detecttextResponses.HttpStatusCode == HttpStatusCode.OK && detecttextResponses.TextDetections.Count > 0)
                {
                    foreach (var item in detecttextResponses.TextDetections)
                    {
                        if (item.Type == TextTypes.LINE)
                        {
                            lines.Add(item.DetectedText);
                        }
                    }
                    message = "There is a text written as " + string.Join(", ", lines.ToArray());
                }
                else
                {
                    message = "Sorry, no text was detected. ";
                }
            }
            catch (Exception ex)
            {
                context.Logger.LogLine(ex.Message);
                message = "Sorry, no text was detected. ";
            }
            return message;
        }

        public State Salutations(State state, ILambdaContext context)
        {
            //state.Message += ", Goodbye";

            if (!string.IsNullOrEmpty(state.BucketName))
            {
                //state.Message += " " + state.BucketName;
            }

            return state;
        }


    }
}
