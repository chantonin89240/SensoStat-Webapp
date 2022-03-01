<template>
    <div>
        <p>Vous avez r&eacute;pondu :</p>

        <div class="form-floating">
            <textarea class="form-control" placeholder="Leave a comment here" id="floatingTextarea" v-model="response">{{ response }}</textarea>
            <label for="floatingTextarea">Comments</label>
        </div>

        <i class="fa-solid fa-microphone"></i>

        <p>Pour valider, dites :</p>
        <a class="btn btn-warning" @click="nextInstruction">Valider</a>

        <p>Pour reformuler, dites :</p>
        <a class="btn btn-warning" @click="reformuler">Reformuler</a>
    </div>
</template>

<script>

export default {
    
    props:{
        response: null
    },
    name: 'QuestionValidationComponent',
    methods:{
        nextInstruction() {
            this.$emit('envoieResponse', this.response)
            this.$emit('nextInstruction')
        },
        reformuler() {
            this.$emit('questionResponse')
        },
    }

}
</script>