
print("Start")
import datetime
import os, threading
from UploadToS3 import uploadImg
from ImgRecognition import CallRecognitionApi
from TextToSpeech import ConvertToSpeech


#imgDetails = uploadImg("081239.jpg")#"PramodAleti.jpg")
#fileName = datetime.datetime.now().strftime("%Y%m%d%H%M%S")+".jpg"

def ProcessImage(caseId):
    fileName = datetime.datetime.now().strftime("%Y%m%d%H%M%S")+".jpg"
    mycmd = 'fswebcam -d /dev/video0  -S 2 -s brightness=60% -s Contrast=15%  --no-banner -s Gamma=50%  -p YUYV -r 1280x720 --jpeg 80 -s Sharpness=40% -s Saturation=15%  ' + fileName
    os.system(mycmd)
    imgDetails = uploadImg(fileName, caseId)
    text = CallRecognitionApi(imgDetails)
    print(text)
    ConvertToSpeech(text)
    #threading.Timer(10, ProcessImage).start()
    #os.remove(fileName)