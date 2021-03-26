using System.Collections.Generic;
using AeldreplejeCore.Core.Entity;

namespace Dummy
{
    public interface INotificationService
    {
        /**
         * The method must check all these requirements
         *  1. User qualification number >= shift qualification number
            2. User should not receive notification if they already have a Shift that overlaps with the newly created Shift.
            3. A user should not receive a notification if they already have X shifts or more in the same week as the new shift that was created.
            4. A user should not receive a notification if they are an admin.
         * We recommend splitting them up into smaller private methods
         */
        List<User> GetValidUsers(PendingShift shift, List<User> allUsers, int x);
    }
}