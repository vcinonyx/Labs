using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorAppointment
{
    public delegate void ClinicStateHandler(object sender, ClinicEventArgs e);
    public class ClinicEventArgs
    {
        public string Message { get; private set; }
        public DateTime Time { get; private set; }
        public ClinicEventArgs(string _message, DateTime _time)
        {
            Message = _message;
            Time = _time;
        }
    }
}
