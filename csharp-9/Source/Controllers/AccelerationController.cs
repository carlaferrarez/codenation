using System;
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
    public class AccelerationController : ControllerBase
    {
        private IAccelerationService _accelerationService;
        private readonly IMapper _mapper;

        public AccelerationController(IAccelerationService acceleration, IMapper mapper)
        {
            _accelerationService = acceleration;
            _mapper = mapper;
        }

        // GET api/acceleration/{id}
        [HttpGet("{id}")]
        public ActionResult<AccelerationDTO> Get(int id)
        {
            var acceleration = _accelerationService.FindById(id);

            if (acceleration != null)
            {
                var retorno = _mapper.Map<AccelerationDTO>(acceleration);

                return Ok(retorno);
            }

            else
                return NotFound();
        }

        // GET api/acceleration
        [HttpGet]
        public ActionResult<IEnumerable<AccelerationDTO>> GetAll(int? companyId = null)
        {
            if (companyId.HasValue)
            {
                var acceleration = _accelerationService.FindByCompanyId(companyId.Value).ToList();
                var retorno = _mapper.Map<List<AccelerationDTO>>(acceleration);

                return Ok(retorno);
            }

            else
                return NoContent();
        }

        // POST api/acceleration
        [HttpPost]
        public ActionResult<AccelerationDTO> Post([FromBody] AccelerationDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var acceleration = _mapper.Map<Models.Acceleration>(value);
            var retorno = _accelerationService.Save(acceleration);

            return Ok(_mapper.Map<AccelerationDTO>(retorno));
        }
    }
    
}
