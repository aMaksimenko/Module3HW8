using System;
using System.Globalization;
using HomeWork.Models;
using HomeWork.Models.Enums;
using HomeWork.Services.Abstractions;

namespace HomeWork.Services
{
    public class DataService : IDataService
    {
        public User StringToUser(string source)
        {
            var data = source.Split(';');

            return new User()
            {
                Id = int.Parse(data[0]),
                Name = data[1],
                Gender = Enum.Parse<Gender>(data[2]),
                Age = int.Parse(data[3])
            };
        }

        public Order StringToOrder(string source)
        {
            var data = source.Split(';');

            return new Order()
            {
                Id = int.Parse(data[0]),
                UserId = int.Parse(data[1]),
                Number = uint.Parse(data[2]),
                Date = DateTime.ParseExact(data[3], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Total = int.Parse(data[4]),
            };
        }

        public string ResultToString(Result source)
        {
            return new string($"{source.OrderNumber};{source.OrderDate};{source.UserName};{source.OrderTotal}");
        }
    }
}