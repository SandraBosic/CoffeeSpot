using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeSpot.Data.Entities
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public String Comment { get; set; }
        public int Grade { get; set; }
    }
}
