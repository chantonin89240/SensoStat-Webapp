<template>
    <div>
        <p>C'est &agrave; vous !</p>

        <div class="form-floating">
            <textarea class="form-control" placeholder="Leave a comment here" id="floatingTextarea" v-model="response" required></textarea>
            <label for="floatingTextarea">Comments</label>
        </div>

        <i class="fa-solid fa-microphone"></i>

        <a class="btn btn-warning" @click="questionValide">Etape suivante</a>
    </div>
</template>

<script>
    import SpeechService from '../services/SpeechService.js';
    import * as sdk from "microsoft-cognitiveservices-speech-sdk";

export default {
    
    props:{
        
    },
    name: 'QuestionReponseComponent',
    data() {
        return {
            response: null,
            SpeechService: undefined,
        };
    },
    mounted() {
        this.SpeechService = new SpeechService();
        this.recognizeSpeech();
        console.log(this.response);
    },
    methods:{
        questionValide() {
            this.$emit('questionValide', this.response)
        },
        recognizeSpeech() {
            
            const speechConfig = sdk.SpeechConfig.fromSubscription("b2e32041353748908c8e5805be94fff0", "westeurope");
            speechConfig.speechRecognitionLanguage = "fr-FR";
            const audioConfig = sdk.AudioConfig.fromDefaultMicrophoneInput();

            const recognizer = new sdk.SpeechRecognizer(speechConfig, audioConfig);

            recognizer.recognizeOnceAsync(result => {
                this.response = result.text
            });
        }
    }

}
</script>