using CityGuide.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private DataContext _context;
        public WeatherForecastController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("getvalues")]
        public IActionResult GetValues()
        {
            var values = _context.Values.ToList();
            return Ok(values);
        }
        [HttpGet("getvalue")]
        public IActionResult GetValue(int id)
        {
            var values = _context.Values.SingleOrDefault(x=>x.Id==id);
            return Ok(values);
        }
    }
}
