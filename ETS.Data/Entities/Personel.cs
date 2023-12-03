using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Data.Entities
{
    public class Personel : IEntity
    {
        public Personel()
        {
            UpdatedBy = string.Empty;
            CreatedBy = string.Empty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nullable<bool> IsMale { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
