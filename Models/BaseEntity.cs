using System;

namespace CustomerApi.Models
{
    public abstract class BaseEntity
    {
        public long id { get; set; }  
        public DateTime createdAt { get; set; }  
        public DateTime updatedAt { get; set; }  
    }
}