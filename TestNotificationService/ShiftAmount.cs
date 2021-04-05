using Microsoft.VisualStudio.TestTools.UnitTesting;
using AeldreplejeCore.Core.Entity;
using Dummy;
using System.Collections.Generic;
using System;

namespace TestNotificationService
{
    [TestClass]
    public class ShiftAmount
    {
        [TestMethod]
        public void TooManyShifts()
        {

            //shift to cover
            PendingShift pendingShift = new PendingShift()
            {
                Shift = new Shift()
                {
                    ActiveRoute = true,
                    ShiftQualificationNumber = 0,
                    Date = new DateTime(2021, 4, 7, 0, 0, 0), /**/
                    TimeStart = new DateTime(2021, 1, 2, 12, 0, 0),
                    TimeEnd = new DateTime(2021, 1, 2, 13, 0, 0)

                }
            };

            //user to assign to
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
                            Date = new DateTime(2021, 4, 5, 0, 0, 0), /**/
                            TimeStart = new DateTime(2021, 6, 5, 10, 0, 0),
                            TimeEnd = new DateTime(2021, 1, 1, 18, 0, 0)
                        },
                        new Shift()
                        {
                            ActiveRoute = true,
                            ShiftQualificationNumber = 0,
                            Date = new DateTime(2021, 4, 6, 0, 0, 0), /**/
                            TimeStart = new DateTime(2021, 1, 1, 10, 0, 0),
                            TimeEnd = new DateTime(2021, 1, 1, 18, 0, 0)
                        }
                    }
                }
            };
            /*all same week*/

            //act
            NotificationService notificationService = new NotificationService();
            List<User> validUsers = notificationService.GetValidUsers(pendingShift, users, 2);

            //Assert
            Assert.IsTrue(validUsers.Count == 0);

        }

        [TestMethod]
        public void SpaceForOneShift()
        {

            //shift to cover
            PendingShift pendingShift = new PendingShift()
            {
                Shift = new Shift()
                {
                    ActiveRoute = true,
                    ShiftQualificationNumber = 0,
                    Date = new DateTime(2021, 4, 7, 0, 0, 0),
                    TimeStart = new DateTime(2021, 1, 2, 12, 0, 0),
                    TimeEnd = new DateTime(2021, 1, 2, 13, 0, 0)

                }
            };

            //user to assign to
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
                            Date = new DateTime(2021, 4, 5, 0, 0, 0),
                            TimeStart = new DateTime(2021, 6, 5, 10, 0, 0),
                            TimeEnd = new DateTime(2021, 1, 1, 18, 0, 0)
                        },
                        new Shift()
                        {
                            ActiveRoute = true,
                            ShiftQualificationNumber = 0,
                            Date = new DateTime(2021, 4, 6, 0, 0, 0),
                            TimeStart = new DateTime(2021, 1, 1, 10, 0, 0),
                            TimeEnd = new DateTime(2021, 1, 1, 18, 0, 0)
                        }
                    }
                }
            };

            //act
            NotificationService notificationService = new NotificationService();
            List<User> validUsers = notificationService.GetValidUsers(pendingShift, users, 3);

            //Assert
            Assert.IsTrue(validUsers.Count == 1);
        }


        [TestMethod]
        public void multipleShiftsMultipleWeeks()
        {

            //shift to cover
            PendingShift pendingShift = new PendingShift()
            {
                Shift = new Shift()
                {
                    ActiveRoute = true,
                    ShiftQualificationNumber = 0,
                    Date = new DateTime(2021, 4, 7, 0, 0, 0),
                    TimeStart = new DateTime(2021, 1, 2, 12, 0, 0),
                    TimeEnd = new DateTime(2021, 1, 2, 13, 0, 0)

                }
            };

            //user to assign to
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
                            Date = new DateTime(2021, 4, 5, 0, 0, 0),
                            TimeStart = new DateTime(2021, 6, 5, 10, 0, 0),
                            TimeEnd = new DateTime(2021, 1, 1, 18, 0, 0)
                        },
                        new Shift()
                        {
                            ActiveRoute = true,
                            ShiftQualificationNumber = 0,
                            Date = new DateTime(2021, 4, 6, 0, 0, 0),
                            TimeStart = new DateTime(2021, 1, 1, 10, 0, 0),
                            TimeEnd = new DateTime(2021, 1, 1, 18, 0, 0)
                        },
                        //one the week after
                        new Shift()
                        {
                            ActiveRoute = true,
                            ShiftQualificationNumber = 0,
                            Date = new DateTime(2021, 4, 12, 0, 0, 0),
                            TimeStart = new DateTime(2021, 6, 5, 10, 0, 0),
                            TimeEnd = new DateTime(2021, 1, 1, 18, 0, 0)
                        },
                        //one the week before
                        new Shift()
                        {
                            ActiveRoute = true,
                            ShiftQualificationNumber = 0,
                            Date = new DateTime(2021, 4, 4, 0, 0, 0),
                            TimeStart = new DateTime(2021, 1, 1, 10, 0, 0),
                            TimeEnd = new DateTime(2021, 1, 1, 18, 0, 0)
                        }
                    }
                }
            };

            //act
            NotificationService notificationService = new NotificationService();
            List<User> validUsers = notificationService.GetValidUsers(pendingShift, users, 3);

            //Assert
            Assert.IsTrue(validUsers.Count == 1);
        }


        [TestMethod]
        public void sameWeekDifferentYear()
        {

            //shift to cover
            PendingShift pendingShift = new PendingShift()
            {
                Shift = new Shift()
                {
                    ActiveRoute = true,
                    ShiftQualificationNumber = 0,
                    Date = new DateTime(2021, 1, 5, 0, 0, 0),
                    TimeStart = new DateTime(2021, 1, 2, 9, 0, 0),
                    TimeEnd = new DateTime(2021, 1, 2, 9, 30, 0)

                }
            };

            //user to assign to
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
                            Date = new DateTime(2021, 1, 5, 0, 0, 0),
                            TimeStart = new DateTime(2021, 6, 5, 10, 0, 0),
                            TimeEnd = new DateTime(2021, 1, 1, 18, 0, 0)
                        },
                        new Shift()
                        {
                            ActiveRoute = true,
                            ShiftQualificationNumber = 0,
                            Date = new DateTime(2020, 1, 5, 0, 0, 0), //Different year, should not count
                            TimeStart = new DateTime(2021, 1, 1, 10, 0, 0),
                            TimeEnd = new DateTime(2021, 1, 1, 18, 0, 0)
                        }
                    }
                }
            };

            //act
            NotificationService notificationService = new NotificationService();
            List<User> validUsers = notificationService.GetValidUsers(pendingShift, users, 2);

            //Assert
            Assert.IsTrue(validUsers.Count == 1);
        }
    }
}
