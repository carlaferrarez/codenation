﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IdentityModel.Client;
using System.Threading.Tasks;

namespace Codenation.Challenge.Controllers
{
    [Authorize("Admin")]
    [Route("api/[controller]")]    
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService service;
        private readonly IMapper mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll(string accelerationName = null, int? companyId = null)
        {            
            if (accelerationName != null)
                return Ok(this.service.FindByAccelerationName(accelerationName).
                    Select(x => mapper.Map<UserDTO>(x)).
                    ToList());
            else if (companyId.HasValue)
                return Ok(this.service.FindByCompanyId(companyId.Value).
                    Select(x => mapper.Map<UserDTO>(x)).
                    ToList());
            else
                return NoContent();

        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {            
            return Ok(mapper.Map<UserDTO>(service.FindById(id)));
        }

        // POST api/user
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(mapper.Map<UserDTO>(service.Save(mapper.Map<User>(value))));
        }


        [HttpGet("GetToken")]

        public async Task<ActionResult<TokenResponse>> GetToken([FromBody]TokenDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            var tokenClient = new TokenClient(disco.TokenEndpoint, "codenation.api_client", "codenation.api_secret");
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(value.UserName, value.Password, "codenation");

            if (!tokenResponse.IsError)
                return Ok(tokenResponse);

            return Unauthorized(tokenResponse.ErrorDescription); 

        }


     
    }
}
