﻿using ensektest.Models;

namespace ensektest.Responces
{
    public class MeterReadingResponse
    {
        public List<MeterReadingModel> SuccessReadings { get; set; } = new List<MeterReadingModel>();
        public int FailureReadings { get; set; }
    }
}
