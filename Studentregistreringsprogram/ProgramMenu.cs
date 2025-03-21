using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Studentregistreringsprogram
{

    public class ProgramMenu
    {
        StudentConfig studentConfig = new StudentConfig();
        public void MenuScreen()
        {
            int menuSelect =99;
            do
            {
                try
                {

                
                PrintMenuScreen();
                switch (menuSelect = Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                         AddOrRemoveMenu();
                        break;
                    case 2:
                        PrintMenuSelectChangeStudent();
                        break;
                    case 3:
                        PrintMenuSelectShowAllStudents();
                        break;
                    case 4:
                        MenuSearchStudent();
                        break;
                    case 0:
                        PrintMenuSelectExit();
                        break;
                }

                }
                catch
                {
                    Console.Clear();
                }

            }
            while (menuSelect != 0);
              
        }
        public void PrintMenuScreen()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("Val.1 : Registrera eller ta bort student");
            Console.WriteLine("Val.2 : Ändra befintlig student");
            Console.WriteLine("Val.3 : Visa alla studenter");
            Console.WriteLine("Val.4 : Sök efter student");
            Console.WriteLine("Val.0 : Avsluta");

        }








        public void AddOrRemoveMenu()
        {

            int menuSelect = 99;
            do
            {
                Console.Clear();
                PrintAddOrRemoveMenu();
                switch (menuSelect = Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        PrintMenuSelectAddStudent();
                        break;
                    case 2:
                        PrintMenuSelectRemoveStudent();
                        break;
                    case 0:
                        PrintMenuSelectExit();
                        break;
                }
            }
            while (menuSelect != 0);
        }

        public void PrintAddOrRemoveMenu()
        {
            Console.WriteLine("Registrera eller ta bort:");
            Console.WriteLine("Val.1 : Registrera ny student");
            Console.WriteLine("Val.2 : Radera student");
            Console.WriteLine("Val.0 : Gå tillbaka till huvudmeny");
        }

     





        public void MenuSearchStudent()
        {
            int menuSelect;
            do
            {
                PrintMenuSearchStudent();
                switch (menuSelect = Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        FirstNameSearch();
                        break;
                    case 2:
                        LastNameSearch();
                        break;
                    case 3:
                        CitySearch();
                        break;
                    case 0:
                        PrintMenuSelectExit();
                        break;
                }
            }
            while (menuSelect != 0);
        }
       
        
       
        public void PrintMenuSearchStudent()
        {
            Console.Clear();
            Console.WriteLine("Hur vill du söka efter studenten?");
            Console.WriteLine("1. Sök via förnamn");
            Console.WriteLine("2. Sök via efternamn");
            Console.WriteLine("3. Sök via ort");
            Console.WriteLine("0. Gå tillbaka");
        }

        public void PrintMenuSelectAddStudent()
        {

            string firstName = string.Empty;
            string lastName = string.Empty;
            string city = string.Empty;

            ShowStudent(firstName, lastName, city);

            Console.WriteLine("Vad heter den nya studenten i förnamn?");

            firstName = Console.ReadLine();
            if (firstName == string.Empty)
            {

                Console.Clear();
                Console.WriteLine("Du måste skriva in ett förnamn!");

                do
                {
                    Console.Clear();
                    Console.WriteLine("Vad heter den nya studenten i förnamn?");
                    firstName = Console.ReadLine();

                } while (firstName == string.Empty);

            }
            
            ShowStudent(firstName, lastName, city);

            Console.WriteLine("Vad heter den nya studenten i efternamn?");
            lastName = Console.ReadLine();

            if (lastName == string.Empty)
            {
                Console.Clear();
                Console.WriteLine("Du måste skriva in ett efternamn!");

                do
                {
                    Console.Clear();
                    Console.WriteLine("Vad heter den nya studenten i efternamn?");
                    lastName = Console.ReadLine();
                    Console.Clear();
                } while (lastName == string.Empty);
            }
            ShowStudent(firstName, lastName, city);

            Console.WriteLine("Vilken ort är studenten från?");
            city = Console.ReadLine();

            if (city == string.Empty)
            {
                Console.Clear();
                Console.WriteLine("Du måste skriva in en ort!");

                do
                {
                    Console.Clear();
                    Console.WriteLine("Vilken ort är studenten från?");
                    city = Console.ReadLine();
                    Console.Clear();
                } while (city == string.Empty);
            }

            


            ShowStudent(firstName, lastName, city);
            studentConfig.AddStudent(firstName, lastName, city);
            Console.WriteLine();
            Console.WriteLine("Den nya studenten har nu skapats! \nKlicka på valvri knapp för att fortsätta..");
            Console.Read();
            Console.Clear();
        }

        public void PrintMenuSelectRemoveStudent() 
        {
            Console.WriteLine("Du har vart att ta bort en student, vilken av dessa studenter vill du ta bort?");
            ShowStudentInfoHeader();
            studentConfig.ShowAllStudent();
            Console.Write("Ange ID på den student du vill ta bort:");
            int studentID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine($"Du tog bort:");
            studentConfig.ShowStudent(studentID);
            studentConfig.RemoveStudent(studentID);
            Console.ReadKey();
            Console.Clear();
            
        }

        private static void ShowStudent(string firstName, string lastName, string city)
        {
            Console.Clear();
            Console.WriteLine($"Den nya studenten:\n|Förnamn: {firstName.PadRight(10)} \n|Efternamn: {lastName.PadRight(10)} \n|Ort: {city}");
        }        


        public void PrintMenuSelectChangeStudent()
        {
            Console.Clear();
            Console.WriteLine("Dessa studenter finns nu");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"|{"ID".PadRight(5)} |{"Förnamn".PadRight(5)} |{"Efternamn".PadRight(10)} |{"Ort"} ");
            Console.WriteLine("--------------------------------------");
            studentConfig.ShowAllStudent();
            Console.WriteLine();
            Console.WriteLine("Ange ID på den du vill ändra på");
            int inputId = Convert.ToInt16(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Du har valt att ändra på:");
            studentConfig.ShowStudent(inputId);
            MenuSelectionChangeSpecificStudentValue(inputId);
            

        }

       


        
        
        public void MenuSelectionChangeSpecificStudentValue(int inputId)
        {
            int menuSelect;
            do
            {
                PrintMenuSelectionChangeSpecificStudentValue();
                switch (menuSelect = Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        studentConfig.ChangeFirstName(inputId);
                        break;
                    case 2:
                        studentConfig.ChangeLastName(inputId);
                        break;
                    case 3:
                        studentConfig.ChangeCity(inputId);
                        break;
                    case 0:
                        PrintMenuSelectExit();
                        break;
                }
            }
            while (menuSelect != 0);


        }

        public void PrintMenuSelectionChangeSpecificStudentValue()
        {
            Console.WriteLine();
            Console.WriteLine("Vill du ändra förnamn tryck 1");
            Console.WriteLine("Vill du ändra efternamn tryck 2");
            Console.WriteLine("Vill du ändra ort tryck 3");
            Console.WriteLine("Vill gå tillbaka tryck 0");
        }

        public void FirstNameSearch()
        {
            Console.WriteLine("Vilket förnamn vill du söka efter?");
            string nameSearch = Console.ReadLine();
            studentConfig.StudentFirstNameSearch(nameSearch);
            
        }
        public void LastNameSearch()
        {
            Console.WriteLine("Vilket efternamn vill du söka efter?");
            string nameSearch = Console.ReadLine();
            studentConfig.StudentLastNameSearch(nameSearch);
        }
        public void CitySearch()
        {
            Console.WriteLine("Vilken ort vill du söka efter?");
            string nameSearch = Console.ReadLine();
            studentConfig.StudentCitySearch(nameSearch);
          
        }


        public void PrintMenuSelectShowAllStudents()
        {
            ShowStudentInfoHeader();
            studentConfig.ShowAllStudent();
            Console.WriteLine();
            Console.WriteLine("Klicka på valfri knapp för att fortsätta");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ShowStudentInfoHeader()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"|{"ID".PadRight(5)} |{"Förnamn".PadRight(5)} |{"Efternamn".PadRight(10)} |{"Ort"} ");
            Console.WriteLine("--------------------------------------");
        }

        public void PrintMenuSelectExit()
        {
            int menuSelect = 0;
            Console.Clear();
        }


        public void Git()
        {
            Console.WriteLine("2025-03-18");
        }




    }
}
