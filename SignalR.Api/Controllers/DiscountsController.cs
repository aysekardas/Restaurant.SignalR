using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        public DiscountsController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(new Discount()
            {
               Description = createDiscountDto.Description,
               Amount = createDiscountDto.Amount,
               ImageUrl = createDiscountDto.ImageUrl,
               Title = createDiscountDto.Title

            });

            return Ok("İndirim bilgisi eklendi");
        }

        [HttpDelete]

        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("İndirim bilgisi silindi");
        }

        [HttpGet("GetDiscount")]

        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]

        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new Discount()
            {
               Title = updateDiscountDto.Title,
               Amount = updateDiscountDto.Amount,
               ImageUrl = updateDiscountDto.ImageUrl,
               Description = updateDiscountDto.Description,
               DiscountID = updateDiscountDto.DiscountID
            });

            return Ok("İndirim bilgisi güncellendi");
        }
    }
}
