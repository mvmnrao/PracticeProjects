using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using ImageTrainApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ImageTrainApp.Controllers
{
    public class ImageTrainController : Controller
    {
        AmazonRekognitionClient client = new AmazonRekognitionClient(Amazon.RegionEndpoint.USEast1);
        // GET: ImageTrain
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(ImageTrainModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                using (Stream inputStream = model.File.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }

                    var collectionsList = client.ListCollections(new ListCollectionsRequest { MaxResults = 10 });
                    //client.CreateCollection(new CreateCollectionRequest
                    //{
                    //    CollectionId = "TrainedImages"
                    //});

                    IndexFacesRequest indexFacesRequest = new IndexFacesRequest()
                    {
                        Image = new Image
                        {
                            Bytes = memoryStream
                        },
                        CollectionId = "TrainedImages",
                        ExternalImageId = model.Name,
                        DetectionAttributes = new List<String>() { "ALL" }
                    };

                    IndexFacesResponse indexFacesResponse = client.IndexFaces(indexFacesRequest);
                    if (indexFacesResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.Message = "Image trained successfully";
                    }

                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
            }
            return View();
        }


        public ActionResult FindMatch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindMatch(ImageRecongnitionModel model)
        {
            string finalMessage = string.Empty;
            bool recognizeFace = false;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {               
                using (Stream inputStream = model.File.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }

                    string objectsDetected = this.DetectObjects(memoryStream, out recognizeFace);

                    if(recognizeFace)
                    {
                        finalMessage = finalMessage + DetectFaces(memoryStream);
                    }
                    ViewBag.Message = finalMessage + objectsDetected + this.DetectText(memoryStream);
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }

        private string DetectObjects(MemoryStream memoryStream, out bool isDetectFace)
        {
            List<string> responseText = new List<string>();
            string detectedResponse = "";
            isDetectFace = false;
            try
            {
                var detectResponses = client.DetectLabels(new DetectLabelsRequest
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
                       detectedResponse =  "And you also seeing " + string.Join(", ", responseText.ToArray());
                    }
                }
                else
                {
                    detectedResponse = "No objects Detected";
                }
            }
            catch
            {
                detectedResponse = "No objects Detected";
            }       
            return detectedResponse;
        }

        private string DetectFaces(MemoryStream memoryStream)
        {
            string message = "";
            try
            {
                SearchFacesByImageResponse detectResponses = client.SearchFacesByImage(new SearchFacesByImageRequest
                {
                    Image = new Image
                    {
                        Bytes = memoryStream
                    },
                    CollectionId = "TrainedImages",
                    FaceMatchThreshold = 85,
                    MaxFaces = 1
                });
                DetectTextResponse detecttextResponses = client.DetectText(new DetectTextRequest
                {
                    Image = new Image
                    {
                        Bytes = memoryStream
                    }
                });

                if (detectResponses != null && detectResponses.HttpStatusCode == HttpStatusCode.OK && detectResponses.FaceMatches.Count > 0)
                {
                    message = "Hey, You have " + detectResponses.FaceMatches[0].Face.ExternalImageId + " with you. ";
                }
                else
                {
                    message = "You found a person but No matching faces available.";
                }
            }
            catch
            {

            }        
            return message;
        }

        private string DetectText(MemoryStream memoryStream)
        {
            string message = "";
            try
            {
                DetectTextResponse detecttextResponses = client.DetectText(new DetectTextRequest
                {
                    Image = new Image
                    {
                        Bytes = memoryStream
                    }
                });

                if (detecttextResponses != null && detecttextResponses.HttpStatusCode == HttpStatusCode.OK && detecttextResponses.TextDetections.Count > 0)
                {
                    message = " There was a text written as " + detecttextResponses.TextDetections[0].DetectedText + " here. ";
                }
            }
            catch
            {

            }
            return message;
        }

    }
}