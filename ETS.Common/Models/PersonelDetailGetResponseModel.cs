using ETS.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Common.Models
{
    public class PersonelDetailGetResponseModel : BaseResponseModel
    {
        public PersonelDTO Data { get; set; }
    }
}
