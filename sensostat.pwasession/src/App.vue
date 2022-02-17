<template>
    <div id="app">
        <!-- Navbar -->
        <NavbarComponent/>
        <!-- section ou sera rassembler les components et trier -->
        <section class="container">
            <!-- <InstructionComponent v-if="currentInstruction.isQuestion == 0" v-bind:currentInstruction="currentInstruction" @nextInstruction="verifInstruction"></InstructionComponent> -->
            <button  @click="call(1350)">Test</button>
            <!-- <QuestionComponent v-if="currentInstruction.isQuestion == 1" v-bind:currentInstruction="currentInstruction" @nextInstruction="verifInstruction"></QuestionComponent> -->
        </section>
        <!-- Footer -->
        <FooterComponent/>
    </div>
</template>
<script>
    import NavbarComponent from './components/Navbar.vue';
    import FooterComponent from './components/Footer.vue';
    // import InstructionComponent from './components/Instruction.vue';
    // import QuestionComponent from './components/Question.vue';
    import PresentationService from './services/PresentationService.js';
export default {
    name: 'App',
    components: {
        NavbarComponent,
        FooterComponent,
        // InstructionComponent,
        // QuestionComponent,
        },
    data() {
        return {
            session: null,
            nbChronology: null,
            instructions : null,
            currentInstruction : null,
            produits : null,
            currentProduit : null,
            presentation : null,
            presentationService : undefined,
        };
    },
    mounted(){
        this.presentationService = new PresentationService()
        this.presentationService.get().then((session) => {
            this.session = session;
            this.instructions = this.session.instructions;
            this.currentInstruction = this.instructions[0];
            this.nbChronology = this.instructions.length;
        })
        this.presentationService.getPresentation(1,1).then((presentation) => {
            this.presentation = presentation;
        })
    },
    methods: {
        verifInstruction(curInstruction) {
            if (curInstruction.chronology == this.nbChronology-2) {
                this.currentInstruction = this.instructions[curInstruction.chronology+1];
            }
            this.currentInstruction = this.instructions[curInstruction.chronology+1];
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