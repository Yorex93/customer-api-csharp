using System;

namespace CustomerApi.Models
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherNames { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}