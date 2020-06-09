using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment
{
    public class Clinic
    {
        protected internal event ClinicStateHandler Added;
        protected internal event ClinicStateHandler Booked;
        protected internal event ClinicStateHandler Diagnosed;
        protected internal event ClinicStateHandler SeenHistory;
        protected internal event ClinicStateHandler CheckedIfPresent;

        private static int AppointmentCardNumber;

        private static int DoctorsID;

        private static int PatientsID;
        public string name { get; }
        public Doctors doctors { get; }

        private List<Patient> patients;

        private List<AppointmentCard> AppointmentCards;
        
        public void Open(ClinicStateHandler addPersonHandler, ClinicStateHandler setDiagnoseHandler, 
                        ClinicStateHandler bookAppointmentHandler, ClinicStateHandler seeHistoryHandler, ClinicStateHandler checkIfDoctorPresent)
        {
            Added += addPersonHandler;
            Booked += bookAppointmentHandler;
            Diagnosed += setDiagnoseHandler;
            SeenHistory += seeHistoryHandler;
            CheckedIfPresent += checkIfDoctorPresent;
        }
        public Clinic(string Name)
        {
            
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException("Name can't be empty or Null");
            }

            name = Name;
            doctors = new Doctors();
            patients = new List<Patient>();
            AppointmentCards = new List<AppointmentCard>();
            DoctorsID = 1;
            PatientsID = 1;
            AppointmentCardNumber = 1;
        }


        public void SetDoctorsSchedule(WorkDayTime[] workTime, int ID)
        {
            Doctor doctor = FindDoctor(ID);
            doctor.SetSchedule(workTime);
        }

        
        public void AddDoctor(Doctor doctor)
        {
            doctors.Add(doctor);
            doctor.AddID(DoctorsID);
            OnAdded(new ClinicEventArgs($" Doctor Succesfully Added! \n Name: {doctor.Name}\t Specialty: {doctor.Specialty} \t   ID: {DoctorsID}", DateTime.Now));
            DoctorsID++;
        }


        public void AddDoctor(string name, DateTime birthDate, Gender gender, DoctorSpecialty specialty)
        {
            Doctor doctor = new Doctor(name, birthDate, gender, specialty);
            doctors.Add(doctor);
            doctor.AddID(DoctorsID);
            OnAdded(new ClinicEventArgs($" Doctor Succesfully Added! \n Name: {doctor.Name}\t Specialty: {doctor.Specialty} \t ID: {DoctorsID}", DateTime.Now));
            DoctorsID++;
        }


        public void AddPatient(string name, DateTime birthDate, Gender gender, string phonenumber)
        {
            Patient patient = new Patient(name, birthDate, gender, phonenumber);
            patients.Add(patient);
            patient.AddID(PatientsID);
            OnAdded(new ClinicEventArgs($" Patient Card Succesfully Created! \n  Name: {patient.Name} \t  ID: {PatientsID}", DateTime.Now));
            PatientsID++;
        }


        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
            patient.AddID(PatientsID);
            OnAdded(new ClinicEventArgs($" Patient Card Succesfully Created! \n  Name: {patient.Name} \t  ID: {PatientsID}", DateTime.Now));
            PatientsID++;        
        }



        public void BookAppointment(Patient patient, Doctor doctor, DateTime AppointmentTime)
        {
            if (doctor.DoctorsAppointments.BookAppointment(AppointmentTime))
            {
                AppointmentCard card = new AppointmentCard(doctor, patient, AppointmentTime, AppointmentCardNumber++);
                AppointmentCards.Add(card);
                OnBooked(new ClinicEventArgs($"Appointment Succesfully Booked! \n Patient: {patient.Name} \n Doctor: {doctor.Name} " +
                    $"\n Time: {AppointmentTime.ToShortDateString()} \n Appointment Card: #{AppointmentCardNumber}", DateTime.Now));
            }
        }


        public void BookAppointment(int patientID, int doctorID, DateTime AppointmentTime)
        {
            Patient patient = FindPatient(patientID);
            Doctor doctor = FindDoctor(doctorID);
            if (doctor.DoctorsAppointments.BookAppointment(AppointmentTime))
            {
                AppointmentCard card = new AppointmentCard(doctor, patient, AppointmentTime, AppointmentCardNumber);
                AppointmentCards.Add(card);
                OnBooked(new ClinicEventArgs($" Appointment Succesfully Booked! \n Patient: {patient.Name} \n Doctor: {doctor.Name} " +
                    $"\n Time: {AppointmentTime.ToShortDateString()} \n Appointment Card: #{AppointmentCardNumber}", DateTime.Now));
                AppointmentCardNumber++;
            }
        }


        public WorkDayTime[] GetDoctorsWeekSchedule(int ID)
        {
            return FindDoctor(ID).DoctorsWeeklySchedule;
        }


        public void AddDiagnose(int doctorID, int appcardN, string diagnose)
        {
            var selectedCard = AppointmentCards.Where(card => card.cardNumber == appcardN).First();
            if (doctorID == selectedCard.doctor.ID)
            {
                selectedCard.SetDiagnose(diagnose);
                OnDiagnosed(new ClinicEventArgs($" Added diagnose ({diagnose}) to the Appointment Card #{selectedCard.cardNumber}" +
                                                $"\n Doctor: {selectedCard.doctor.Specialty} {selectedCard.doctor.Name} " +
                                                $"\n Patient: {selectedCard.patient.Name}", DateTime.Now));
            }
            else OnDiagnosed(new ClinicEventArgs($" Entered ID do not match the Appointment Card",DateTime.Now));
        }


        public List<AppointmentCard> GetDoctorsPatients(int doctorID)
        {
            List<AppointmentCard> selectedCards = AppointmentCards.Where(card => card.Diagnose == "" && card.doctor.ID == doctorID).ToList();
            if (selectedCards.Count == 0)
            {
                OnDiagnosed(new ClinicEventArgs($" There is no Cards to Add diagnose!", DateTime.Now));
                return null;
            }

            OnDiagnosed(new ClinicEventArgs($" List of Doctors Patients without diagnose", DateTime.Now));
            return selectedCards;
        }


        public List<AppointmentCard> GetPatientHistory(int patientID)
        {
            List<AppointmentCard> selectedCards = AppointmentCards.Where(card => card.patient.ID == patientID).ToList();
            if (selectedCards.Count == 0)
            {
                OnHistory(new ClinicEventArgs($"  Appointment History of patient with ID: {patientID} is empty!", DateTime.Now));
                return null;
            }
            OnHistory(new ClinicEventArgs($" History of {FindPatient(patientID).Name}:", DateTime.Now));
            return selectedCards;
        }


        public void CheckIfDoctorPresent(int ID)
        {

            if (FindDoctor(ID).IsPresentNow())
            {
                OnPresent(new ClinicEventArgs($" Doctor {FindDoctor(ID).Name} is present at the moment", DateTime.Now));
            };

            OnPresent(new ClinicEventArgs($" Doctor {FindDoctor(ID).Name}  is not present at the moment", DateTime.Now));
        }


        public Doctor FindDoctor(int ID)
        {
            if (ID > 0)
            {
                foreach (Doctor doctor in doctors)
                {
                    if (doctor.ID == ID)
                    {
                        return doctor;
                    }
                }
                throw new ArgumentOutOfRangeException($"No Doctor find with ID: {ID}");
            }
            throw new ArgumentOutOfRangeException("Doctor's ID can't be negative");
        }


        public Patient FindPatient(int ID)
        {
            if (ID > 0)
            {
                foreach (Patient patient in patients)
                {
                    if (patient.ID == ID)
                    {
                        return patient;
                    }
                }
                throw new ArgumentOutOfRangeException($"No Patient find with ID: {ID}" );
            }
            throw new ArgumentOutOfRangeException("Patient's ID can't be negative");
        }



        private void CallEvent(ClinicEventArgs e, ClinicStateHandler handler)
        {
            if (e != null && handler != null)
                handler(this, e);
        }

        private void OnAdded(ClinicEventArgs e)
        {
            CallEvent(e, Added);
        }
        private void OnBooked(ClinicEventArgs e)
        {
            CallEvent(e, Booked);
        }

        private void OnDiagnosed(ClinicEventArgs e)
        {
            CallEvent(e, Diagnosed);
        }

        private  void OnHistory(ClinicEventArgs e)
        {
            CallEvent(e, SeenHistory);
        }

        private void OnPresent(ClinicEventArgs e)
        {
            CallEvent(e, CheckedIfPresent);
        }
    }


    public class Doctors: IEnumerable<Doctor>
    {
        
        private List<Doctor> _doctors;
        
        protected internal Doctors() 
        {
            _doctors = new List<Doctor>();
        }

        protected internal void Add(Doctor doctor)
        {
            _doctors.Add(doctor);
        }

        public IEnumerator<Doctor> GetEnumerator()
        {
            return _doctors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _doctors.GetEnumerator();
        }
    }
}