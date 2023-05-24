using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace Merck.DTOS
{
    public class StatsDTO
    {
        public int NoOfTransmission { get; set; }
        public string DeviceType { get; set; }
        public int Distribution { get; set; }
        public int OverallAttacks { get; set; }
        public int TransmissionError { get; set;}
        public int DeviceId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }

    public class BarChartStats
    {
        public string Type { get; set; }
        public bool ShowInLegend { get; set; }
        public string MarkerType { get; set; }
        public string Name { get; set; }
        public List<ChartCoordinates> DataPoints { get; set; }
    }
    public class BarChartDataPoints
    {
        public int NoOfTransmission { get; set; }
        public int Distribution { get; set; }
        public int OverallAttacks { get; set; }
        public int TransmissionError { get; set; }
    }
    public class ChartCoordinates
    {
        public string X { get; set; }
        public int Y { get; set; }
    }
}