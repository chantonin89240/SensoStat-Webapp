import * as sdk from "microsoft-cognitiveservices-speech-sdk";
const speechConfig = sdk.SpeechConfig.fromSubscription("b2e32041353748908c8e5805be94fff0", "westeurope");

export default class SpeechService {
    
    synthesizeSpeech(textSpeech) {
        speechConfig.speechSynthesisLanguage = "fr-CA";
        speechConfig.speechSynthesisVoiceName = "fr-CA-JeanNeural";
        const audioConfig = sdk.AudioConfig.fromDefaultSpeakerOutput();

        const synthesizer = new sdk.SpeechSynthesizer(speechConfig, audioConfig);
        synthesizer.speakTextAsync(
            textSpeech,
            result => {
                if (result) {
                    synthesizer.close();
                    return result.audioData;
                }
            },
            error => {
                console.log(error);
                synthesizer.close();
            });
    }

    recognizeSpeech() {
        speechConfig.speechRecognitionLanguage = "fr-FR";
        const audioConfig = sdk.AudioConfig.fromDefaultMicrophoneInput();

        const recognizer = new sdk.SpeechRecognizer(speechConfig, audioConfig);
        
        recognizer.recognizeOnceAsync(result => {
            return 1;
        })
    }


}




//// appel de l'api web speech
//var synth = window.speechSynthesis;

//// variable de ouf
//var voices = [];
//var theVoice;
//var i = 0;

//// class
//export default class SpeechService {
//    // fonction qui va r�cup�rer la voix de lecture 
//    populateVoiceList() {
//        voices = synth.getVoices().sort(function (a, b) {
//            const aname = a.name.toUpperCase(), bname = b.name.toUpperCase();
//            if (aname < bname) return -1;
//            else if (aname == bname) return 0;
//            else return +1;
//        });

//        for (i = 0; i < voices.length; i++) {

//            if (voices[i].default) {
//                theVoice = voices[i];
//            }

//            // pour firefox
//            if (theVoice == null) {
//                if (voices[i].name == "Microsoft Hortense Desktop - French") {
//                    theVoice = voices[i];
//                }
//            }
//        }
//        return theVoice;
//    }

//    // text to speech 
//    speak(textSpeech) {
//        if (synth.speaking) {
//            console.error('speechSynthesis.speaking');
//            return;
//        }
//        if (textSpeech !== '') {
//            var utterThis = new SpeechSynthesisUtterance(textSpeech);
//            utterThis.onend = function (event) {
//                console.log('SpeechSynthesisUtterance.onend');
//                console.log(event);
//            }
//            utterThis.onerror = function (event) {
//                console.error('SpeechSynthesisUtterance.onerror');
//                console.log(event);
//            }
            
//            var voiceSpeech = this.populateVoiceList();

//            utterThis.voice = voiceSpeech;
//            synth.speak(utterThis);
//        }
//    }
//}




