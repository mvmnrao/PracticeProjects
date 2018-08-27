
import requests, datetime

apiUrl = "https://qpvd06mldh.execute-api.us-east-1.amazonaws.com/dev/transformtotext"
apiUrl1 = "https://pdtv6z9w3g.execute-api.us-east-1.amazonaws.com/dev/transformtotext"

def CallRecognitionApi(imageDetails):
    print('Calling Recog' + datetime.datetime.now().strftime("-%M%S"))
    r = requests.post(apiUrl, 
                      data=imageDetails)
    #print(r.status_code, r.reason)
    #print(r.text)
    print('Calling Recog Done' + datetime.datetime.now().strftime("-%M%S"))
    return r.text
