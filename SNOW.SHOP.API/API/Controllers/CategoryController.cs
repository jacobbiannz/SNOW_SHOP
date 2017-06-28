using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SNOW.SHOP.API.Data;
using SNOW.SHOP.API.API.Response;
using SNOW.SHOP.API.API.Extentions;
using Microsoft.EntityFrameworkCore;
using SNOW.SHOP.API.API.ViewModel;
using SNOW.SHOP.API.src.Model;

namespace SNOW.SHOP.API.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {

        private ISnowShopAPIRepository SnowShopAPIRepository;


        public CategoryController(ISnowShopAPIRepository repository)
        {
            SnowShopAPIRepository = repository;
        }

        protected override void Dispose(Boolean disposing)
        {
            SnowShopAPIRepository?.Dispose();

            base.Dispose(disposing);
        }

        // GET Production/Category
        /// <summary>
        /// Retrieves a list of Categories
        /// </summary>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="name">Name</param>
        /// <returns>List response</returns>
        [HttpGet]
        [Route("Categories")]
        public async Task<IActionResult> GetCategories(Int32? pageSize = 10, Int32? pageNumber = 1, String name = null)
        {
            var response = new ListModelResponse<CategoryViewModel>() as IListModelResponse<CategoryViewModel>;

            try
            {
                response.PageSize = (Int32)pageSize;
                response.PageNumber = (Int32)pageNumber;

                response.Model = await SnowShopAPIRepository
                        .GetCategories(response.PageSize, response.PageNumber, name)
                        .Select(item => item.ToViewModel())
                        .ToListAsync();

                response.Message = String.Format("Total of records: {0}", response.Model.Count());
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        // GET Production/Category/5
        /// <summary>
        /// Retrieves a specific Category by id
        /// </summary>
        /// <param name="id">CategoryID</param>
        /// <returns>Single response</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(Int32 id)
        {
            var response = new SingleModelResponse<CategoryViewModel>() as ISingleModelResponse<CategoryViewModel>;

            try
            {
                var entity = await SnowShopAPIRepository.GetCategoryAsync(new Category { Id = id });

                response.Model = entity.ToViewModel();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        // POST Production/Category/
        /// <summary>
        /// Creates a new user on Production catalog
        /// </summary>
        /// <param name="value">Category entry</param>
        /// <returns>Single response</returns>
        [HttpPost]
        [Route("Category"), Obsolete]
        private async Task<IActionResult> CreateCategory([FromBody]CategoryViewModel value)
        {
            var response = new SingleModelResponse<CategoryViewModel>() as ISingleModelResponse<CategoryViewModel>;

            try
            {
                var entity = await SnowShopAPIRepository.AddCategoryAsync(value.ToEntity());

                response.Model = entity.ToViewModel();
                response.Message = "The data was saved successfully";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return response.ToHttpResponse();
        }

        // PUT Production/Category/5
        /// <summary>
        /// Updates an existing Category
        /// </summary>
        /// <param name="value">Product entry</param>
        /// <returns>Single response</returns>
        [HttpPut]
        [Route("Category"), Obsolete]
        private async Task<IActionResult> UpdateCategory([FromBody]CategoryViewModel value)
        {
            var response = new SingleModelResponse<CategoryViewModel>() as ISingleModelResponse<CategoryViewModel>;

            try
            {
                var entity = await SnowShopAPIRepository.UpdateCategoryAsync(value.ToEntity());

                response.Model = entity.ToViewModel();
                response.Message = "The record was updated successfully";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        // DELETE Production/Category/5
        /// <summary>
        /// Delete an existing Category
        /// </summary>
        /// <param name="id">Category ID</param>
        /// <returns>Single response</returns>
        [HttpDelete]
        [Route("Category/{id}"), Obsolete]
        private async Task<IActionResult> DeleteCategory(Int32 id)
        {
            var response = new SingleModelResponse<CategoryViewModel>() as ISingleModelResponse<CategoryViewModel>;

            try
            {
                var entity = await SnowShopAPIRepository.DeleteCategoryAsync(new Category { Id = id });

                response.Model = entity.ToViewModel();
                response.Message = "The record was deleted successfully";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }
    }
}
