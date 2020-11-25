using Assessment.BusinessEntity;
using Assessment.BusinessLogicLayer.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assessment.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonProcessor _personProcessor;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonProcessor personProcessor, ILogger<PersonController> logger)
        {
            _personProcessor = personProcessor;
            _logger = logger;
        }
        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<PersonBE> Get()
        {
            try
            {
                return _personProcessor.Get();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                throw;
            }
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public PersonBE Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    return _personProcessor.Get(id);
                }
                else
                {
                    throw new ArgumentException("Invalid id input parameter");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                throw;
            }
            //return "value";
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Post(PersonBE person)
        {
            try
            {
                if (person != null)
                {
                    _personProcessor.Post(person);
                }
                else
                {
                    throw new ArgumentNullException("Invalid id input parameter");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                throw;
            }
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, PersonBE person)
        {
            try
            {
                if (person != null && id > 0)
                {
                    person.PersonId = id;
                    _personProcessor.Put(person);
                }
                else
                {
                    throw new ArgumentException("Invalid input parameters");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                throw;
            }
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                if (id > 0)
                {

                    _personProcessor.Delete(id);
                }
                else
                {
                    throw new ArgumentException("Invalid input parameters");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                throw;
            }
        }
    }
}
