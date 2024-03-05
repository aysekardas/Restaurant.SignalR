using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {

        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]

        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new()
            {
                Date = createBookingDto.Date,
                Name = createBookingDto.Name,
                Mail = createBookingDto.Mail,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone

            };

            _bookingService.TAdd(booking);
            return Ok("Rezervasyon yapıldı");
        }

        [HttpDelete]

        public IActionResult DeleteBooking(int id)
        {
           // _bookingService.TDelete(_bookingService.TGetById(id));
          var value =  _bookingService.TGetById(id);
            _bookingService.TDelete(value);
                
            return Ok("Rezervasyon silindi");
        }


        [HttpPut]

        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new()
            {
                BookingID = updateBookingDto.BookingID,
                Date = updateBookingDto.Date,
                Name = updateBookingDto.Name,
                Mail = updateBookingDto.Mail,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone
            };

            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon güncellendi");
        }

        [HttpGet("GetBooking")]

        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }

    }
}
