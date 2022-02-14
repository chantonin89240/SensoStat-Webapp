<template>
    <div class="post">

        <p>Cliquez ou dites :</p>
        <a class="btn btn-warning" href="">Etape suivante</a>

        <p>Pour r&eacute;pondre, dites :</p>
        <a class="btn btn-warning" href="">R&eacute;pondre</a>

        <p>La r&eacute;p&eacute;ter la question, dites :</p>
        <a class="btn btn-warning" href="">r&eacute;p&eacute;ter</a>

    </div>
</template>

<script lang="js">

    export default {
        name: "InstructionPageComponent",
        props: {
            instruction: undefined,
        }
    };
</script>