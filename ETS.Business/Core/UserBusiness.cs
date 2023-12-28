using ETS.Business.Interfaces;
using ETS.Common.Models;
using ETS.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Business.Core
{
    public class UserBusiness : IUserService
    {
        private readonly IUserDal _service;
        private readonly IMapper _mapper;
        public UserBusiness(IUserDal service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public User GetUserByCredentials(string email, string password)
        {
            
            var entity = _service.Get(x => x.Email == email && x.Password == password);
            return _mapper.AutoMapper.Map<ETS.Common.Models.User>(entity);
        }
    }
}
