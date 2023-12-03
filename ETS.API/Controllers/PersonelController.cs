using ETS.Business.Core;
using ETS.Business.Interfaces;
using ETS.Common.DTO;
using ETS.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonelBusiness _personelBusiness;
        public PersonelController(IPersonelBusiness personelBusiness) => (_personelBusiness) = (personelBusiness);

        /// <summary>
        /// Create Course Element
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Create")]
        public IActionResult Create(PersonelDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = _personelBusiness.Add(model);
                switch (response.Code)
                {
                    case (int)SystemConstans.CODES.SUCCESS:
                        return Ok(response);
                    case (int)SystemConstans.CODES.NOTFOUND:
                        return NotFound(response);
                    case (int)SystemConstans.CODES.SYSTEMERROR:
                        return StatusCode(500, response);
                    default:
                        return NotFound();
                }
            }

            return StatusCode(200, "Model Is Not Valid");
        }

        /// <summary>
        /// Delete Course Element
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _personelBusiness.Delete(id);

            switch (response.Code)
            {
                case (int)SystemConstans.CODES.SUCCESS:
                    return Ok(response);
                case (int)SystemConstans.CODES.NOTFOUND:
                    return NotFound(response);
                case (int)SystemConstans.CODES.SYSTEMERROR:
                    return StatusCode(500, response);
                default:
                    return NotFound();
            }
        }

        /// <summary>
        /// Update Course Element
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update/{id}")]
        public IActionResult Update(int id, [FromBody] PersonelDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = _personelBusiness.Update(id, model);

                switch (response.Code)
                {
                    case (int)SystemConstans.CODES.SUCCESS:
                        return Ok(response);
                    case (int)SystemConstans.CODES.NOTFOUND:
                        return NotFound(response);
                    case (int)SystemConstans.CODES.SYSTEMERROR:
                        return StatusCode(500, response);
                    default:
                        return NotFound();
                }
            }

            return StatusCode(200, "Model Is Not Valid");
        }

        /// <summary>
        /// Gets All Course List
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _personelBusiness.GetAll();

            switch (response.Code)
            {
                case (int)SystemConstans.CODES.SUCCESS:
                    return Ok(response);
                case (int)SystemConstans.CODES.NOTFOUND:
                    return NotFound(response);
                case (int)SystemConstans.CODES.SYSTEMERROR:
                    return StatusCode(500, response);
                default:
                    return NotFound();
            }
        }

        /// <summary>
        /// Gets All Course List
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            var response = _personelBusiness.Get(id);

            switch (response.Code)
            {
                case (int)SystemConstans.CODES.SUCCESS:
                    return Ok(response);
                case (int)SystemConstans.CODES.NOTFOUND:
                    return NotFound(response);
                case (int)SystemConstans.CODES.SYSTEMERROR:
                    return StatusCode(500, response);
                default:
                    return NotFound();
            }
        }
    }
}
