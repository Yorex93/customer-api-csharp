using System;

namespace CustomerApi.Models
{
    public class Customer : BaseEntity
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string otherNames { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public bool isActive { get; set; }
    }
}