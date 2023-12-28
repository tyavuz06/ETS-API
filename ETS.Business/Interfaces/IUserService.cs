using ETS.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Business.Interfaces
{
    public interface IUserService
    {
        public User GetUserByCredentials(string email, string password);
    }
}
