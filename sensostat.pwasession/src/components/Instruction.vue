<template>
    <div>
        <p>aaaaaaaaaaaaa</p>
        <p></p>
        <br />

        <p>Cliquez ou dites :</p>
        <a class="btn btn-warning" @click="verifInstruction">Etape suivante</a>
    </div>
</template>

<script>

export default {
    props:{
        currentInstruction: undefined
    },
    name: 'InstructionComponent',

}
</script>