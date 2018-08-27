
import boto3
import datetime
import json

s3Bucket = 'team-virtual-crew'
tempFileName = '.jpg'

def uploadImg(filePath, caseId):
    print("Uploading image to S3" + datetime.datetime.now().strftime("-%M%S"))
    s3 = boto3.client('s3')
    dynamicKey = datetime.datetime.now().strftime("%Y%m%d%H%M%S")
    dynamicFileName = '%s%s' % (dynamicKey, tempFileName)
    s3.upload_file(filePath, s3Bucket, dynamicFileName)#, ExtraArgs={'ACL': "public-read"})
    print("Uploaded image to S3" + datetime.datetime.now().strftime("-%M%S"))
    s3Details = {'BucketName': s3Bucket, 'Key': dynamicFileName, 'CaseId' : caseId}
    return json.dumps(s3Details)
