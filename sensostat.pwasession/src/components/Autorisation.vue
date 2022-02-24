<template>
    <div>
        <p>Autorisez vous l'utilisation de votre micro</p>

        <a class="btn btn-warning" @click="autorisation('oui')">Oui</a>
        <br/>
        <a class="btn btn-warning" @click="autorisation('non')">Non</a>

    </div>
</template>

<script>

    export default {

    props:{
            
    },
        name: 'AutorisationComponent',
    data() {
        return {

        };
    },

    methods:{
        autorisation(text) {
            this.$emit('autorisation', text)
        },
    }
}
</script>