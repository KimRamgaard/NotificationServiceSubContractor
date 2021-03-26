using System;
using System.Collections.Generic;
using System.Text;

namespace AeldreplejeCore.Core.Entity
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public Group Group { get; set; }
        public string ProfilePicture { get; set; }
        public List<Shift> Shifts { get; set; }
        public List<UserPendingShift> PShifts { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }

    }
}
