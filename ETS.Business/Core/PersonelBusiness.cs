using ETS.Business.Interfaces;
using ETS.Common.DTO;
using ETS.Common.Models;
using ETS.Data.Entities;
using ETS.Data.Repository.Interfaces;

namespace ETS.Business.Core
{
    public class PersonelBusiness : IPersonelBusiness
    {
        private readonly IPersonelDal _service;
        private readonly IMapper _mapper;
        public PersonelBusiness(IPersonelDal service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public BaseResponseModel Add(PersonelDTO model)
        {
            var baseResponseModel = new BaseResponseModel();

            try
            {
                var entity = _mapper.AutoMapper.Map<PersonelDTO, Personel>(model);
                entity.CreateDate = DateTime.Now;
                _service.Add(entity);
                baseResponseModel.Id = entity.Id;
                baseResponseModel.SetCode(Common.SystemConstans.CODES.SUCCESS);
            }
            catch (Exception ex)
            {
                //log ex
                baseResponseModel.SetCode(Common.SystemConstans.CODES.SYSTEMERROR);
            }

            return baseResponseModel;
        }

        public BaseResponseModel Delete(int id)
        {
            var baseResponseModel = new BaseResponseModel();

            try
            {
                var entity = _service.Get(x => x.Id == id);

                if (entity != null)
                {
                    _service.Delete(entity);
                    baseResponseModel.SetCode(Common.SystemConstans.CODES.SUCCESS);
                }
                else
                    baseResponseModel.SetCode(Common.SystemConstans.CODES.NOTFOUND);
            }
            catch (Exception ex)
            {
                //log ex
                baseResponseModel.SetCode(Common.SystemConstans.CODES.SYSTEMERROR);
            }

            return baseResponseModel;
        }

        public PersonelDetailGetResponseModel Get(int id)
        {
            var baseResponseModel = new PersonelDetailGetResponseModel();

            try
            {
                var entity = _service.Get(x => x.Id == id);

                if (entity != null)
                {
                    baseResponseModel.Data = _mapper.AutoMapper.Map<Personel, PersonelDTO>(entity);
                    baseResponseModel.SetCode(Common.SystemConstans.CODES.SUCCESS);
                }
                else
                    baseResponseModel.SetCode(Common.SystemConstans.CODES.NOTFOUND);
            }
            catch (Exception ex)
            {
                //log ex
                baseResponseModel.SetCode(Common.SystemConstans.CODES.SYSTEMERROR);
            }

            return baseResponseModel;
        }

        public async Task<PersonelListGetResponseModel> GetAll()
        {
            var baseResponseModel = new PersonelListGetResponseModel();

            try
            {
                var list = await _service.GetList();
                baseResponseModel.Data = _mapper.AutoMapper.Map<List<Personel>, List<PersonelDTO>>(list);
                baseResponseModel.SetCode(Common.SystemConstans.CODES.SUCCESS);
            }
            catch (Exception ex)
            {
                //log ex
                baseResponseModel.SetCode(Common.SystemConstans.CODES.SYSTEMERROR);
            }

            return baseResponseModel;
        }

        public BaseResponseModel Update(int id, PersonelDTO model)
        {
            var baseResponseModel = new BaseResponseModel();

            try
            {
                var entity = _service.Get(x => x.Id == id);
                if (entity != null)
                {
                    entity = _mapper.AutoMapper.Map<PersonelDTO, Personel>(model);
                    entity.Id = id;
                    entity.UpdateDate = DateTime.Now;
                    _service.Update(entity);
                    baseResponseModel.SetCode(Common.SystemConstans.CODES.SUCCESS);
                }
                else
                    baseResponseModel.SetCode(Common.SystemConstans.CODES.NOTFOUND);
            }
            catch (Exception ex)
            {
                //log ex
                baseResponseModel.SetCode(Common.SystemConstans.CODES.SYSTEMERROR);
            }

            return baseResponseModel;
        }
    }
}
