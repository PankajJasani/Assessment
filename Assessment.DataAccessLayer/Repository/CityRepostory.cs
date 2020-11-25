using Assessment.BusinessEntity;
using Assessment.DataAccessLayer.Models;
using Assessment.DataAccessLayer.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.DataAccessLayer.Repository
{
    public class CityRepository: ICityRepository
    {
        private readonly AssessmentDBContext _assessmentDBContext;
        private readonly ILogger<CityRepository> _logger;

        public CityRepository(AssessmentDBContext assessmentDBContext, ILogger<CityRepository> logger)
        {
            _assessmentDBContext = assessmentDBContext;
            _logger = logger;
        }


        public List<CityBE> GetCities()
        {
            try
            {
                return (from e in _assessmentDBContext.AsCities 
                        select new CityBE
                        {
                            Id = e.CityId,
                            CityName = e.CityName

                        }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                throw;
            }
        }
    }
}
