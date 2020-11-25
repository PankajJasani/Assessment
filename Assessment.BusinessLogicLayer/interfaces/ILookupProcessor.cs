using Assessment.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.BusinessLogicLayer.interfaces
{
    public interface ILookupProcessor
    {
        List<CityBE> GetCities();
    }
}
