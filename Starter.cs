using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork.Models;
using HomeWork.Services;

namespace HomeWork
{
    public class Starter
    {
        public async Task Run()
        {
            var fileService = new FileService();
            var dataService = new DataService();
            var usersString = await fileService.ReadAsync("users.txt");
            var ordersString = await fileService.ReadAsync("orders.txt");
            var users = new List<User>();
            var orders = new List<Order>();

            foreach (var item in usersString)
            {
                users.Add(dataService.StringToUser(item));
            }

            foreach (var item in ordersString)
            {
                orders.Add(dataService.StringToOrder(item));
            }

            var results = Filter(orders, users);

            await fileService.WriteAsync(
                "result.txt",
                results.Select(res => $"{res.OrderNumber};{res.OrderDate.ToString("yyyy-MM-dd")};{res.UserName};{res.OrderTotal};"));
        }

        public IEnumerable<Result> Filter(IEnumerable<Order> orders, IEnumerable<User> users)
        {
            var weekAgoDate = DateTime.Today.AddDays(-7);

            return orders
                .Where(order => order.Date > weekAgoDate)
                .OrderBy(order => order.Date)
                .Join(
                    users.Where(user => user.Age > 18 && user.Age < 65),
                    order => order.UserId,
                    user => user.Id,
                    (order, user) => new Result()
                    {
                        OrderNumber = order.Number,
                        OrderDate = order.Date,
                        OrderTotal = order.Total,
                        UserName = user.Name
                    });
        }
    }
}