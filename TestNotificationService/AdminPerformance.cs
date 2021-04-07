using Microsoft.VisualStudio.TestTools.UnitTesting;
using AeldreplejeCore.Core.Entity;
using Dummy;
using System.Collections.Generic;
using System;

namespace TestNotificationService
{

    //Handle 
    [TestClass]
    public class AdminPerformance
    {

        //The pending shift is has start and end time between start and end time of already established shift
        [TestMethod]
        public void isAdmin()
        {
            //arrange
            PendingShift pendingShift = new PendingShift()
            {
                Shift = new Shift()
                {
                    ActiveRoute = true,
                    ShiftQualificationNumber = 0,
                    Date = DateTime.Today,
                    TimeStart = new DateTime(2021, 1, 2, 12, 0, 0),
                    TimeEnd = new DateTime(2021, 1, 2, 13, 0, 0)

                }
            };

            List<User> users = new List<User>
            {
                new User()
                {
                    IsAdmin = true
                }
            };

            //act
            NotificationService notificationService = new NotificationService();
            List<User> validUsers = notificationService.GetValidUsers(pendingShift, users, 10);

            //Assert
            Assert.IsTrue(validUsers.Count == 0);
        }
    }
}
