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
    public class PersonRepository : IPersonRepository
    {
        private readonly AssessmentDBContext _assessmentDBContext;
        private readonly ILogger<PersonRepository> _logger;

        public PersonRepository(AssessmentDBContext assessmentDBContext, ILogger<PersonRepository> logger)
        {
            _assessmentDBContext = assessmentDBContext;
            _logger = logger;
        }


        public IEnumerable<PersonBE> Get()
        {
            try
            {
                return (from e in _assessmentDBContext.AsPeople where e.Operation!="D" orderby e.LastName
                        select new PersonBE
                        {
                            PersonId = e.PersonId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            CityId = e.CityId,
                            CityName = e.City.CityName,
                            PhoneNumber = e.PhoneNumber

                        }).ToList();
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
                    return (from e in _assessmentDBContext.AsPeople
                            select new PersonBE
                            {
                                PersonId = e.PersonId,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                CityId = e.CityId,
                                CityName = e.City.CityName,
                                PhoneNumber = e.PhoneNumber

                            }).FirstOrDefault();
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
                    var asPerson = new AsPerson
                    {
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        CityId = _assessmentDBContext.AsCities.Where(c => c.CityName.Equals(person.CityName)).Select(c => c.CityId).First(),
                        PhoneNumber = person.PhoneNumber,
                        Operation = "A",
                        AddedBy = "Application",
                        AddedDate = DateTime.UtcNow
                    };
                    _assessmentDBContext.Add<AsPerson>(asPerson);
                    _assessmentDBContext.SaveChanges();
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
                if (person != null)
                {

                    AsPerson asperson = (from e in _assessmentDBContext.AsPeople
                                         where e.PersonId == e.PersonId
                                         select e).FirstOrDefault();

                    asperson.FirstName = person.FirstName;
                    asperson.LastName = person.LastName;
                    asperson.CityId = _assessmentDBContext.AsCities.Where(c => c.CityName.Equals(person.CityName)).Select(c => c.CityId).First();
                    asperson.PhoneNumber = person.PhoneNumber;
                    asperson.UpdatedBy = "Application";
                    asperson.UpdatedDate = DateTime.UtcNow;
                    asperson.Operation = "U";
                    _assessmentDBContext.SaveChanges();
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

                    AsPerson asperson = (from e in _assessmentDBContext.AsPeople
                                         where e.PersonId == e.PersonId
                                         select e).FirstOrDefault();

                    asperson.UpdatedBy = "Application";
                    asperson.UpdatedDate = DateTime.UtcNow;
                    asperson.Operation = "D";
                    _assessmentDBContext.SaveChanges();
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
