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
        public MeterReadingResponse MeterReadingUploads()
        {
           var response = _meterReadingService.ReadCsvFile(@"C:\\Users\\dpalu\\Downloads\\ENSEK Remote Technical Task Brief\\Meter_Reading.csv");
            MeterReadingResponse responseResponse = new MeterReadingResponse() { FailureReadings = response.FailureReadings};
            foreach (var item in response.SuccessReadings)
            {
                if(_meterReadingService.SaveMeterReading(item))
                {
                    responseResponse.SuccessReadings++;
                    continue;
                }
                responseResponse.FailureReadings++;
            }

          return responseResponse;
        }

        [HttpPost("seed")]
        public MeterReadingResponse SeedDb()
        {
            var response = _meterReadingService.ReadAccountCsvFile(@"C:\\Users\\dpalu\\Downloads\\ENSEK Remote Technical Task Brief\\Test_Accounts.csv");
            return new MeterReadingResponse();
        }
    }
}
