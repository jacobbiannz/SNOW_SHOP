using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SNOW.SHOP.API.Data;
using SNOW.SHOP.API.API.Response;
using SNOW.SHOP.API.API.ViewModel;
using SNOW.SHOP.API.API.Extentions;
using Microsoft.EntityFrameworkCore;
using SNOW.SHOP.API.src.Model;
using AutoMapper;
using SNOW.SHOP.API.src.Abstract;
using System.Collections.Generic;
using SNOW.SHOP.API.API.Core;
using Microsoft.AspNetCore.Authorization;

namespace SNOW.SHOP.API.API.Controllers
{
    [Route("api/[controller]")]
  //  [Authorize]
    public class CategoryController : Controller
    {

        private ICategoryRepository _categoryRepository;
        int page = 1;
        int pageSize = 4;

        public CategoryController(ICategoryRepository repository)
        {
            _categoryRepository = repository;
        }

       

        // GET Production/Category
        /// <summary>
        /// Retrieves a list of Products
        /// </summary>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="name">Name</param>
        /// <returns>List response</returns>
        [HttpGet]
        [Route("Categories")]
        public IActionResult GetCategories()
        {
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }

            int currentPage = page;
            int currentPageSize = pageSize;
            var totalProducts = _categoryRepository.Count();
            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);


            IEnumerable<Category> _categories = _categoryRepository
               .AllIncluding(s => s.Company, s=>s.AllProducts)
               .OrderBy(s => s.Id)
               .Skip((currentPage - 1) * currentPageSize)
               .Take(currentPageSize)
               .ToList();

            Response.AddPagination(page, pageSize, totalProducts, totalPages);

            var response = new ListModelResponse<CategoryViewModel>() as IListModelResponse<CategoryViewModel>;

            IEnumerable<CategoryViewModel> _categoriesVM = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(_categories);

            return new OkObjectResult(_categoriesVM);
        }

        // GET Production/Product/5
        /// <summary>
        /// Retrieves a specific Product by id
        /// </summary>
        /// <param name="id">ProductID</param>
        /// <returns>Single response</returns>
        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<IActionResult> GetCateogry(int id)
        {
            Category _category = await _categoryRepository
                 .GetSingleAsync(s => s.Id == id, s=>s.Company, s=>s.AllProducts);

            if (_category != null)
            {
                CategoryViewModel _categoryVM = Mapper.Map<Category, CategoryViewModel>(_category);
                return new OkObjectResult(_categoryVM);
            }
            else
            {
                return NotFound();
            }
        }

        // POST Production/Product/
        /// <summary>
        /// Creates a new user on Production catalog
        /// </summary>
        /// <param name="value">Product entry</param>
        /// <returns>Single response</returns>
        [HttpPost]
        
        private async Task<IActionResult> Create([FromBody]CategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category _newCategory = Mapper.Map<CategoryViewModel, Category>(category);
            _newCategory.CreatedDate = DateTime.Now;

           await _categoryRepository.AddAsync(_newCategory);

            // foreach (var userId in product.)
            //      {
            //         _newSchedule.Attendees.Add(new Attendee { UserId = userId });
            //     }
            //     _scheduleRepository.Commit();

            category = Mapper.Map<Category, CategoryViewModel>(_newCategory);

            CreatedAtRouteResult result = CreatedAtRoute("GetCategory", new { controller = "Category", id = category.ID }, category);
            return result;
        }

        // PUT Production/Product/5
        /// <summary>
        /// Updates an existing Product
        /// </summary>
        /// <param name="value">Product entry</param>
        /// <returns>Single response</returns>
        [HttpPut]
        [Route("Category")]
        private async Task<IActionResult> Put([FromBody]CategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category _categoryDb = await _categoryRepository.GetSingleAsync(category.ID);

            if (_categoryDb == null)
            {
                return NotFound();
            }
            else
            {
                _categoryDb.Name = category.Name;
                _categoryDb.CompanyId = _categoryDb.CompanyId;
              




               await _categoryRepository.CommitAsync();
            }

            category = Mapper.Map<Category, CategoryViewModel>(_categoryDb);

            return new NoContentResult();
        }

        // DELETE Production/Product/5
        /// <summary>
        /// Delete an existing Product
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Single response</returns>
        [HttpDelete("{id}", Name = "RemoveCategory")]
        private async Task<IActionResult> Delete(int id)
        {
            Category _categoryDb = await _categoryRepository.GetSingleAsync(id);

            if (_categoryDb == null)
            {
                return new NotFoundResult();
            }
            else
            {

               await _categoryRepository.DeleteAsync(_categoryDb);

               return new NoContentResult();
            }
        }
    }
}
