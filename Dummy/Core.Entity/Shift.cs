using System;
using System.Data;

namespace AeldreplejeCore.Core.Entity
{
    public class Shift
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public Route Route { get; set; }
        public int? RouteId { get; set; }
        public bool ActiveRoute { get; set; }
        public User User { get; set; }
        public PendingShift PShift { get; set; }
        
        public int ShiftQualificationNumber { get; set; }
    }
}