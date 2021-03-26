using System;
using System.Collections.Generic;
using AeldreplejeCore.Core.Entity;

namespace Dummy
{
    public class DummyData
    {

        string password = "password";
        byte[] passwordHashUserOne, passwordSaltUserOne, passwordHashUserTwo, passwordSaltUserTwo;
        private User userNormal2;
        private User userNormal;
        private User userNormal3;
        private User userAdmin;
        private PendingShift pShift1;

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public DummyData()
        {

            CreatePasswordHash(password, out passwordHashUserOne, out passwordSaltUserOne);
            CreatePasswordHash(password, out passwordHashUserTwo, out passwordSaltUserTwo);


            var SSA = new Group()
            {
                Type = "SSA",
                QualificationNumber = 3,
            };
            var SSH = new Group()
            {
                Type = "SSH",
                QualificationNumber = 2
            };
            var UDD = new Group()
            {
                Type = "UDD",
                QualificationNumber = 1
            };

            userNormal = new User()
            {
                IsAdmin = false,
                Name = "Christian",
                PasswordSalt = passwordSaltUserOne,
                PasswordHash = passwordHashUserOne,
                Email = "christiansEmail@email.com",
                Group = SSA,
                ProfilePicture = "https://scontent-ams4-1.xx.fbcdn.net/v/t1.0-9/68397042_2373050946108579_1355476049231609856_n.jpg?_nc_cat=111&_nc_ohc=L-VxFCgmIOEAQkExKADS7GkFanYn-wlS1DtritGMIDMaz-F2F47jDBqdg&_nc_ht=scontent-ams4-1.xx&oh=d64bb5c81845f4af32142583c4d47f87&oe=5E89A221"
            };
            userNormal2 = new User()
            {
                IsAdmin = false,
                Name = "Richart",
                Email = "richart@email.com",
                ProfilePicture = "https://scontent-ams4-1.xx.fbcdn.net/v/t1.0-9/13906839_10206396239896911_6785032534256698008_n.jpg?_nc_cat=100&_nc_ohc=NWUTbJTLB7oAQkf5171xXvT0S_v4pdlAB1wHR_kbXfXiZXd0kzXCiLjuA&_nc_ht=scontent-ams4-1.xx&oh=d38d30e968f89eff9eb1fe39ee3287c3&oe=5E68167D",
                PasswordSalt = passwordSaltUserOne,
                PasswordHash = passwordHashUserOne,
                Group = UDD
            };
            userNormal3 = new User()
            {
                IsAdmin = false,
                Name = "Casper",
                Email = "casper@email.com",
                ProfilePicture = "https://scontent-ams4-1.xx.fbcdn.net/v/t1.0-9/12524001_1549641258661056_8462488784370177517_n.png?_nc_cat=109&_nc_ohc=_uulefV7bhEAQmqusa2XXfvuZdh72xF92JjafAdGC2NjGXJZ0RGgy2z2w&_nc_ht=scontent-ams4-1.xx&oh=1c4928765d11ea4940a2a00321425a65&oe=5E6815A3"
                ,
                PasswordSalt = passwordSaltUserOne,
                PasswordHash = passwordHashUserOne,
                Group = SSA
            };

            userAdmin = new User()
            {
                IsAdmin = true,
                Name = "Simon",
                Email = "simon@email.com",
                ProfilePicture = "https://imgix.bustle.com/elite-daily/2017/07/28103007/joffrey-game-of-thrones-choking.jpg?w=1020&h=574&fit=crop&crop=faces&auto=format&q=70",
                PasswordSalt = passwordSaltUserTwo,
                PasswordHash = passwordHashUserTwo,
                Group = SSH
            };

            var route1 = new Route()
            {
                Name = "MA01",

            };
            var route2 = new Route()
            {
                Name = "MA02",

            };




            var ar = new ActiveRoute()
            {
                Name = "MA01"
            };
            var ar2 = new ActiveRoute()
            {
                Name = "MA02"
            };
            var ar3 = new ActiveRoute()
            {
                Name = "MA03"
            };
            var ar4 = new ActiveRoute()
            {
                Name = "MA10"
            };

            var ts = new TimeStart()
            {
                timeStart = "15:00"
            };
            var ts2 = new TimeStart()
            {
                timeStart = "15:30"
            };
            var ts3 = new TimeStart()
            {
                timeStart = "16:00"
            };
            var ts4 = new TimeStart()
            {
                timeStart = "16:30"
            };

            var te = new TimeEnd()
            {
                timeEnd = "23:00"
            };

            

            var shift = new Shift()
            {
                ActiveRoute = true,
                ShiftQualificationNumber = 3,
                TimeStart = new DateTime(2021, 1, 1, 10, 0, 0),
                TimeEnd = new DateTime(2021, 1, 1, 18, 0, 0)

            };
            var shift2 = new Shift()
            {
                ActiveRoute = true,
                ShiftQualificationNumber = 2,
                TimeStart = new DateTime(2021, 1, 2, 10, 0, 0),
                TimeEnd = new DateTime(2021, 1, 2, 18, 0, 0)

            };
            var shift3 = new Shift()
            {
                ActiveRoute = true,
                ShiftQualificationNumber = 1,
                TimeStart = new DateTime(2021, 1, 3, 10, 0, 0),
                TimeEnd = new DateTime(2021, 1, 3, 18, 0, 0)
            };

            pShift1 = new PendingShift()
            {
                Shift = shift
            };

            userNormal.Shifts = new List<Shift> {shift2, shift3};
        }

        public List<User> GetAllUser()
        {
            return new List<User> { userAdmin, userNormal, userNormal2, userNormal3 };
        }

        public List<PendingShift> GetAllPendingShifts()
        {
            return new List<PendingShift> {pShift1};
        }
    }
}