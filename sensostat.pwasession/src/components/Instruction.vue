<template>
    <div>
        <p>{{currentInstruction.libelle}}</p>
        <p></p>
        <br />

        <p>Cliquez ou dites :</p>
        <a class="btn btn-warning" @click="nextInstruction">Etape suivante</a>
    </div>
</template>

<script>

export default {
    props:{
        currentInstruction: undefined
    },
    name: 'InstructionComponent',
    methods:{
        nextInstruction(){
            this.$emit('nextInstruction')
        }
    }

}
</script>