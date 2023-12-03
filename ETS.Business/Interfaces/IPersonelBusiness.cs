using ETS.Common.DTO;
using ETS.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Business.Interfaces
{
    public interface IPersonelBusiness
    {
        /// <summary>
        /// Creates a new Course Element
        /// </summary>
        /// <param name="course">It Take CourseDTO Model</param>
        /// <returns>BaseResponseModel</returns>
        public BaseResponseModel Add(PersonelDTO course);

        /// <summary>
        /// Deletes a Course Element
        /// </summary>
        /// <param name="course">It Take CourseDTO Model</param>
        /// <returns>BaseResponseModel</returns>
        public BaseResponseModel Delete(int id);

        /// <summary>
        /// Updates a Course Element
        /// </summary>
        /// <param name="course">It Take CourseDTO Model</param>
        /// <returns>BaseResponseModel</returns>
        public BaseResponseModel Update(int id, PersonelDTO course);

        /// <summary>
        /// Gets All Course List
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Task<PersonelListGetResponseModel> GetAll();

        /// <summary>
        /// Gets All Course List
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public PersonelDetailGetResponseModel Get(int id);
    }
}
