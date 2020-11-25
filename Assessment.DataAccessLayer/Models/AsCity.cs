using System;
using System.Collections.Generic;

#nullable disable

namespace Assessment.DataAccessLayer.Models
{
    public partial class AsCity
    {
        public AsCity()
        {
            AsPeople = new HashSet<AsPerson>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Operation { get; set; }

        public virtual ICollection<AsPerson> AsPeople { get; set; }
    }
}
