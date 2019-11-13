using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Contracts
{
    public class CustomerCreateRequest
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        public string otherNames { get; set; }

        [Required]
        public string phone { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }
    }
}