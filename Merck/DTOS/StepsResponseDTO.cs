using System;

namespace Merck.DTOS
{
    public class StepsResponseDTO
    {
        public string StepName { get;set; }
        public DateTime StepCompletedDate { get;set; }
        public string CompletedBy { get;set; }
        public string ManfName { get; set; }
    }
}
