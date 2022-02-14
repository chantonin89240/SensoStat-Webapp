// <copyright file="JwtSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SensoStat.WebAPI.Helpers
{
    using System;

    /** Cette classe contient les propriétés définies dans le fichier appsettings.json 
     * et est utilisée pour accéder aux paramètres de l'application via des objets injectés dans 
     * les classes à l'aide du système d'injection de dépendances (DI) intégré à .NET. 
     *
     * Par exemple, le service utilisateur accède aux paramètres de l'application via un objet 
     * IOptions<ApiSettings> appSettings qui est injecté dans le constructeur.
     */
    public class JwtSettings
    {
        /// <summary>
        /// Secret utilisé pour vérifier le jeton JWT.
        /// </summary>
        public string JwtSecret { get; set; }

        /// <summary>
        /// Emetteur du jeton (ici l'URL de l'API). (Exemple: https://domain.tld/).
        /// </summary>
        public string JwtIssuer { get; set; }

        /// <summary>
        /// Cible du jeton JWT (quel service doit accepter ce jeton). (Exemple: https://domain.tld/).
        /// </summary>
        public string JwtAudience { get; set; }
    }
}