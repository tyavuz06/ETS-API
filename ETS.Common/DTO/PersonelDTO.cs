using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Common.DTO
{
    public class PersonelDTO
    {
        public PersonelDTO() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nullable<bool> IsMale { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
