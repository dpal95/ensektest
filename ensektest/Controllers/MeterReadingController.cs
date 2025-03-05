using ensektest.Models;
using ensektest.Responces;
using ensektest.Services;
using Microsoft.AspNetCore.Mvc;

namespace ensektest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeterReadingController : ControllerBase
    {       
        private readonly ILogger<MeterReadingController> _logger;
        private readonly IMeterReadingService _meterReadingService;
        public MeterReadingController(ILogger<MeterReadingController> logger, IMeterReadingService meterReadingService)
        {
            _logger = logger;
            _meterReadingService = meterReadingService;
        }

        [HttpPost("meter-reading-uploads")]
        public IActionResult MeterReadingUploads()
        {
           var csvResponse = _meterReadingService.ReadCsvFile(@"C:\\Users\\dpalu\\Downloads\\ENSEK Remote Technical Task Brief\\Meter_Reading.csv");
            
            var saveResponse = _meterReadingService.SaveMeterReading(csvResponse);

          return Ok(saveResponse);
        }

        [HttpPost("seed")]
        public IActionResult SeedDb()
        {
            var response = _meterReadingService.ReadAccountCsvFile(@"C:\\Users\\dpalu\\Downloads\\ENSEK Remote Technical Task Brief\\Test_Accounts.csv");
            return Ok();
        }
    }
}
