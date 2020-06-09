using System;
using DoctorAppointment;

namespace DoctorAppointmentApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Clinic myClinic = new Clinic("Durka Clinic");
            myClinic.Open(AddPersonHandler, SetDiagnoseHandler, BookAppointmentHandler, SeePatientHistoryHandler, CheckIfDoctorPresentHandler);
            UserController.StartInformation(myClinic);
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\n 1. Create Patient Card  \t 2. Add a Doctor \t 3. See Doctor's TimeTable\n " +
                    "4. Book Appointment \t\t 5. Add Diagnose \t 6. See Patient's History \n 7. Check if Doctor is Present");
                try
                {
                    Console.Write("\n Choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                            
                    switch (choice)
                    {
                        case 1:
                            UserController.CreateAccount(myClinic);
                            break;
                        case 2:
                            UserController.AddDoctor(myClinic);
                            break;
                        case 3:
                            UserController.SeeDoctorsTimeTable(myClinic);
                            break;
                        case 4:
                            UserController.BookAppointment(myClinic);
                            break;
                        case 5:
                            UserController.AddDiagnose(myClinic);
                            break;
                        case 6:
                            UserController.SeePatientHistory(myClinic);
                            break;
                        case 7:
                            UserController.CheckIfDoctorPresent(myClinic);
                            break;
                        case 8:
                            flag = false;
                            continue;
                    }
                }
                
                catch (Exception E)
                {
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" \n " + E.Message);
                    Console.ForegroundColor = color;
                }
            }
        }

        private static void AddPersonHandler(object sender, ClinicEventArgs e)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" \n " + e.Message);
            Console.ForegroundColor = color;
        }
        
        
        private static void BookAppointmentHandler(object sender, ClinicEventArgs e)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" \n " + e.Message);
            Console.ForegroundColor = color;
        }
        

        private static void SetDiagnoseHandler(object sender, ClinicEventArgs e)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" \n " + e.Message);
            Console.ForegroundColor = color;
        }


        private static void SeePatientHistoryHandler(object senderm, ClinicEventArgs e)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" \n " + e.Message);
            Console.ForegroundColor = color;
        }

        private static void CheckIfDoctorPresentHandler(object sender, ClinicEventArgs e)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" \n " + e.Message);
            Console.ForegroundColor = color;
        }
    }
}

