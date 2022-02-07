<template>
    <div id="app">
        <!-- Navbar -->
        <NavbarComponent></NavbarComponent>

        <!-- section ou sera rassembler les components et trier -->
        <section class="container">
            <HomePageComponent v-bind:post="post"></HomePageComponent>
        </section>
        
        <!-- Footer -->
        <FooterComponent></FooterComponent>
    </div>
</template>

<script>
    import NavbarComponent from './components/Navbar.vue';
    import FooterComponent from './components/Footer';
    import HomePageComponent from './components/HomePage.vue';
    import EndPageComponent from './components/EndPage.vue';
    import InstructionPageComponent from './components/InstructionPage.vue';
    import QuestionPageComponent from './components/QuestionPage.vue';

export default {
    name: 'App',
    components: {
        NavbarComponent,
        FooterComponent,
        HomePageComponent,
        EndPageComponent,
        InstructionPageComponent,
        QuestionPageComponent
        },
    data() {
        return {
            loading: false,
            post: null
        };
    },
    created() {
        // fetch the data when the view is created and the data is
        // already being observed
        this.fetchData();
    },
    watch: {
        // call again the method if the route changes
        '$route': 'fetchData'
    },
    methods: {
        fetchData() {
            this.post = null;
            this.loading = true;

            fetch('https://localhost:5001/api/sessions/3')
                .then(r => r.json())
                .then(json => {
                    this.post = json;
                    this.loading = false;
                    return;
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
