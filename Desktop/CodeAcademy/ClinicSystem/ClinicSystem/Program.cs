using ClinicSystem.Data;
using ClinicSystem.Model;
using System.Numerics;

namespace ClinicSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello to our clienic");
            using DataContextClinic _clinic = new DataContextClinic();

            while (true)
            {
                Console.WriteLine("for login press 1 \n for register press 2");
                int loginNumber;
                int.TryParse(Console.ReadLine(), out loginNumber);
                switch (loginNumber)
                {
                    case 1:
                        #region take passwor
                        Console.WriteLine("Enter Your name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Your password");
                        string password = Console.ReadLine();
                        int personID = login(name, password);
                        #endregion
                        
                       
                        break;
                    case 2:
                        Regstraion();
                        break;
                    default:
                        Console.WriteLine("choose the right number please");
                        break;
                }
            }


            #region login function
            int login(string name, string password)
            {
                int personID = 0;
                try { 
                var visitorlogin = _clinic.Persons.Where(e => name == e.Name && password == e.password).FirstOrDefault();
                if (visitorlogin != null)
                {
                        personID = visitorlogin.Person_Id;
                        string role = visitorlogin.role;
                        Console.WriteLine($"welcome {name} ");
                        if (role == "Admin")
                        {
                            AppointmentList(personID);
                            Console.WriteLine("choose the number of the appointment to update stats? or press Enter to live");
                            int updatapp;
                            int.TryParse(Console.ReadLine(), out updatapp);
                            UpdateAppoint(updatapp);
                            
                        }
                        else if (role == "Patiene")
                        {
                            Console.WriteLine(" please take appointment");
                            takaAppointment(personID);
                        }

                    }
                    else
                {
                    Console.WriteLine("you dont have account");
                }
                }catch (Exception ex) {
                    Console.WriteLine("you name is unavailabe");
                }
                return personID;
            }

            #endregion

            #region Restraion
            void Regstraion()
            {

                Console.WriteLine("Enter Your name");
                string name = Console.ReadLine();

                Console.WriteLine("Create Your password");
                string password = Console.ReadLine();

                Console.WriteLine("Enter Your Phone");
                int phone;

                int.TryParse(Console.ReadLine(), out phone);
                Console.WriteLine("Enter Your Email");

                string Email = Console.ReadLine();

                Console.WriteLine("for Admin press= 1 \n for patient press = 2");
                int authoriz;
                int.TryParse(Console.ReadLine(), out authoriz);
                string role = "Patiene";
                try
                {
                    Person person = new Person();
                    person.Name = name;
                    person.password = password;
                    person.phoneNumber = phone;
                    person.Email = Email;
                    person.role = role;

                    _clinic.Persons.Add(person);
                    _clinic.SaveChanges();
                    Console.WriteLine("Sucssef");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("not saved" + ex.Message);
                }
            }
            #endregion

            #region takeAppointment
            void takaAppointment(int personID)
            {
                Console.WriteLine("what is your Specialization? Enter the number");

                // display the speclization list
                int spliz = 0;
                var splicilization = from x in _clinic.specialization select x;
                foreach (var x in splicilization)
                {
                    Console.WriteLine($" {x.SpeciaID} >> {x.Specia_Name}");
                }
                int.TryParse(Console.ReadLine(), out spliz);
                // take time 
                Console.WriteLine("Enter the time");
                DateTime time;
                DateTime.TryParse(Console.ReadLine(), out time);
                DateTime dt2 = new DateTime(2015, 12, 31); 

                // Date
                Console.WriteLine("Enter the date");
                DateTime date;
                DateTime.TryParse(Console.ReadLine(), out date);

                try
                {
                    Appointment appointment = new Appointment();
                    appointment.person_ID = personID;
                    appointment.appoinDate = date;
                    appointment.appoinTime = time;
                    appointment.specialization_ID = spliz;

                    appointment.status = "not approved";
                    _clinic.Appointments.Add(appointment);
                    _clinic.SaveChanges();
                    Console.WriteLine("Appoint add but not approved");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            #endregion

            #region Appointment List
            void AppointmentList(int personID)
            {
               
                var Appointm = (from x in _clinic.Appointments orderby x.appoinDate select x).ToList();
                if (Appointm.Count == 0)
                {
                    Console.WriteLine("You dont have appointment");
                }
                Console.WriteLine($" AppointentID | appoinTime |  appoinDate | person_ID | status");
                foreach (var x in Appointm)
                {
                    Console.WriteLine($" {x.AppointentID} | {x.appoinTime} | {x.appoinDate} | {x.person_ID} | {x.status}");
                }
            }
            #endregion

            #region UpdateAppointment
            void UpdateAppoint(int ID)
            {
                try
                {
                    var _updateAppointment = _clinic.Appointments.FirstOrDefault(a => a.AppointentID == ID);
                     _updateAppointment.AppointentID = ID;
                    Console.WriteLine("what you want to change? \n 1..time \n 2..Date \n 3..stats");
                    int up;
                    int.TryParse(Console.ReadLine(), out up);
                    switch (up)
                    {
                        case 1:
                            Console.WriteLine("Enter the new day");
                            DateTime Timenew;
                            DateTime.TryParse(Console.ReadLine(), out Timenew);
                            _updateAppointment.appoinTime = Timenew;
                            break;
                        case 2:
                            Console.WriteLine("Enter the new time");
                            DateTime Datenew;
                            DateTime.TryParse(Console.ReadLine(), out Datenew);
                            _updateAppointment.appoinTime = Datenew;
                            break;
                        case 3:
                            _updateAppointment.status = "approved";
                            break;
                    }
                    _clinic.Appointments.Update(_updateAppointment);
                    _clinic.SaveChanges();
                    Console.WriteLine("states is approved succesfuly");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            #endregion

        }
    }
}