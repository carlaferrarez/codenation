﻿
using System;
using System.Collections.Generic;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _service;

        public QuoteController(IQuoteService service)
        {
            _service = service;
        }

        // GET api/quote
        [HttpGet]
        public ActionResult<QuoteView> GetAnyQuote()
        {
            var quote = _service.GetAnyQuote();

            if (quote != null)
            {
                var getJsonResponse = new QuoteView()
                {
                    Id = quote.Id,
                    Actor = quote.Actor,
                    Detail = quote.Detail
                };
                return getJsonResponse;
            }
            else
                return NotFound();
        }

        // GET api/quote/{actor}
        [HttpGet("{actor}")]
        public ActionResult<QuoteView> GetAnyQuote(string actor)
        {
            var quotebyactor = _service.GetAnyQuote(actor);

            if (quotebyactor != null)
            {
                var getJsonResponse = new QuoteView()
                {
                    Id = quotebyactor.Id,
                    Actor = quotebyactor.Actor,
                    Detail = quotebyactor.Detail
                };
                return getJsonResponse;
            }
            else
                return NotFound();
        }

    }
}
