using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalRApi.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            return Ok(_mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll()));
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            Discount discount = new Discount()
            {
                Amount = createDiscountDto.Amount,
                description = createDiscountDto.description,
                ImageUrl = createDiscountDto.ImageUrl,
                Title = createDiscountDto.Title,

            };
            _discountService.TAdd(discount);
            return Ok("Ekleme Başarılı");
        }
        [HttpDelete]

        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("silme başarılı");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            Discount discount = new Discount()
            {
                DiscountID = updateDiscountDto.DiscountID,
                Amount = updateDiscountDto.Amount,
                description = updateDiscountDto.description,
                ImageUrl = updateDiscountDto.ImageUrl,
                Title = updateDiscountDto.Title,

            };
            _discountService.TUpdate(discount);
            return Ok("Güncelleme Başarılı");
        }
        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {

            return Ok(_discountService.TGetById(id));
        }

    }
}
