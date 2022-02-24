<template>
    <div>
        <p>{{currentText}}</p>
        <p></p>
        <br />

        <p>Cliquez ou dites :</p>
        <a class="btn btn-warning" @click="nextInstruction">Etape suivante</a>


    </div>
</template>

<script>

    export default {

    props:{
            currentText: undefined
    },
        name: 'MsgAccueilComponent',
    data() {
        return {

        };
    },

    methods:{
        nextInstruction(){
            this.$emit('nextInstruction')
        },
    }
}
</script>