using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Data.Entities
{
    public class User : IEntity
    {
        public User() { }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdateDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}
