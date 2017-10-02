using System;

namespace Nutrimeal.Models.API
{
    public class BaseResult
    {
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
        public bool HasError { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }
}