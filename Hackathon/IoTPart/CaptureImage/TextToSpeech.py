import boto3
import pygame
import os
import datetime
import time

#from pygame import mixer
from contextlib import closing

def ConvertToSpeech(text):  
    client = boto3.client('polly')
    print('Calling polly' + datetime.datetime.now().strftime("-%M%S"))
    response = client.synthesize_speech(
        OutputFormat='mp3',
        Text=text,
        TextType='text',
        VoiceId='Salli'
    )
    print('Got polly response' + datetime.datetime.now().strftime("-%M%S"))

    dynamicStr = datetime.datetime.now().strftime("%Y%m%d%H%M%S")
    if "AudioStream" in response:
        with closing(response["AudioStream"]) as stream:
            output = dynamicStr + ".mp3"
    
            try:
                # Open a file for writing the output as a binary stream
                with open(output, "wb", buffering=-1, encoding=None, errors=None, newline=None, closefd=True) as file:
                    file.write(stream.read())
                    playSound(output)
                        
                    print('Played and deleted audio' + datetime.datetime.now().strftime("-%M%S"))
                    #return True

            except IOError as error:
                # Could not write to file, exit gracefully
                print(error)
                sys.exit(-1)

def playSound(fileName):
    pygame.mixer.init()
    pygame.mixer.music.load(fileName)
    pygame.mixer.music.play()
    if(fileName != "beep.mp3"): 
        DeleteFile(fileName)

def DeleteFile(fileName):  
    os.remove(fileName)
