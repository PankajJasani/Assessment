using Assessment.BusinessEntity;
using Assessment.BusinessLogicLayer.interfaces;
using Assessment.DataAccessLayer.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.BusinessLogicLayer
{
    public class LookupProcessor : ILookupProcessor
    {
        private readonly ICityRepository _cityRepository;
        private readonly ILogger<LookupProcessor> _logger;

        public LookupProcessor(ICityRepository cityRepository, ILogger<LookupProcessor> logger)
        {
            _cityRepository = cityRepository;
            _logger = logger;
        }


        public List<CityBE> GetCities()
        {
            try
            {
                return _cityRepository.GetCities();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                throw;
            }
        }
    }
}
