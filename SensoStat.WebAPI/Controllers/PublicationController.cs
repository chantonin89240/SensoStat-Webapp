﻿namespace SensoStat.WebAPI.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Models.HttpResponse;
    using SensoStat.Services.Contracts;

    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        private readonly IPublicationService _publicationService;

        public PublicationController(IPublicationService publicationService)
        {
            _publicationService = publicationService;
        }

        [HttpPost]
        public bool Publish(int id)
        {
            return this._publicationService.Publish(id);
        }

        [HttpGet]
        public SessionResponse GetPublication()
        {
            return new SessionResponse();
        }
    }
}