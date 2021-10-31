using HomeWork.Models.Enums;

namespace HomeWork.Models
{
    public class User
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public Gender Gender { get; init; }
        public int Age { get; set; }
    }
}