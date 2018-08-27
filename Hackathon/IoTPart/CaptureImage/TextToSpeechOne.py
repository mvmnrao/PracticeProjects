
import pyttsx3

engine = pyttsx3.init()
txt = "Hi how are you doing today manik, how is hackathon going?"
voices = engine.getProperty('voices')
#for voice in voices:
#print(repr(voice))
engine.setProperty('rate',120)  #120 words per minute
engine.setProperty('volume',0.9)
engine.setProperty('voice', voices[1].id)
engine.say(txt)
pyttsx3.voice.Voice.gender = 'female'
#pyttsx3.engine.Engine.setPropertyValue()
engine.runAndWait()

#import pyttsx
#engine = pyttsx.init()
#engine.setProperty('rate', 70)

#voices = engine.getProperty('voices')
#for voice in voices:
#    print ("Using voice:" + repr(voice))
#    engine.setProperty('voice', voice.id)
#    engine.say("Hi there, how's you ?")
#    engine.say("A B C D E F G H I J K L M")
#    engine.say("N O P Q R S T U V W X Y Z")
#    engine.say("0 1 2 3 4 5 6 7 8 9")
#    engine.say("Sunday Monday Tuesday Wednesday Thursday Friday Saturday")
#    engine.say("Violet Indigo Blue Green Yellow Orange Red")
#    engine.say("Apple Banana Cherry Date Guava")
#engine.runAndWait()