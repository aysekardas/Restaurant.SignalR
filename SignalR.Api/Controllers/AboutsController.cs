using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {

        // ToDo:UI'da dtos klasörü aç
   
        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]

        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]


        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new()
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                İmageUrl = createAboutDto.İmageUrl

            };
        
           _aboutService.TAdd(about);
            return Ok("Hakkımda bilgisi başarıyla eklendi");

        }

        [HttpDelete]

        public async Task<IActionResult> DeleteAbout(int id)
        {
            var values =  _aboutService.TGetById(id);
            _aboutService.TDelete(values);
            return Ok("Hakkımda bilgisi başarıyla silindi");
        
        }

        [HttpPut]

        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new()
            {
                AboutID = updateAboutDto.AboutID,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                İmageUrl = updateAboutDto.İmageUrl

            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımda alanı güncellendi");
        }

        [HttpGet("GetAbout")]

        public IActionResult GetAbout(int id)
        {
           var value = _aboutService.TGetById(id);
            return Ok(value);
        
        }
    }
}
