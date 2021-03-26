namespace AeldreplejeCore.Core.Entity
{
    public class UserPendingShift
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public int PendingShiftId { get; set; }
        public PendingShift PendingShift { get; set; }
    }
}