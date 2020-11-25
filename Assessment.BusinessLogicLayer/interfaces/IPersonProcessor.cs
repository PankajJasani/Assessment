using Assessment.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.BusinessLogicLayer.interfaces
{
    public interface IPersonProcessor
    {

        public IEnumerable<PersonBE> Get();


        public PersonBE Get(int id);


      
        public void Post(PersonBE person);



        public void Put(PersonBE person);



        public void Delete(int id);
     

    }
}
