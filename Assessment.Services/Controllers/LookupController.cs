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
    public class LookupController : ControllerBase
    {

        private readonly ILookupProcessor _cityProcessor;
        private readonly ILogger<LookupController> _logger;

        public LookupController(ILookupProcessor personProcessor, ILogger<LookupController> logger)
        {
            _cityProcessor = personProcessor;
            _logger = logger;
        }

        // GET: api/<LookupController>
        [HttpGet]
        public IEnumerable<CityBE> GetCities()
        {
            try
            {
                return _cityProcessor.GetCities();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                throw;
            }
        }

        
    }
}
