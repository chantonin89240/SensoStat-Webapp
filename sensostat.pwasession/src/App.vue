<template>
    <div id="app">
        <!-- Navbar -->
        <NavbarComponent />

        <!-- section ou sera rassembler les components et trier -->
        <section class="container">
            <AutorisationComponent v-if="autoResponse" @autorisation="autorisation"></AutorisationComponent>
            <MsgAccueilComponent v-if="msgAccueilTrue" v-bind:currentText="currentText" @nextInstruction="verifMsgAccueil"></MsgAccueilComponent>
            <InstructionComponent v-if="isQuestion == 0 && msgAccueilTrue == false && msgFinalTrue == false && autoResponse == false" v-bind:currentInstruction="currentInstruction" @nextInstruction="verifInstruction"></InstructionComponent>
            <!-- <button  @click="call(1350)">Test</button> -->
            <QuestionComponent v-if="isQuestion == 1 && msgAccueilTrue == false && msgFinalTrue == false && autoResponse == false" v-bind:currentInstruction="currentInstruction" @repeteSpeech="repeteSpeech" @nextInstruction="verifInstruction"></QuestionComponent>
            <MsgFinal v-if="msgFinalTrue" v-bind:msgFinal="msgFinal"></MsgFinal>
        </section>

        <!-- Footer -->
        <FooterComponent />
    </div>
</template>

<script>
    import NavbarComponent from './components/Navbar.vue';
    import FooterComponent from './components/Footer.vue';
    import AutorisationComponent from './components/Autorisation.vue';
    import MsgAccueilComponent from './components/MsgAccueil.vue';
    import MsgFinalComponent from './components/MsgFinal.vue';
    import InstructionComponent from './components/Instruction.vue';
    import QuestionComponent from './components/Question.vue';
    import PresentationService from './services/PresentationService.js';
    import SpeechService from './services/SpeechService.js';

export default {
    name: 'App',
    components: {
        NavbarComponent,
        FooterComponent,
        AutorisationComponent,
        MsgAccueilComponent,
        MsgFinalComponent,
        InstructionComponent,
        QuestionComponent,
        },
    data() {
        return {
            session: null,
            autori: null,
            autoResponse: true,
            currentInstruction: null,
            isQuestion: null,
            currentText: null,
            instructions: null,
            nbChronology: null,
            instructionCodeProduit: null,
            currentPresentation : null,
            presentations : null,
            nbPresentation : null,
            presentationService: undefined,
            SpeechService: new SpeechService(),
            msgAccueilTrue: false,
            msgFinalTrue: false,
        };
    },
    mounted(){
       
    },
    watch: {
        currentText() {
            console.log(this.currentText);
            this.SpeechService.synthesizeSpeech(this.currentText);
        }
     },
    methods: {
        autorisation(text) {
            this.autoResponse = false;
            this.msgAccueilTrue = true;
            this.autori = text;
            this.callInstru();
        },
        verifMsgAccueil() {
            this.msgAccueilTrue = false;
            this.isQuestion = this.currentInstruction.isQuestion;
            this.currentText = this.currentInstruction.libelle;
        },
        verifInstruction() {
            if (this.currentInstruction.chronology == this.nbChronology) {
                if (this.currentPresentation.rank == this.nbPresentation) {
                    this.msgFinalTrue = true;
                }
                else{
                    this.instructionCodeProduit = JSON.parse(JSON.stringify(this.instructions));
                    this.currentPresentation = this.presentations[this.currentPresentation.rank];
                    this.instructionCodeProduit.forEach(instruction => {
                        instruction.libelle = instruction.libelle.replace('#codeProduit', this.currentPresentation.codeProduit);
                    });
                    this.currentInstruction = this.instructionCodeProduit[0];
                    this.currentText = this.currentInstruction.libelle;
                    this.isQuestion = this.currentInstruction.isQuestion;
                }     
            }
            else{
                this.currentInstruction = this.instructionCodeProduit[this.currentInstruction.chronology];
                this.currentText = this.currentInstruction.libelle;
                this.isQuestion = this.currentInstruction.isQuestion;
            }
        },
        repeteSpeech() {
            //this.SpeechService.pause();
            this.SpeechService.synthesizeSpeech(this.currentText);
        },
        callInstru() {
            this.presentationService = new PresentationService()
            this.presentationService.get().then((session) => {
                this.session = session;
                this.instructions = this.session.instructions;
                this.nbChronology = this.instructions.length;
                this.instructionCodeProduit = JSON.parse(JSON.stringify(this.instructions));
                this.currentInstruction = this.instructionCodeProduit[0];
                this.currentText =  this.session.msgAccueil;
                
            }).then(() => {
                this.presentationService.getPresentation(101, 101).then((presentation) => {
                    this.presentations = presentation;
                    this.nbPresentation = this.presentations.length;
                    this.currentPresentation = this.presentations[0];
                    this.instructionCodeProduit.forEach(instruction => {
                        instruction.libelle = instruction.libelle.replace('#codeProduit', this.currentPresentation.codeProduit);
                    });
                })
            });
        }
    },
}

</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
