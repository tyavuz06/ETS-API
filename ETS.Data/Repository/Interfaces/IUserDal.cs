using ETS.Data.Entities;
using ETS.Data.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Data.Repository.Interfaces
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
