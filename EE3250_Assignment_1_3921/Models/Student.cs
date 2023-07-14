using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EE3250_Assignment_1_3921.Models
{
    public class Student
    {
        public string Id { get; set; }
        public BitmapImage Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Telephone { get; set; }
        public double GPA { get; set; }

        #region Default Constructor
        public Student()
        {

        }
        #endregion

        #region Overloaded Constructor
        public Student(string id, BitmapImage image, string firstName, string lastName, string gender, DateOnly dateOfBirth, string telephone, double gPA)
        {
            Id = id;
            Image = image;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Telephone = telephone;
            GPA = gPA;
        } 
        #endregion
    }
}
