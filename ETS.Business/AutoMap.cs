using AutoMapper;
using ETS.Common.DTO;
using ETS.Data.Entities;

namespace ETS.Business
{
    public class AutoMap : IMapper
    {
        public Mapper AutoMapper { get; set; }

        public AutoMap()
        {
            AutoMapper = InitializeAutomapper();
        }

        private AutoMapper.Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PersonelDTO, Personel>().ReverseMap();
                cfg.CreateMap<ETS.Common.Models.User, User>().ReverseMap();   
            });
            
            var mapper = new AutoMapper.Mapper(config);
            return mapper;
        }
    }
}
