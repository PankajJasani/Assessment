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
    public class PersonProcessor : IPersonProcessor
    {
        private readonly IPersonRepository _personRepository;
        private readonly ILogger<PersonProcessor> _logger;

        public PersonProcessor(IPersonRepository personRepostory, ILogger<PersonProcessor> logger)
        {
            _personRepository = personRepostory;
            _logger = logger;
        }

       
        public IEnumerable<PersonBE> Get()
        {
            try
            {
                return _personRepository.Get();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                throw;
            }
        }

       
        public PersonBE Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    return _personRepository.Get(id);
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

        
        public void Post(PersonBE person)
        {
            try
            {
                if (person != null)
                {
                    _personRepository.Post(person);
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

       
        public void Put(PersonBE person)
        {
            try
            {
                if (person != null )
                {
                   
                    _personRepository.Put(person);
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

       
        public void Delete(int id)
        {
            try
            {
                if (id > 0)
                {

                    _personRepository.Delete(id);
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
