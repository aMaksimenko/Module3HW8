using System;

namespace HomeWork.Models
{
    public class Result
    {
        public uint OrderNumber { get; init; }
        public DateTime OrderDate { get; init; }
        public string UserName { get; init; }
        public int OrderTotal { get; set; }
    }
}