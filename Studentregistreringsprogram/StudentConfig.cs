using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Studentregistreringsprogram
{
   public class StudentConfig
    {
        StudentDBContext dbCtx = new StudentDBContext();
        Student student = new Student();
        public void AddStudent(string firstName, string lastName, string city)
        {
            var student = new Student()
            {
                FirstName = firstName,
                LastName =lastName,
                City = city
            };
            dbCtx.Add(student);
            dbCtx.SaveChanges();
        }

        public void RemoveStudent(int idInput)
        {
            StudentIdSearch(idInput);
            var delete = dbCtx.Students.Where(s => s.StudentId == idInput).FirstOrDefault<Student>();
            dbCtx.Remove(delete);
            dbCtx.SaveChanges();
        }

        public Student? StudentIdSearch(int idInput)
        {
            return dbCtx.Students.Where(s => s.StudentId == idInput).FirstOrDefault<Student>();
        }

        public void StudentFirstNameSearch(string nameInput)
        {
            if (dbCtx.Students.Any(s => s.FirstName == nameInput))
            {
                var allTheSameName = dbCtx.Students.Where(s => s.FirstName == nameInput).
                               OrderBy(s => s.FirstName)
                               .ThenBy(s => s.LastName);
                foreach (var student in allTheSameName)
                {
                    Console.WriteLine($"{student.StudentId.ToString().PadRight(5)} {student.FirstName.PadRight(7)} {student.LastName.PadRight(10)} {student.City}");
                }
                Console.WriteLine("\nTryck på valfri knapp för att fortsätta");
                Console.Read();
            }

            else
            {
                Console.WriteLine("Hittar ingen med det förnamnet, klicka på valfri knapp och försök igen");
                Console.ReadKey();
            }
        }
            
            public void StudentLastNameSearch(string lastNameInput)
            {
            if (dbCtx.Students.Any(s => s.LastName == lastNameInput))
            {
                var allTheSameName = dbCtx.Students.Where(s => s.LastName == lastNameInput).
                               OrderBy(s => s.LastName)
                               .ThenBy(s => s.FirstName);
                foreach (var student in allTheSameName)
                {
                    Console.WriteLine($"{student.StudentId.ToString().PadRight(5)} {student.FirstName.PadRight(7)} {student.LastName.PadRight(10)} {student.City}");
                }
                Console.WriteLine("\nTryck på valfri knapp för att fortsätta");
                Console.ReadLine();
            }

            else
            {
                Console.WriteLine("Hittar ingen med det efternamnet, klicka på valfri knapp och försök igen");
                Console.ReadKey();
            }
        }


        public void StudentCitySearch(string cityInput)
        {
            if (dbCtx.Students.Any(s => s.City == cityInput))
            {
                var allTheSameName = dbCtx.Students.Where(s => s.City == cityInput).
                                OrderBy(s => s.City)
                               .ThenBy(s => s.FirstName)
                               .ThenBy(s=>s.LastName);
                foreach (var student in allTheSameName)
                {
                    Console.WriteLine($"{student.StudentId.ToString().PadRight(5)} {student.FirstName.PadRight(7)} {student.LastName.PadRight(10)} {student.City}");
                }
                Console.WriteLine("\nTryck på valfri knapp för att fortsätta");
                Console.Read();
            }

            else
            {
                Console.WriteLine("Hittar ingen ort med det namnet, klicka på valfri knapp och försök igen");
                Console.ReadKey();
            }
        }



        public void ChangeFirstName(int idInput)
        {
            Student? student = StudentIdSearch(idInput);
            Console.WriteLine("Ange det nya förnamnet:");
            string newFirstName = Console.ReadLine();
            student.FirstName = newFirstName;
            dbCtx.SaveChanges();
        }


        public void ChangeLastName(int idInput)
        {
            var student = dbCtx.Students.Where(s => s.StudentId == idInput).FirstOrDefault<Student>();
            Console.WriteLine("Ange det nya efternamnet:");
            string newLastName = Console.ReadLine();
            student.LastName = newLastName;
            dbCtx.SaveChanges();
            
        }



        public void ChangeCity(int idInput)
        {
            var student = dbCtx.Students.Where(s => s.StudentId == idInput).FirstOrDefault<Student>();
            Console.WriteLine("Ange den nya orten:");
            string newCity = Console.ReadLine();
            student.City = newCity;
            dbCtx.SaveChanges();
        }

        public void ShowStudent(int idInput)
        {
            Student? student = StudentIdSearch(idInput);

            Console.WriteLine($"{student.StudentId.ToString().PadRight(5)} {student.FirstName.PadRight(7)} {student.LastName.PadRight(10)} {student.City}");
        }

        public void ShowAllStudent()
        {
            

            foreach (var item in dbCtx.Students)
            {
                Console.WriteLine($"{item.StudentId.ToString().PadRight(5)} {item.FirstName.PadRight(7)} {item.LastName.PadRight(10)} {item.City}");
                Console.WriteLine("--------------------------------------");
            }

        }

       


    }
}
