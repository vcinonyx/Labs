using System;

namespace DoctorAppointment
{
    public class AppointmentCard
    {
        public int cardNumber { get; }
        public DateTime appointmentDate { get; private set; }

        public Doctor doctor { get; }

        public Patient patient { get;  }

        public string Diagnose { get; private set; }

        public AppointmentCard(Doctor Doctor, Patient Patient, DateTime AppointmentTime, int CardNumber)
        {
            doctor = Doctor;
            patient = Patient;
            appointmentDate = AppointmentTime;
            cardNumber = CardNumber;
            Diagnose = "";
        }

        protected internal void SetDiagnose(string diagnose)
        {
           if (string.IsNullOrWhiteSpace(diagnose))
           {
                throw new ArgumentException(" Diagnose can't be empty or Null! ");
           }

            Diagnose = diagnose;
        }
    }    
}
