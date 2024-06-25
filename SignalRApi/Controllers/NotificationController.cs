using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetListAll());
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }
        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()

        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }
        [HttpPost]
        public IActionResult CreateNotificiation(CreateNotificationDto createNotificationDto)
        {
            Notification notification = new Notification()
            {
                Type = createNotificationDto.Type,
                Icon = createNotificationDto.Icon,
                Description = createNotificationDto.Description,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Status = false,
            };
            _notificationService.TAdd(notification);
            return Ok("Ekleme işlemi başarıyla tamamlandı.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Silme işlemi başarıyla tamamlandı.");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            Notification notification = new Notification()
            {
                NotificationID= updateNotificationDto.NotificationID,
                Type = updateNotificationDto.Type,
                Icon = updateNotificationDto.Icon,
                Description = updateNotificationDto.Description,
                Date = updateNotificationDto.Date,
                Status = updateNotificationDto.Status
            };
            _notificationService.TUpdate(notification);
            return Ok("Güncelleme işlemi başarıyla tamamlandı.");
        }
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id) 
        {
            var value = _notificationService.TGetById(id);
            return Ok(value); 
        }

        [HttpGet("NotificationChangeToFalse/{id}")]

        public IActionResult NotificationChangeToFalse(int id)
        {
            _notificationService.TNotificationChangeToFalse(id);
            return Ok("Güncelleme Yapuldı");
        }
        [HttpGet("NotificationChangeToTrue/{id}")]
        public IActionResult NotificationChangeToTrue(int id)
        {
            _notificationService.TNotificationChangeToTrue(id);
            return Ok("Güncelleme Yapuldı");
        }

    }
}
