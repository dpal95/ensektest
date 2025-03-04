using ensektest.Models;
using ensektest.Responces;
using Microsoft.AspNetCore.Mvc;

namespace ensektest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeterReadingController : ControllerBase
    {       
        private readonly ILogger<MeterReadingController> _logger;

        public MeterReadingController(ILogger<MeterReadingController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "meter-reading-uploads")]
        public MeterReadingResponse MeterReadingUploads()
        {
          return new MeterReadingResponse();
        }
    }
}
