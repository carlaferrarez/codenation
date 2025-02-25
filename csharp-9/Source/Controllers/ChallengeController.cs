﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private IChallengeService _challengeService;
        private readonly IMapper _mapper;
        public ChallengeController(IChallengeService service, IMapper mapper)
        {
            _challengeService = service;
            _mapper = mapper;
        }

        // GET api/challenge
        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if (accelerationId.HasValue && userId.HasValue)
            {
                var challenge = _challengeService.FindByAccelerationIdAndUserId(accelerationId.Value, userId.Value).ToList();
                var retorno = _mapper.Map<List<ChallengeDTO>>(challenge);

                return Ok(retorno);
            }

            else
                return NoContent();
        }

        // POST api/challenge
        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var challenge = _mapper.Map<Models.Challenge>(value);
            var retorno = _challengeService.Save(challenge);

            return Ok(_mapper.Map<ChallengeDTO>(retorno));
        }

    }
}
