using Microsoft.VisualStudio.TestTools.UnitTesting;
using AeldreplejeCore.Core.Entity;
using Dummy;
using System.Collections.Generic;
using System;

namespace TestNotificationService
{
    [TestClass]
    public class Qualification
    {

        private DummyData testdata = new DummyData(); 


        [TestMethod]
        public void QualifiedUser()
        {
            //arrange
            List<User> users = new List<User>
            {
                testdata.userNormal // Has qualification Number 3
            };

            PendingShift pendingShift = testdata.pShift1; // Has Qualification Number 3

            //act
            NotificationService notificationService = new NotificationService();
            List<User> validUsers = notificationService.GetValidUsers(pendingShift, users, 10);

            //Assert
            Assert.IsTrue(validUsers.Count == 1);
        }


        [TestMethod]
        public void UnQualifiedUser()
        {
            //arrange
            List<User> users = new List<User>
            {
                testdata.userNormal // Has qualification Number 3
            };

            PendingShift pendingShift = testdata.pShift1; // Has Qualification Number 4
            pendingShift.Shift.ShiftQualificationNumber = 4;

            //act
            NotificationService notificationService = new NotificationService();
            List<User> validUsers = notificationService.GetValidUsers(pendingShift, users, 10);

            //Assert
            Assert.IsFalse(validUsers.Count == 1);
        }
        

    }
}
