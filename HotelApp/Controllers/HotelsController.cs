using HotelsApi.Models;
using HotelsApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ListingsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelService _hotelService;

        public HotelsController(HotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public ActionResult<List<Hotel>> Get() =>
            _hotelService.Get();

        [HttpGet("{id:length(24)}", Name = "GetHotel")]
        public ActionResult<Hotel> Get(string id)
        {
            var hotel = _hotelService.Get(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        [HttpPost]
        public ActionResult<Hotel> Create(Hotel hotel)
        {
            _hotelService.Create(hotel);

            return CreatedAtRoute("GetHotel", new { id = hotel.Id.ToString() }, hotel);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Hotel hotelIn)
        {
            var hotel = _hotelService.Get(id);

            if (hotel == null)
            {
                return NotFound();
            }

            _hotelService.Update(id, hotelIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var hotel = _hotelService.Get(id);

            if (hotel == null)
            {
                return NotFound();
            }

            _hotelService.Remove(hotel.Id);

            return NoContent();
        }
    }
}