using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace API.Entities
{
    public class LatestEvents
    {
        [JsonIgnore]
        public string PublicId { get; set; }
        public string Title { get; set; }
        public string EventDate { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }

    }
}