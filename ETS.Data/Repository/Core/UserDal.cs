using ETS.Data.Entities;
using ETS.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Data.Repository.Core
{
    public class UserDal : RepositoryBase<User, ETSContext>, IUserDal
    {
    }
}
