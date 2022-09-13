using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tracking
{
    public class Location
    {
        [Key]
        public int Id { get; set; } 
        public double Latitude { get; set; }
        public double Longitude { get; set; }    
        public DateTime TimeStamp { get; set; }   
    }
}
