<template>
    <div id="app">
        <!-- Navbar -->
        <NavbarComponent></NavbarComponent>

        <!-- section ou sera rassembler les components et trier -->
        <section class="container">
            <p v-text="post.instructions[0].libelle"></p>
            <p v-text="nbChronology"></p>
            <br />

            <p>Cliquez ou dites :</p>
            <a class="btn btn-warning" @click="verifInstruction">Etape suivante</a>
        </section>

        <!-- Footer -->
        <FooterComponent></FooterComponent>
    </div>
</template>

<script>
    import NavbarComponent from './components/Navbar.vue';
    import FooterComponent from './components/Footer';

export default {
    name: 'App',
    components: {
        NavbarComponent,
        FooterComponent,
        },
    data() {
        return {
            loading: false,
            post: null,
            chronology: null,
            nbChronology: null,
            isQuestion: null,
            vrai: false
        };
    },
    created() {
        // fetch the data when the view is created and the data is
        // already being observed
        this.fetchData();
    },
    beforeMount() {
        this.nbChronology = this.post.instructions[0].libelle;
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
