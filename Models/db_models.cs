using System;

namespace Asp.Net_core_auth_task.Models
{
        public class Customer
    {
        public int Id { get; set; }
        public string Full_name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime Updated_at { get; set; } = DateTime.Now;
    }

    public class Auth
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

        public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime Updated_at { get; set; } = DateTime.Now;

    }
}