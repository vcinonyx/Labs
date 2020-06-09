using System;
using System.Collections;
using System.Collections.Generic;


namespace DoctorAppointment
{
    public class Appointments   
    {
        private List<AppointmentDay> AppointmentDays;

        protected internal WorkDayTime[] WorkDaysOfWeek { get; }
        protected internal Appointments(WorkDayTime[] workDaysOfWeek) 
        {
            WorkDaysOfWeek = new WorkDayTime[workDaysOfWeek.Length];
            int i = 0;
            foreach (WorkDayTime workDay in workDaysOfWeek) 
            {
                WorkDaysOfWeek[i++] = workDay;
            }
            AppointmentDays = new List<AppointmentDay>();
        }


        protected internal bool BookAppointment(DateTime AppointmentTime)
        {
            
            if (AppointmentTime < DateTime.Now) 
            {
                throw new ArgumentException($"Appointment Date ({AppointmentTime.ToLongDateString()}) Is Not Correct. Check It Again"); 
            }
            
            
            foreach (AppointmentDay appointment in AppointmentDays)
            {
                if (appointment.StartTime.ToShortDateString() == AppointmentTime.ToShortDateString())
                {
                    return appointment.BookAppointment(AppointmentTime);
                }
            }
        
            
            foreach (WorkDayTime workDay in WorkDaysOfWeek)
            {
                if (workDay.dayOfWeek == AppointmentTime.DayOfWeek)
                {
                    AppointmentDay NewAppointment = new AppointmentDay(workDay, AppointmentTime);
                    AppointmentDays.Add(NewAppointment);
                    return NewAppointment.BookAppointment(AppointmentTime);
                }
            }

            throw new ArgumentOutOfRangeException($" Selected appointment time ({AppointmentTime.ToLongTimeString()}) is out of worktime!");
        }


        protected internal bool IsPresentNow()
        { 
            foreach(WorkDayTime workday in WorkDaysOfWeek)
            {
                if ((workday.dayOfWeek == DateTime.Today.DayOfWeek) && (workday.sTime.Hour <= DateTime.Now.Hour))
                {
                    if (workday.eTime.Hour > DateTime.Now.Hour) return true;
                }
            }
            return false;
        }
    }

    public class AppointmentDay
    {
        protected internal DayOfWeek DayOfWeek { get; }
        protected internal DateTime StartTime { get; private set; }
        protected internal DateTime EndTime { get; private set; }
        protected internal AppointmentHour[] AppointmentHours { get; private set; }

        private TimeSpan WorkSpan;
        protected internal AppointmentDay(WorkDayTime WorkDayOfWeek, DateTime date)
        {
            if (WorkDayOfWeek.eTime <= WorkDayOfWeek.sTime) throw new ArgumentException("StartTime can't be later than the EndTime!");
            DayOfWeek = WorkDayOfWeek.dayOfWeek;
            StartTime = new DateTime(date.Year, date.Month, date.Day, WorkDayOfWeek.sTime.Hour, WorkDayOfWeek.sTime.Minute, WorkDayOfWeek.sTime.Second);
            EndTime = new DateTime(date.Year, date.Month, date.Day, WorkDayOfWeek.eTime.Hour, WorkDayOfWeek.eTime.Minute, WorkDayOfWeek.eTime.Second);
            WorkSpan = EndTime - StartTime;
            AppointmentHours = new AppointmentHour[WorkSpan.Hours];
            CreateWorkHourSlots();
        }


        protected internal bool BookAppointment(DateTime AppointmentTime)
        {
            if ((AppointmentTime >= EndTime) || (AppointmentTime < StartTime))
            {
                throw new ArgumentOutOfRangeException($"Selected appointment time ({AppointmentTime.TimeOfDay}) is out of worktime");
            }

            if ((AppointmentHours[GetAppointmentHourIndex(AppointmentTime)]).IsBooked())
            {
                throw new ArgumentException($"Selected appointment time ({AppointmentTime.TimeOfDay}) is not free");
            }

            AppointmentHours[(GetAppointmentHourIndex(AppointmentTime))].BookAppointment();
            return true;
        }

        private int GetAppointmentHourIndex(DateTime AppointmentTime)
        {
            TimeSpan AppointmentSpan = AppointmentTime - StartTime;
            int index = AppointmentSpan.Hours;
            return index;
        }

        private void CreateWorkHourSlots()
        {
            DateTime time = StartTime;
            for (int i = 0; i < WorkSpan.Hours; i += 1)
            {
                AppointmentHours[i] = new AppointmentHour(time);
                time = time.AddHours(1.0);
            }
        }

    

        protected internal class AppointmentHour
        {
            protected internal DateTime HourStart { get; private set;  }

            private bool Booked;
            protected internal AppointmentHour() 
            {
                Booked = false; 
            }
            protected internal AppointmentHour(DateTime Start)
            {
                HourStart = Start;
                Booked = false;
            }

            protected internal void BookAppointment()
            {
                this.Booked = true;
            }
            protected internal bool IsBooked() => Booked;
        }

    }

    public struct WorkDayTime
    {
        public DayOfWeek dayOfWeek { get; }
        public DateTime sTime { get; }
        public DateTime eTime { get; }

        public WorkDayTime(DayOfWeek dayOfWeek, DateTime sTime, DateTime eTime)
        {
            if (eTime <= sTime) throw new ArgumentException($"StartTime ({sTime.TimeOfDay}) can't be later than EndTime ({eTime.TimeOfDay})!");
            this.dayOfWeek = dayOfWeek;
            this.eTime = eTime;
            this.sTime = sTime;
        }
    }
}
