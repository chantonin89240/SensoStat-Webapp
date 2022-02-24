<template>
    <div>
        <QuestionInstructionComponent v-if="questionInstru" @questionResponse="questionResponse" v-bind:currentInstruction="currentInstruction" @repeteSpeech="repeteSpeech"/>
        <QuestionReponseComponent v-if="questionReponse" @questionValide="questionValide"/>
        <QuestionValidationComponent v-if="questionValidation" @nextInstruction="nextInstruction" v-bind:response="response" />
    </div>
</template>

<script>
    import QuestionInstructionComponent from "./QuestionInstruction.vue";
    import QuestionReponseComponent from "./QuestionReponse.vue";
    import QuestionValidationComponent from "./QuestionValidation.vue";

export default {

    props:{
        currentInstruction: undefined
    },
    components : {
        QuestionInstructionComponent,
        QuestionReponseComponent,
        QuestionValidationComponent
        },
    data() {
        return {
            questionInstru: true,
            questionReponse: false,
            questionValidation: false,
            response: null,
        };
    },
    name: 'QuestionComponent',
    methods:{
        nextInstruction() {
            this.$emit('nextInstruction')
            this.questionInstru = true;
            this.questionReponse = false;
            this.questionValidation = false;
        },
        questionResponse() {
            this.questionInstru = false;
            this.questionReponse = true;
            this.questionValidation = false;
        },
        questionValide(response) {
            this.questionInstru = false;
            this.questionReponse = false;
            this.questionValidation = true;
            this.response = response;
        },
        repeteSpeech() {
            this.$emit('repeteSpeech')
        }
    }

}
</script>