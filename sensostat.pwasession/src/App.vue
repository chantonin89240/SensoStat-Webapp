<template>
    <div id="app">
        <!-- Navbar -->
        <NavbarComponent/>

        <!-- section ou sera rassembler les components et trier -->
        <section class="container">
            <InstructionComponent v-if="currentInstruction.isQuestion == 0" v-bind:currentInstruction="currentInstruction" @nextInstruction="verifInstruction"></InstructionComponent>
            <!-- <button  @click="call(1350)">Test</button> -->
            <QuestionComponent v-if="currentInstruction.isQuestion == 1" v-bind:currentInstruction="currentInstruction" @nextInstruction="verifInstruction"></QuestionComponent>
        </section>

        <!-- Footer -->
        <FooterComponent/>
    </div>
</template>

<script>
    import NavbarComponent from './components/Navbar.vue';
    import FooterComponent from './components/Footer.vue';
    import InstructionComponent from './components/Instruction.vue';
    import QuestionComponent from './components/Question.vue';
    import PresentationService from './services/PresentationService.js';

export default {
    name: 'App',
    components: {
        NavbarComponent,
        FooterComponent,
        InstructionComponent,
        QuestionComponent,
        },
    data() {
        return {
            session: null,
            currentInstruction : null,
            instructions : null,
            nbChronology: null,
            instructionCodeProduit: null,
            currentPresentation : null,
            presentations : null,
            nbPresentation : null,
            presentationService : undefined,
        };
    },
    mounted(){
        //verifier si des réponses ont déjà été donnée pour faire reprendre là où c'était arreté le paneliste
        this.presentationService = new PresentationService()
        this.presentationService.get().then((session) => {
            this.session = session;
            this.instructions = this.session.instructions;
            this.nbChronology = this.instructions.length;
            this.instructionCodeProduit = JSON.parse(JSON.stringify(this.instructions));
            this.currentInstruction = this.instructionCodeProduit[0];
        }).then(() => {
            this.presentationService.getPresentation(1,1).then((presentation) => {
                this.presentations = presentation;
                this.nbPresentation = this.presentations.length;
                this.currentPresentation = this.presentations[0];
                this.instructionCodeProduit.forEach(instruction => {
                    instruction.libelle = instruction.libelle.replace('#codeProduit', this.currentPresentation.codeProduit);
                });
            })
        });
    },
    methods: {
        verifInstruction() {
            if (this.currentInstruction.chronology == this.nbChronology-2) {
                if (this.currentPresentation.rank == this.nbPresentation) {
                    this.currentInstruction = this.instructionCodeProduit[this.currentInstruction.chronology+1];
                }
                else{
                    this.instructionCodeProduit = JSON.parse(JSON.stringify(this.instructions));
                    this.currentPresentation = this.presentations[this.currentPresentation.rank];
                    this.instructionCodeProduit.forEach(instruction => {
                        instruction.libelle = instruction.libelle.replace('#codeProduit', this.currentPresentation.codeProduit);
                    });
                    this.currentInstruction = this.instructionCodeProduit[1];
                }     
            }
            else{
                this.currentInstruction = this.instructionCodeProduit[this.currentInstruction.chronology+1];
            }
        },
        call(number) {
            for (let index = 0; index < number; index++) {
                fetch("https://sensostatapi.azurewebsites.net/api/sessions/1")                
            }
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
