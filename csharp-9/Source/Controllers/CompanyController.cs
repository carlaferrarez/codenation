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
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService service, IMapper mapper)
        {
            _companyService = service;
            _mapper = mapper;
        }

        // GET api/company/{id}
        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            var company = _companyService.FindById(id);

            if (company != null)
            {
                var retorno = _mapper.Map<CompanyDTO>(company);

                return Ok(retorno);
            }

            else
                return NotFound();
        }

        // GET api/company
        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if (accelerationId.HasValue && userId == null)
            {
                var acceleration = _companyService.FindByAccelerationId(accelerationId.Value).ToList();
                var retorno = _mapper.Map<List<CompanyDTO>>(acceleration);

                return Ok(retorno);
            }

            else if (userId.HasValue && accelerationId == null)
            {
                // mesma coisa do de cima, mas de outra forma
                return Ok(_companyService.FindByUserId(userId.Value).
                    Select(x => _mapper.Map<CompanyDTO>(x)).
                    ToList());
            }

            else
                return NoContent();
        }

        // POST api/company
        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var company = _mapper.Map<Company>(value);
            var retorno = _companyService.Save(company);

            return Ok(_mapper.Map<CompanyDTO>(retorno));
        }
    }
}
