using System.ComponentModel.DataAnnotations;

namespace BP_API.Models
{
    public enum Condition 
    {
        Low = 0,
        Normal = 1,
        High = 3
    }
    public class Measurement
    {
        [Key]
        public DateOnly Date {get; set;}

        public int Systolic {get; set;}
        public int Diastolic {get; set;}

        public Condition Diagnosis {get; set;}
        
    }
}