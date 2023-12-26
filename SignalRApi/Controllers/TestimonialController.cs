using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult TestimonialList()
        {
            return Ok(_mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll()));
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            Testimonial testimonial = new Testimonial()
            {
                Status = createTestimonialDto.Status,
                Comment = createTestimonialDto.Comment,
                ImageUrl = createTestimonialDto.ImageUrl,
                Name = createTestimonialDto.Name,
                Title = createTestimonialDto.Title,
            };
            _testimonialService.TAdd(testimonial);
            return Ok("Ekleme Başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Sİlme Başarılı");
        }
		[HttpGet("{id}")]
		public IActionResult GetTestimonial(int id)
		{
			return Ok(_testimonialService.TGetById(id));
		}
		[HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            Testimonial testimonial = new Testimonial()
            {
                Status = updateTestimonialDto.Status,
                Comment = updateTestimonialDto.Comment,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Name = updateTestimonialDto.Name,
                Title = updateTestimonialDto.Title,
                TestimonialID = updateTestimonialDto.TestimonialID,
            };
            _testimonialService.TUpdate(testimonial);
            return Ok("GÜncelleme Başarılı");
        }
       
    }
}
