<template>
    <div class="post">

        <p>{{ post.instructions[0].libelle }}</p>

        <p>Cliquez ou dites :</p>
        <a class="btn btn-warning" href="" >Etape suivante</a>
    </div>
</template>

<script lang="js">

    export default {
        name: "HomePage",
        props: {
            post: undefined,
        }
    };
</script>