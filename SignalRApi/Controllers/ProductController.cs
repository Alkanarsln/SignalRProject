using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalRApi.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult ProductList()
        {
            return Ok(_mapper.Map<List<ResultProductDto>>(_productService.TGetListAll()));
        }
        [HttpGet("ProductListWithCategory")]
        public ActionResult ProductListWithCategory() 
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                Description= y.Description,
                ImageUrl= y.ImageUrl,
                Price= y.Price,
                ProductID= y.ProductID,
                ProductName= y.ProductName,
                ProductStatus= y.ProductStatus,
                CategoryName = y.Category.CategoryName
            });
            return Ok(values.ToList());
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            Product product = new Product()
            {
                Description= createProductDto.Description,
                ImageUrl= createProductDto.ImageUrl,
                ProductStatus= createProductDto.ProductStatus,
                Price= createProductDto.Price,
                ProductName= createProductDto.ProductName,
            };
            _productService.TAdd(product);
            return Ok("Ürün Başarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Ürün başarılı bir şeklide silindi");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto) 
        {
            Product product = new Product()
            {
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                ProductStatus = updateProductDto.ProductStatus,
                Price = updateProductDto.Price,
                ProductName = updateProductDto.ProductName,
                ProductID = updateProductDto.ProductID,
            };
            _productService.TUpdate(product);
            return Ok("Ürün başarılı bir şekilde güncellendi");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            return Ok(_productService.TGetById(id));
        }
    }
}
