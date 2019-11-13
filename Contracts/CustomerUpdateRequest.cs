using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Contracts
{
    public class CustomerUpdateRequest
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string otherNames { get; set; }

        public string phone { get; set; }

        [EmailAddress]
        public string email { get; set; }
    }
}