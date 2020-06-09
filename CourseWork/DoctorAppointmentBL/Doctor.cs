using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoctorAppointment
{
    public class Doctor : Person
    {
        public int ID { get; private set; }

        public DoctorSpecialty Specialty { get; }
        public WorkDayTime[] DoctorsWeeklySchedule { get; private set; }
        public Appointments DoctorsAppointments { get; private set; }
        public Doctor(string name,
                      DateTime birthdate,
                      Gender gender,
                      DoctorSpecialty specialty)
        : base(name, birthdate, gender)
        {

            int lastSpecialty = Enum.GetValues(typeof(DoctorSpecialty)).Cast<int>().Max();

            if ((int)specialty >= lastSpecialty) 
            {
                throw new ArgumentOutOfRangeException(" Doctor's specialty is out of range", nameof(specialty));
            }
            Specialty = specialty;
        }


        protected internal void SetSchedule(WorkDayTime[] WeekSchedule)
        {
            DoctorsWeeklySchedule = WeekSchedule;
            DoctorsAppointments = new Appointments(DoctorsWeeklySchedule);
        }


        protected internal void AddID(int ID)
        {
            this.ID = ID;
        }
        
       protected internal bool BookAppointment(DateTime AppointmentTime)
       {
            return DoctorsAppointments.BookAppointment(AppointmentTime);
       }
        protected internal bool IsPresentNow()
        {
            return DoctorsAppointments.IsPresentNow();
        }
    }

    public enum DoctorSpecialty
    {
        Ophthalmologist,
        Allergist,
        Dermatologist,
        Pediatrician,
        Surgeon,
        Anastethiologist,
        Cardiologist,
        Otolaryngologist,
        Oral,
        Neurologist,
        Gynecologist,
        Endocrinologist,
    }
}
