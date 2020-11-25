using System;
using System.Collections.Generic;

#nullable disable

namespace Assessment.DataAccessLayer.Models
{
    public partial class AsPerson
    {
        public long PersonId { get; set; }
        public Guid UniqueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CityId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Operation { get; set; }

        public virtual AsCity City { get; set; }
    }
}
