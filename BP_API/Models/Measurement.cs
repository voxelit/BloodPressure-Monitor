using System.ComponentModel.DataAnnotations;

namespace BP_API.Models
{
    public enum Condition 
    {
        Low,
        Normal,
        High
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