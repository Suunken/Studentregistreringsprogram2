using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
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
            int menuSelect;
            do
            {
                PrintMenuScreen();
                switch (menuSelect = Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        PrintMenuSelectAddStudent();
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
            while (menuSelect != 0);
              
        }

        public void PrintMenuScreen()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("Val.1 : Registrera ny student");
            Console.WriteLine("Val.2 : Ändra befintlig student");
            Console.WriteLine("Val.3 : Visa alla studenter");
            Console.WriteLine("Val.4 : Sök efter student");
            Console.WriteLine("Val.0 : Avsluta");

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
            Console.WriteLine("1. Sök via förnamn");
            Console.WriteLine("2. Sök via efternamn");
            Console.WriteLine("3. Sök via ort");
            Console.WriteLine("0. Gå tillbaka");
        }

        public void PrintMenuSelectAddStudent()
        {
            Console.WriteLine("Vad heter den nya studenten i förnamn?");
            string firstName = Console.ReadLine();
            Console.WriteLine("Vad heter den nya studenten i efternamn?");
            string lastName = Console.ReadLine();
            Console.WriteLine("Vilken ort är eleven från?");
            string city = Console.ReadLine();
            studentConfig.AddStudent(firstName,lastName,city);
        }


        public void PrintMenuSelectChangeStudent()
        {
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
            Console.WriteLine("Vilket förnamn vill du söka efter?");
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
            Console.Clear();
            studentConfig.ShowAllStudent();
            Console.WriteLine();
            Console.WriteLine("Klicka på valfri knapp för att fortsätta");
            Console.ReadKey();
            Console.Clear();
        }
        public void PrintMenuSelectExit()
        {
            int menuSelect = 0;
            Console.Clear();
        }


        public void GitProblem()
        {
            Console.WriteLine("2025-03-18");
        }




    }
}
