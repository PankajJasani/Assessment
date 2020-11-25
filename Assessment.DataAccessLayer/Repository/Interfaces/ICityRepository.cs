using Assessment.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.DataAccessLayer.Repository.Interfaces
{
    public interface ICityRepository
    {
        List<CityBE> GetCities();
    }
}
