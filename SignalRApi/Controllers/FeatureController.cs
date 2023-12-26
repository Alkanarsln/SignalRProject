using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalRApi.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;
        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatueList()
        {
            return Ok(_mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll()));
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            Feature feature = new Feature()
            {
                Title1 = createFeatureDto.Title1,
                Title2 = createFeatureDto.Title2,
                Title3 = createFeatureDto.Title3,
                Description1 = createFeatureDto.Description1,
                Description2 = createFeatureDto.Description2,
                Description3 = createFeatureDto.Description3,
                 

            };
            _featureService.TAdd(feature);
            return Ok("Ekleme Başarılı");
        }
        [HttpDelete("{id}")]

        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            _featureService.TDelete(value);
            return Ok("silme başarılı");
        }
		[HttpGet("{id}")]
		public IActionResult GetFeature(int id)
		{

			return Ok(_featureService.TGetById(id));
		}
		[HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {

            Feature feature = new Feature()
            {
                Title1 = updateFeatureDto.Title1,
                Title2 = updateFeatureDto.Title2,
                Title3 = updateFeatureDto.Title3,
                Description1 = updateFeatureDto.Description1,
                Description2 = updateFeatureDto.Description2,
                Description3 = updateFeatureDto.Description3,
                FeatureID = updateFeatureDto.FeatureID,


            };
            _featureService.TUpdate(feature);
            return Ok("Güncelleme Başarılı");
        }
    }
}
