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
        private readonly string meterRoute = @"\\Meter_Reading.csv";
        private readonly string accountRoute = @"\\Test_Accounts.csv";

        public MeterReadingController(ILogger<MeterReadingController> logger, IMeterReadingService meterReadingService)
        {
            _logger = logger;
            _meterReadingService = meterReadingService;
        }

        [HttpPost("meter-reading-uploads")]
        public IActionResult MeterReadingUploads()
        {
           var csvResponse = _meterReadingService.ReadCsvFile(meterRoute);
            
            var saveResponse = _meterReadingService.SaveMeterReading(csvResponse);

          return Ok(saveResponse);
        }

        [HttpPost("seed")]
        public IActionResult SeedDb()
        {
            var response = _meterReadingService.ReadAccountCsvFile(accountRoute);
            return Ok();
        }
    }
}
