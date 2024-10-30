using System;

namespace fitnessclass.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public DateTime RegistrationTime { get; set; }
        public bool IsCanceled { get; set; } // Tracks if registration was canceled
        public string CancellationReason { get; set; } 
    }
}
