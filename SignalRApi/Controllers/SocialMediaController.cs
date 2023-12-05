using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult SocialMediaList()
        {
            return Ok(_mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll()));
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto socialMediaDto)
        {
            SocialMedia socialMedia = new SocialMedia()
            {
                Icon = socialMediaDto.Icon,
                Title= socialMediaDto.Title,
                Url= socialMediaDto.Url,          
            };
            _socialMediaService.TAdd(socialMedia);
            return Ok("Ekleme Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(value);
            return Ok("Sİlme Başarılı");
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            SocialMedia socialMedia = new SocialMedia()
            {
                Icon = updateSocialMediaDto.Icon,
                Title = updateSocialMediaDto.Title,
                Url = updateSocialMediaDto.Url,
                SocialMediaID = updateSocialMediaDto.SocialMediaID,
            };
            _socialMediaService.TUpdate(socialMedia);
            return Ok("GÜncelleme Başarılı");
        }
        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            return Ok(_socialMediaService.TGetById(id));
        }
    }
}
