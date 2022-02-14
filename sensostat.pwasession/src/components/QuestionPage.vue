<template>
    <div class="post">

        <p>c'est à vous !</p>

        <textarea></textarea>

        <i class="fa-solid fa-microphone"></i>

        <a class="btn btn-warning" href="">Etape suivante</a>

    </div>
</template>

<script lang="js">

    export default {
        name: "QuestionPageComponent",
        props: {
            question: undefined,
        }
    };
</script>