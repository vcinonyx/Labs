using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoctorAppointment
{
    public abstract class Person
    {
        public string Name { get; }
        protected internal DateTime BirthDate { get; }
        protected internal Gender Gender { get; }
        public Person(string name, DateTime birthDate, Gender gender)
        {

            #region Check Parameters
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can't be empty or null");
            }  
            
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Date of birth is not correct");
            }
            
            int lastGender = Enum.GetValues(typeof(Gender)).Cast<int>().Max();
            
            if ((int) gender > lastGender)
            {
                throw new ArgumentOutOfRangeException("Gender is not correct", nameof(gender));
            }
            #endregion

            Name = name;
            BirthDate = birthDate;
            Gender = gender;
        }
    }
    public enum Gender 
    {
        Male,
        Female,
    }
}
