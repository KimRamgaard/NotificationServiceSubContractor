﻿using AeldreplejeCore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Dummy
{
    class NotificationService : INotificationService
    {


        /**
         * The method must check all these requirements
         *  1. User qualification number >= shift qualification number
            2. User should not receive notification if they already have a Shift that overlaps with the newly created Shift.
            3. A user should not receive a notification if they already have X shifts or more in the same week as the new shift that was created.
            4. A user should not receive a notification if they are an admin.
         * We recommend splitting them up into smaller private methods
         */
        public List<User> GetValidUsers(PendingShift shift, List<User> allUsers, int x)
        {
            List<User> validUsers = new List<User>();
            
            foreach (User user in allUsers)
            {
                
                if( !IsUserQualified(shift, user))
                {
                    break;
                }

                if (IsUserAlreadyBooked(shift,user))
                {
                    break;
                }

                if (HasTooManyShifts(user, shift.Shift.Date, x))
                {
                    break;
                }

                if (user.IsAdmin)
                {
                    break;
                }


                validUsers.Add(user);
            }

            return validUsers;
   
        }


        // 1. User qualification number >= shift qualification number
        private bool IsUserQualified(PendingShift shift, User user)
        {
            int shiftQualityLevel = shift.Shift.ShiftQualificationNumber;
            int userQualityLevel = user.Group.QualificationNumber;

            if (shiftQualityLevel >= userQualityLevel)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        //2. User should not receive notification if they already have a Shift that overlaps with the newly created Shift.
        private bool IsUserAlreadyBooked(PendingShift pshift, User user)
        {
            //Is pending shifts, shifts in the future.
            //Is Shifts then always in the past?
            foreach (Shift usershift in user.Shifts)
            {
                if (pshift.Shift.Date == usershift.Date) 
                {
                    if(pshift.Shift.TimeStart > usershift.TimeStart &
                        pshift.Shift.TimeStart < usershift.TimeEnd)
                    {
                        return true;
                    }

                    if (pshift.Shift.TimeEnd > usershift.TimeStart &
                        pshift.Shift.TimeEnd < usershift.TimeEnd)
                    {
                        return true;
                    }
                }
                // Can you have shifts that spans over multiple days?
            }

            return false;
        }

        //3. A user should not receive a notification if they already have X shifts or more in the same week as the new shift that was created.
        private bool HasTooManyShifts(User user, DateTime newShiftDate, int MaxShifts)
        {
            CultureInfo culInf = CultureInfo.CurrentCulture;
            Calendar calendar = culInf.Calendar;
                
            //what are the rules for the week. ex. when does a week start?
            int newShiftWeekNo = calendar.GetWeekOfYear(newShiftDate, culInf.DateTimeFormat.CalendarWeekRule, culInf.DateTimeFormat.FirstDayOfWeek );

            int NoOfShiftsInWeek = 0;
            foreach (Shift shift in user.Shifts)
            {
                int currentShiftWeekNo = calendar.GetWeekOfYear(shift.Date, culInf.DateTimeFormat.CalendarWeekRule, culInf.DateTimeFormat.FirstDayOfWeek);
                if (newShiftWeekNo == currentShiftWeekNo)
                {
                    NoOfShiftsInWeek += 1;
                }
            }

            if (NoOfShiftsInWeek >= MaxShifts)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
