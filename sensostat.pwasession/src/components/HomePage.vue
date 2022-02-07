<template>
    <div class="post">
        <div v-if="loading" class="loading">
            home page . See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>

        <div v-if="post" class="content">
            <table>
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>{{ post.name }}</td>
                        <td>{{ post.etat }}</td>
                        <td>{{ post.dateCreate }}</td>
                        <td>{{ post.instructions[0].libelle }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="js">
    import Vue from 'vue';

    export default {
        name: "HomePage",
        props: {
            post: undefined,
        }

        //data() {
        //    return {
        //        loading: false,
        //        post: null
        //    };
        //},
        //created() {
        //    // fetch the data when the view is created and the data is
        //    // already being observed
        //    this.fetchData();
        //},
        //watch: {
        //    // call again the method if the route changes
        //    '$route': 'fetchData'
        //},
        //methods: {
        //    fetchData() {
        //        this.post = null;
        //        this.loading = true;

        //        fetch('https://localhost:5001/api/sessions/3')
        //            .then(r => r.json())
        //            .then(json => {
        //                this.post = json;
        //                this.loading = false;
        //                return;
        //            });
        //    }
        //},
    };
</script>