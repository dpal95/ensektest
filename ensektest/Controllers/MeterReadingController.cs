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

        [HttpPost(Name = "meter-reading-uploads")]
        public MeterReadingResponse MeterReadingUploads()
        {
           var response = _meterReadingService.ReadCsvFile(@"C:\\Users\\dpalu\\Downloads\\ENSEK Remote Technical Task Brief\\Meter_Reading.csv");

            foreach (var item in response.SuccessReadings)
            {
                _meterReadingService.SaveMeterReading(item);
            }

          return response;
        }
    }
}
