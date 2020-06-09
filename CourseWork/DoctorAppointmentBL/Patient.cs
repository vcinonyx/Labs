using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorAppointment
{
    public class Patient : Person
    {
        protected internal int ID { get; private set; }
        protected internal string PhoneNumber { get; }
        public Patient(string name, DateTime birthDate, Gender gender) : base(name, birthDate, gender) { }
        public Patient(string name,
                       DateTime birthDate,
                       Gender gender,
                       string phoneNumber
                       )
                       : base(name, birthDate, gender)

        { 
            PhoneNumber = phoneNumber;
        }

        protected internal void AddID(int ID)
        {
            this.ID = ID;
        }
    }
}
