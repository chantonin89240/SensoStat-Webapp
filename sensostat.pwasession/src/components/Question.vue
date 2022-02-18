<template>
    <div>
        <QuestionInstructionComponent v-bind:currentInstruction="currentInstruction"/>
        <QuestionReponseComponent/>
        <QuestionValidationComponent/>
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
    name: 'QuestionComponent',
    methods:{
        nextInstruction(){
            this.$emit('nextInstruction', this.currentInstruction)
        }
    }

}
</script>