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

namespace SNOW.SHOP.API.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private IProductRepository _productRepository;
        int page = 1;
        int pageSize = 4;

        public ProductController(IProductRepository repository, IMapper mapper)
        {
            _productRepository = repository;
            _mapper = mapper;
        }

       

        // GET Production/Product
        /// <summary>
        /// Retrieves a list of Products
        /// </summary>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="name">Name</param>
        /// <returns>List response</returns>
       // [HttpGet]
      //  [Route("Products")]
        public IActionResult Get()
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
            var totalProducts = _productRepository.Count();
            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);


            IEnumerable<Product> _products = _productRepository
               .AllIncluding(s => s.CompanyId, s => s.Company)
               .OrderBy(s => s.Id)
               .Skip((currentPage - 1) * currentPageSize)
               .Take(currentPageSize)
               .ToList();

            Response.AddPagination(page, pageSize, totalProducts, totalPages);

            var response = new ListModelResponse<ProductViewModel>() as IListModelResponse<ProductViewModel>;

            IEnumerable<ProductViewModel> _productsVM = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(_products);

            return new OkObjectResult(_productsVM);
        }

        // GET Production/Product/5
        /// <summary>
        /// Retrieves a specific Product by id
        /// </summary>
        /// <param name="id">ProductID</param>
        /// <returns>Single response</returns>
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            Product _product = await _productRepository
                 .GetSingleAsync(id);

            if (_product != null)
            {
                ProductViewModel _productVM = Mapper.Map<Product, ProductViewModel>(_product);
                return new OkObjectResult(_productVM);
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
        
        private async Task<IActionResult> Create([FromBody]ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product _newProduct = Mapper.Map<ProductViewModel, Product>(product);
            _newProduct.CreatedDate = DateTime.Now;

           await _productRepository.AddAsync(_newProduct);

            // foreach (var userId in product.)
            //      {
            //         _newSchedule.Attendees.Add(new Attendee { UserId = userId });
            //     }
            //     _scheduleRepository.Commit();

            product = Mapper.Map<Product, ProductViewModel>(_newProduct);

            CreatedAtRouteResult result = CreatedAtRoute("GetProduct", new { controller = "Product", id = product.ID }, product);
            return result;
        }

        // PUT Production/Product/5
        /// <summary>
        /// Updates an existing Product
        /// </summary>
        /// <param name="value">Product entry</param>
        /// <returns>Single response</returns>
        [HttpPut]
        [Route("Product"), Obsolete]
        private async Task<IActionResult> Put([FromBody]ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product _productDb = await _productRepository.GetSingleAsync(product.ID);

            if (_productDb == null)
            {
                return NotFound();
            }
            else
            {
                _productDb.Name = product.Name;
                _productDb.Description = product.Description;
                _productDb.StockPrice = product.StockPrice;
                _productDb.MarketPrice = product.MarketPrice;




               await _productRepository.CommitAsync();
            }

            product = Mapper.Map<Product, ProductViewModel>(_productDb);

            return new NoContentResult();
        }

        // DELETE Production/Product/5
        /// <summary>
        /// Delete an existing Product
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Single response</returns>
        [HttpDelete("{id}", Name = "RemoveProduct")]
        private async Task<IActionResult> Delete(int id)
        {
            Product _productDb = await _productRepository.GetSingleAsync(id);

            if (_productDb == null)
            {
                return new NotFoundResult();
            }
            else
            {

               await _productRepository.DeleteAsync(_productDb);

               return new NoContentResult();
            }
        }
    }
}
