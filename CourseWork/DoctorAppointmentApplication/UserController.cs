using System;
using DoctorAppointment;

namespace DoctorAppointmentApplication
{
    public class UserController
    {
        protected internal static void CreateAccount(Clinic clinic)
        {
            Console.WriteLine("\n Fill next fields to create PatientCard");
            Console.Write(" Name: ");
            string name = Convert.ToString(Console.ReadLine());
            Console.Write(" Gender: ");
            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.Write($" {i}. {Enum.GetName(typeof(Gender), i) + "\t"}");
            }
            Console.Write("\n Choice: ");
            Gender gender = (Gender)Convert.ToInt32(Console.ReadLine()); 
            Console.Write(" Phone number: ");
            string phoneNumber = Convert.ToString(Console.ReadLine());
            Console.Write(" Date of birth \n");
            Console.Write(" Year: "); int year = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Month (number): "); int month = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Day: "); int day = Convert.ToInt32(Console.ReadLine());
            clinic.AddPatient(name, new DateTime(year, month, day), gender, phoneNumber);
            return;
        }

        protected internal static void AddDoctor(Clinic clinic)
        {
            Console.WriteLine("\n To add a doctor fill the next fields");
            Console.Write(" Name: ");
            string name = Convert.ToString(Console.ReadLine());
            Console.Write(" Gender: ");
            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.Write($" {i}. {Enum.GetName(typeof(Gender), i) + "\t"}");
            }
            Console.Write(" Choice: ");
            Gender gender = (Gender)Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" Specialty: ");
            foreach (int i in Enum.GetValues(typeof(DoctorSpecialty)))
            {
                Console.Write($" {i}. {Enum.GetName(typeof(DoctorSpecialty), i) + "\n"}");
            }
            Console.Write(" Answer: ");
            DoctorSpecialty specialty = (DoctorSpecialty)Convert.ToInt32(Console.ReadLine());
            Console.Write(" Date of birth \n");
            Console.Write(" Year: "); int year = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Month (number): "); int month = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Day: "); int day = Convert.ToInt32(Console.ReadLine());
            clinic.AddDoctor(name, new DateTime(year, month, day), gender, specialty);
            return;
        }


        protected internal static void BookAppointment(Clinic clinic)
        {
            int doctorID;
            int patientID;
            Console.WriteLine("\n Do You Have Patient Card?" +
                "\t 1. Yes \t 2. No");

            Console.Write(" Choice: ");
            int command = Convert.ToInt32(Console.ReadLine());

            if (command == 1)
            {
                Console.Write(" Enter your ID: ");
                patientID = Convert.ToInt32(Console.ReadLine());
                var CurrentPatient = clinic.FindPatient(patientID);
                Console.WriteLine(" Select Doctor from the List ");
                foreach (var doctor in clinic.doctors)
                {
                    Console.WriteLine(" " + doctor.ID + ". " + doctor.Name + " " + doctor.Specialty);
                }
                Console.Write(" Number: ");
                doctorID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(" Enter Appointment Date: ");
                Console.Write(" Year: "); int year = Convert.ToInt32(Console.ReadLine());
                Console.Write(" Month (number): "); int month = Convert.ToInt32(Console.ReadLine());
                Console.Write(" Day: "); int day = Convert.ToInt32(Console.ReadLine());
                Console.Write(" Hour: "); int hour = Convert.ToInt32(Console.ReadLine());
                clinic.BookAppointment(patientID, doctorID, new DateTime(year, month, day, hour, 0, 0));
            }

            if (command == 2)
            {
                CreateAccount(clinic);
            }
            return;
        }

        protected internal static void SeeDoctorsTimeTable(Clinic clinic)
        {
            Console.WriteLine("\n 1. Find Doctor by ID \t 2. Select Doctor from the Doctors List");
            Console.Write(" Answer: ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number == 1)
            {
                Console.Write(" Doctor's ID: ");
                int ID = Convert.ToInt32(Console.ReadLine());
                var DoctorsTimeTable = clinic.GetDoctorsWeekSchedule(ID);
                foreach (var workday in DoctorsTimeTable)
                {
                    Console.WriteLine(" " + workday.dayOfWeek + "   \t" + workday.sTime.TimeOfDay + " - " + workday.eTime.TimeOfDay);
                }
            }
            if (number == 2)
            {
                Console.WriteLine();
                foreach (var doctor in clinic.doctors)
                {
                    Console.WriteLine(" " + doctor.ID + ". " + doctor.Name + " " + doctor.Specialty);
                }
                Console.Write(" Number: ");
                int ID = Convert.ToInt32(Console.ReadLine());
                var DoctorsTimeTable = clinic.GetDoctorsWeekSchedule(ID);
                foreach (var workday in DoctorsTimeTable)
                {
                    Console.WriteLine(" " + workday.dayOfWeek + "   \t" + workday.sTime.TimeOfDay + " - " + workday.eTime.TimeOfDay);
                }
            }
            return;
        }


        protected internal static void CheckIfDoctorPresent(Clinic clinic)
        {
            Console.WriteLine(" 1. Enter Doctor's ID \t 2. Select Doctor from the Doctors List");
            Console.Write(" Choice: ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number == 1)
            {
                Console.Write(" Doctor's ID: ");
                int ID = Convert.ToInt32(Console.ReadLine());
                clinic.CheckIfDoctorPresent(ID);
            }
            if (number == 2)
            {
                Console.WriteLine();
                foreach (var doctor in clinic.doctors)
                {
                    Console.WriteLine(" " + doctor.ID + ". " + doctor.Name + " " + doctor.Specialty);
                }
                Console.Write(" Number: ");
                int ID = Convert.ToInt32(Console.ReadLine());
                clinic.CheckIfDoctorPresent(ID);
            }
        }

        protected internal static void AddDiagnose(Clinic clinic)
        {
            Console.Write("\n Enter your ID: ");
            int doctorID = Convert.ToInt32(Console.ReadLine());
            var cards = clinic.GetDoctorsPatients(doctorID);
            if (cards != null)
            {
                foreach (var card in cards)
                {
                    Console.WriteLine($" Card Number: {card.cardNumber}   \t Patient: {card.patient.Name} \t Date: {card.appointmentDate.ToLongTimeString()}");
                }

                Console.Write("\n Enter Card Number: ");
                int cardnumber = Convert.ToInt32(Console.ReadLine());
                Console.Write(" Write diagnose: ");
                string diagnose = Convert.ToString(Console.ReadLine());
                clinic.AddDiagnose(doctorID, cardnumber, diagnose);
            }

            return;
        }


        protected internal static void SeePatientHistory(Clinic clinic)
        {
            Console.Write("\n Enter your ID: ");
            int patientID = Convert.ToInt32(Console.ReadLine());
            var history = clinic.GetPatientHistory(patientID);
            if (history != null)
            {
                foreach (var appointment in history)
                {
                    Console.WriteLine($" Patient: {appointment.patient.Name} \n Doctor {appointment.doctor.Name} " +
                        $"\n Appointment Date: {appointment.appointmentDate.ToLongTimeString()} " +
                        $"\n Diagnose: {appointment.Diagnose}");
                }
            }

            return;
        }


        protected internal  static void AddPersonHandler(object sender, ClinicEventArgs e)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" \n " + e.Message);
            Console.ForegroundColor = color;
        }


        protected internal static void BookAppointmentHandler(object sender, ClinicEventArgs e)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" \n " + e.Message);
            Console.ForegroundColor = color;
        }


        protected internal static void SetDiagnoseHandler(object sender, ClinicEventArgs e)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" \n " + e.Message);
            Console.ForegroundColor = color;
        }


        protected internal static void SeePatientHistoryHandler(object senderm, ClinicEventArgs e)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" \n " + e.Message);
            Console.ForegroundColor = color;
        }

        protected internal static void CheckIfDoctorPresentHandler(object sender, ClinicEventArgs e)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" \n " + e.Message);
            Console.ForegroundColor = color;
        }


        protected internal static void StartInformation(Clinic myClinic)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Doctor[] doctors = new Doctor[5];
            doctors[0] = new Doctor("Ivan Pesotsky", new DateTime(1965, 7, 13), Gender.Male, DoctorSpecialty.Allergist);
            doctors[1] = new Doctor("Petro Liashko", new DateTime(1962, 8, 31), Gender.Male, DoctorSpecialty.Ophthalmologist);
            doctors[2] = new Doctor("Svitlana Prius", new DateTime(1989, 5, 12), Gender.Female, DoctorSpecialty.Dermatologist);
            doctors[3] = new Doctor("Peter Parker", new DateTime(1974, 8, 15), Gender.Male, DoctorSpecialty.Pediatrician);
            doctors[4] = new Doctor("Victor Zhuk", new DateTime(1945, 12, 24), Gender.Male, DoctorSpecialty.Surgeon);
            Patient patient1 = new Patient("Patrick Lumumba", new DateTime(1999, 9, 9), Gender.Female);
            Patient patient2 = new Patient("Paul Pogba", new DateTime(1993, 1, 9), Gender.Male);
            Patient patient3 = new Patient("Antoine Griman", new DateTime(1990, 3, 19), Gender.Female);
            myClinic.AddDoctor(doctors[0]);
            myClinic.AddDoctor(doctors[1]);
            myClinic.AddDoctor(doctors[2]);
            myClinic.AddDoctor(doctors[3]);
            myClinic.AddDoctor(doctors[4]);
            myClinic.AddPatient(patient1);
            myClinic.AddPatient(patient2);
            myClinic.AddPatient(patient3);

            WorkDayTime[] workTime = new WorkDayTime[6];
            workTime[0] = new WorkDayTime(DayOfWeek.Monday, new DateTime(1, 1, 1, 9, 0, 0), new DateTime(1, 1, 1, 12, 0, 0, 0));
            workTime[1] = new WorkDayTime(DayOfWeek.Tuesday, new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 12, 0, 0, 0));
            workTime[2] = new WorkDayTime(DayOfWeek.Wednesday, new DateTime(1, 1, 1, 9, 0, 0), new DateTime(1, 1, 1, 13, 0, 0, 0));
            workTime[3] = new WorkDayTime(DayOfWeek.Thursday, new DateTime(1, 1, 1, 10, 0, 0), new DateTime(1, 1, 1, 14, 0, 0, 0));
            workTime[4] = new WorkDayTime(DayOfWeek.Friday, new DateTime(1, 1, 1, 9, 0, 0), new DateTime(1, 1, 1, 20, 0, 0, 0));
            workTime[5] = new WorkDayTime(DayOfWeek.Saturday, new DateTime(1, 1, 1, 9, 0, 0), new DateTime(1, 1, 1, 23, 0, 0, 0));

            foreach (Doctor doctor in doctors)
            {
                myClinic.SetDoctorsSchedule(workTime, doctor.ID);
            }
        }

    }
}
