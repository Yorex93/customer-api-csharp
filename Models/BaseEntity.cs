using System;

namespace CustomerApi.Models
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }  
        public DateTime CreatedAt { get; set; }  
        public DateTime UpdatedAt { get; set; }  
    }
}