<template>
    <div>
        <p>{{msgFinal}}</p>
    </div>
</template>

<script>

    export default {

    props:{
            msgFinal: undefined
    },
        name: 'MsgFinalComponent',
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