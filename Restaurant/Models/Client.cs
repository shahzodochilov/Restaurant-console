using Restaurant.Enums;

namespace Restaurant.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; }
    }
}
