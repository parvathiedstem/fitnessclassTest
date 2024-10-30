using System;
using System.Collections.Generic;

namespace fitnessclass.Models
{
    public class FitnessClass
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string Instructor { get; set; }
        public DateTime DateTime { get; set; }
        public int Capacity { get; set; }
        public int AvailableSpots { get; set; }
        public string RoomNumber { get; set; }
    }
}
