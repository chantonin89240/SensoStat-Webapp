<template>
    <div id="app">
        <!-- Navbar -->
        <NavbarComponent></NavbarComponent>

        

        <!-- section ou sera rassembler les components et trier -->
        <section class="container">
            <InstructionComponent v-if="isQuestion == 0" v-bind:currentInstruction="currentInstruction"></InstructionComponent>

            <QuestionComponent v-if="isQuestion == 1" v-bind:currentInstruction="currentInstruction"></QuestionComponent>
        </section>

        <!-- Footer -->
        <FooterComponent></FooterComponent>
    </div>
</template>

<script>
    import NavbarComponent from './components/Navbar.vue';
    import FooterComponent from './components/Footer.vue';
    import InstructionComponent from './components/Instruction.vue';
    import QuestionComponent from './components/Question.vue';

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
            nbChronology: null,
            isQuestion: 0,
            instructions : null,
            currentInstruction : null
        };
    },
    created() {
        // fetch the data when the view is created and the data is
        // already being observed
        this.fetchData();
    },
    beforeMount() {
        this.nbChronology = this.instructions.length;
    },
    methods: {
        fetchData() {
            fetch('https://localhost:5001/api/sessions/3')
                .then(r => r.json())
                .then(json => {
                    this.session = json;
                    this.instructions = json.instructions;
                    return;
                });
        },
        verifInstruction() {

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
