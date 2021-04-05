using Microsoft.VisualStudio.TestTools.UnitTesting;
using AeldreplejeCore.Core.Entity;
using Dummy;
using System.Collections.Generic;
using System;

namespace TestNotificationService
{
    [TestClass]
    public class TimeOverlap
    {

        //The pending shift is has start and end time between start and end time of already established shift
        [TestMethod]
        public void ShiftOverlaps()
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
                    Group = new Group()
                    {
                        QualificationNumber = 1
                    },
                    Shifts = new List<Shift>
                    {
                        new Shift()
                        {
                            ActiveRoute = true,
                            ShiftQualificationNumber = 0,
                            Date = DateTime.Today,
                            TimeStart = new DateTime(2021, 1, 1, 10, 0, 0),
                            TimeEnd = new DateTime(2021, 1, 1, 18, 0, 0)
                        }
                    }
                }
            };

            //act
            NotificationService notificationService = new NotificationService();
            List<User> validUsers = notificationService.GetValidUsers(pendingShift, users, 10);

            //Assert
            Assert.IsTrue(validUsers.Count == 0);
        }


        //The pending shift but on different days
        [TestMethod]
        public void ShiftOnDifferentDay()
        {
            //arrange
            PendingShift pendingShift = new PendingShift()
            {
                Shift = new Shift()
                {
                    ActiveRoute = true,
                    ShiftQualificationNumber = 0,
                    Date = new DateTime(2022, 2, 2, 0, 0, 0),
                    TimeStart = new DateTime(2021, 1, 2, 12, 0, 0),
                    TimeEnd = new DateTime(2021, 1, 2, 13, 0, 0)

                }
            };

            List<User> users = new List<User>
            {
                new User()
                {
                    Group = new Group()
                    {
                        QualificationNumber = 0
                    },
                    Shifts = new List<Shift>
                    {
                        new Shift()
                        {
                            ActiveRoute = true,
                            ShiftQualificationNumber = 0,
                            Date = new DateTime(2021, 2, 1, 0, 0 ,0),
                            TimeStart = new DateTime(2021, 1, 1, 10, 0, 0),
                            TimeEnd = new DateTime(2021, 1, 1, 18, 0, 0)
                        }
                    }
                }
            };

            //act
            NotificationService notificationService = new NotificationService();
            List<User> validUsers = notificationService.GetValidUsers(pendingShift, users, 10);

            //Assert
            Assert.IsTrue(validUsers.Count == 1);
        }

        
        //the user is elligeble to get the new shift
        [TestMethod]
        public void SameDayDifferentTime()
        {
            //arrange
            PendingShift pendingShift = new PendingShift()
            {
                Shift = new Shift()
                {
                    ActiveRoute = true,
                    ShiftQualificationNumber = 0,
                    Date = new DateTime(2022, 2, 2, 0, 0, 0),
                    TimeStart = new DateTime(2021, 1, 2, 12, 0, 0),
                    TimeEnd = new DateTime(2021, 1, 2, 13, 0, 0)

                }
            };

            List<User> users = new List<User>
            {
                new User()
                {
                    Group = new Group()
                    {
                        QualificationNumber = 0
                    },
                    Shifts = new List<Shift>
                    {
                        new Shift()
                        {
                            ActiveRoute = true,
                            ShiftQualificationNumber = 0,
                            Date = new DateTime(2021, 2, 1, 0, 0 ,0),
                            TimeStart = new DateTime(2021, 1, 1, 14, 0, 0),
                            TimeEnd = new DateTime(2021, 1, 1, 18, 0, 0)
                        }
                    }
                }
            };

            //act
            NotificationService notificationService = new NotificationService();
            List<User> validUsers = notificationService.GetValidUsers(pendingShift, users, 10);

            //Assert
            Assert.IsTrue(validUsers.Count == 1);
        }

    }
}
