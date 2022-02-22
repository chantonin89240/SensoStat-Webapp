<template>
    <div>
        <p>{{currentInstruction.libelle}}</p>
        <br />

        <p>Pour r&eacute;pondre, dites :</p>
        <a class="btn btn-warning" @click="questionResponse">R&eacute;pondre</a>

        <p>Pour r&eacute;p&eacute;ter la question, dites :</p>
        <a class="btn btn-warning" @click="repeteSpeech">R&eacute;p&eacute;ter</a>
    </div>
</template>

<script>

export default {
    
    props:{
        currentInstruction : null
    },
    name: 'QuestionInstructionComponent',
    methods:{
        questionResponse() {
            this.$emit('questionResponse')
        },
        repeteSpeech() {
            this.$emit('repeteSpeech')
        }
    }

}
</script>