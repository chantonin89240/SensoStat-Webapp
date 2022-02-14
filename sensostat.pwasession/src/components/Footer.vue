<template>
    <div>
        <nav class="navbar fixed-bottom navbar-light bg-white">
            <div class="container-fluid d-flex justify-content-center">
                <a class="navbar-brand h6 text-wrap fs-6" asp-area="" asp-controller="Home" asp-action="Index" asp-route-pageNumber="1">SensoStat - Tous droits réservés © SensoStat 2022 </a>
            </div>
        </nav>
    </div>
</template>

<script>export default {
    name: 'FooterComponent',

}</script>