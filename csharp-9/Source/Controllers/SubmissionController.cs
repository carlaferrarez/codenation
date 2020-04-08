﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private ISubmissionService _submissionService;
        private readonly IMapper _mapper;

        public SubmissionController(ISubmissionService submission, IMapper mapper)
        {
            _submissionService = submission;
            _mapper = mapper;
        }

        // GET api/submission/higherScore
        [HttpGet("higherScore")]
        public ActionResult<SubmissionDTO> GetHigherScore(int? challengeId)
        {
            if (challengeId.HasValue)
            {
                var submission = _submissionService.FindHigherScoreByChallengeId(challengeId.Value);
                //var retorno = _mapper.Map<SubmissionDTO>(submission);

                return Ok(submission);
            }

            else
                return NoContent();
        }

        // GET api/submission
        [HttpGet]
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll(int? accelerationId = null, int? challengeId = null)
        {
            if (accelerationId.HasValue && challengeId.HasValue)
            {
                var submission = _submissionService.FindByChallengeIdAndAccelerationId(accelerationId.Value, challengeId.Value).ToList();
                var retorno = _mapper.Map<List<SubmissionDTO>>(submission);

                return Ok(retorno);
            }

            else
                return NoContent();
        }

        // POST api/submission
        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var submission = _mapper.Map<Models.Submission>(value);
            var retorno = _submissionService.Save(submission);

            return Ok(_mapper.Map<SubmissionDTO>(retorno));
        }
    }
}
