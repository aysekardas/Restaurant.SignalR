using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
                 Description = createProductDto.Description,
                 ImageUrl = createProductDto.ImageUrl,
                 Price = createProductDto.Price,
                 ProductName = createProductDto.ProductName,
                 ProductStatus = createProductDto.ProductStatus

            });

            return Ok("Ürün bilgisi eklendi");
        }

        [HttpDelete]

        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Ürün bilgisi silindi");
        }

        [HttpGet("GetProduct")]

        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]

        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product()
            {
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                Price = updateProductDto.Price,
                ProductName = updateProductDto.ProductName,
                ProductStatus = updateProductDto.ProductStatus,
                ProductID = updateProductDto.ProductID
                
            });

            return Ok("Ürün bilgisi güncellendi");
        }
    }
}
