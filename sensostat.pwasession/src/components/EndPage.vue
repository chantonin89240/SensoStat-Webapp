<template>
    <div class="post">

        <p>{{ endMessage }}</p>

    </div>
</template>

<script lang="js">

    export default {
        name: "EndPageComponent",
        props: {
            endMessage: undefined,
        }
    };
</script>