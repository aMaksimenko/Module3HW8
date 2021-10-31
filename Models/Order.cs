using System;

namespace HomeWork.Models
{
    public class Order
    {
        public int Id { get; init; }
        public int UserId { get; init; }
        public uint Number { get; init; }
        public DateTime Date { get; init; }
        public int Total { get; set; }
    }
}