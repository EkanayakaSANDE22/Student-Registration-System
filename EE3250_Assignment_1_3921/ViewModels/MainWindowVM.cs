using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EE3250_Assignment_1_3921.Models;
using EE3250_Assignment_1_3921.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace EE3250_Assignment_1_3921.ViewModels
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;

        [ObservableProperty]
        public Student selectedStudent;

        #region Constructor
        public MainWindowVM()
        {
            students = new ObservableCollection<Student>();

            Students.Add(new Student("EG/2020/0001", new BitmapImage(new Uri("/Img/1.png", UriKind.Relative)), "Caden", "Conrad", "Male", new DateOnly(2000, 9, 21), "0212387164", 2.8));
            Students.Add(new Student("EG/2020/0002", new BitmapImage(new Uri("/Img/2.png", UriKind.Relative)), "Steve", "Hodges", "Male", new DateOnly(1998, 4, 13), "0896222572", 3.4));
            Students.Add(new Student("EG/2020/0003", new BitmapImage(new Uri("/Img/6.png", UriKind.Relative)), "Paula", "Stevens", "Female", new DateOnly(1999, 3, 17), "0152150837", 1.8));
            Students.Add(new Student("EG/2020/0004", new BitmapImage(new Uri("/Img/4.png", UriKind.Relative)), "Valentina", "Vargas", "Female", new DateOnly(2000, 7, 8), "0928827292", 2.3));
            Students.Add(new Student("EG/2020/0005", new BitmapImage(new Uri("/Img/5.png", UriKind.Relative)), "Miguel", "Guerrero", "Male", new DateOnly(1999, 6, 3), "0233577839", 3.7));

            Students.Add(new Student("EG/2020/0006", new BitmapImage(new Uri("/Img/1.png", UriKind.Relative)), "Caden", "Conrad", "Male", new DateOnly(2000, 9, 21), "0212387164", 2.8));
            Students.Add(new Student("EG/2020/0007", new BitmapImage(new Uri("/Img/2.png", UriKind.Relative)), "Steve", "Hodges", "Male", new DateOnly(1998, 4, 13), "0896222572", 3.4));
            Students.Add(new Student("EG/2020/0008", new BitmapImage(new Uri("/Img/6.png", UriKind.Relative)), "Paula", "Stevens", "Female", new DateOnly(1999, 3, 17), "0152150837", 1.8));
            Students.Add(new Student("EG/2020/0009", new BitmapImage(new Uri("/Img/4.png", UriKind.Relative)), "Valentina", "Vargas", "Female", new DateOnly(2000, 7, 8), "0928827292", 2.3));
            Students.Add(new Student("EG/2020/00015", new BitmapImage(new Uri("/Img/5.png", UriKind.Relative)), "Miguel", "Guerrero", "Male", new DateOnly(1999, 6, 3), "0233577839", 3.7));
            Students.Add(new Student("EG/2020/00011", new BitmapImage(new Uri("/Img/1.png", UriKind.Relative)), "Caden", "Conrad", "Male", new DateOnly(2000, 9, 21), "0212387164", 2.8));
            Students.Add(new Student("EG/2020/00012", new BitmapImage(new Uri("/Img/2.png", UriKind.Relative)), "Steve", "Hodges", "Male", new DateOnly(1998, 4, 13), "0896222572", 3.4));
            Students.Add(new Student("EG/2020/00013", new BitmapImage(new Uri("/Img/6.png", UriKind.Relative)), "Paula", "Stevens", "Female", new DateOnly(1999, 3, 17), "0152150837", 1.8));
            Students.Add(new Student("EG/2020/00014", new BitmapImage(new Uri("/Img/4.png", UriKind.Relative)), "Valentina", "Vargas", "Female", new DateOnly(2000, 7, 8), "0928827292", 2.3));
            Students.Add(new Student("EG/2020/00025", new BitmapImage(new Uri("/Img/5.png", UriKind.Relative)), "Miguel", "Guerrero", "Male", new DateOnly(1999, 6, 3), "0233577839", 3.7));
            Students.Add(new Student("EG/2020/00021", new BitmapImage(new Uri("/Img/1.png", UriKind.Relative)), "Caden", "Conrad", "Male", new DateOnly(2000, 9, 21), "0212387164", 2.8));
            Students.Add(new Student("EG/2020/00022", new BitmapImage(new Uri("/Img/2.png", UriKind.Relative)), "Steve", "Hodges", "Male", new DateOnly(1998, 4, 13), "0896222572", 3.4));
            Students.Add(new Student("EG/2020/00023", new BitmapImage(new Uri("/Img/6.png", UriKind.Relative)), "Paula", "Stevens", "Female", new DateOnly(1999, 3, 17), "0152150837", 1.8));
            Students.Add(new Student("EG/2020/00024", new BitmapImage(new Uri("/Img/4.png", UriKind.Relative)), "Valentina", "Vargas", "Female", new DateOnly(2000, 7, 8), "0928827292", 2.3));
            Students.Add(new Student("EG/2020/00025", new BitmapImage(new Uri("/Img/5.png", UriKind.Relative)), "Miguel", "Guerrero", "Male", new DateOnly(1999, 6, 3), "0233577839", 3.7));

        }
        #endregion

        //This Function is for close whole program
        #region Close program function
        [RelayCommand]
        public static void CloseProgram()
        {
            var result = MessageBox.Show("Do you really want to exit ? ", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                Application.Current.MainWindow.Close();
        }
        #endregion

        //Logic for Add student to the list
        #region Add Student Function
        [RelayCommand]
        public void AddStudent()
        {
            var viewmodel = new AddEditStudentWindowVM();
            var window = new AddEditStudentWindow { DataContext = viewmodel };

            if (window.ShowDialog() == true)
            {
                var student = new Student
                {
                    FirstName = viewmodel.FirstName,
                    LastName = viewmodel.LastName,
                    Image = viewmodel.Image,
                    Id = viewmodel.Id,
                    Gender = viewmodel.Gender,
                    Telephone = viewmodel.Telephone,
                    DateOfBirth = viewmodel.DateOfBirth,
                    GPA = viewmodel.GPA,
                };

                if (student.FirstName != null && student.LastName != null && student.Image != null)
                {
                    Students.Add(student);
                }
            }
        }
        #endregion

        //Logic for Edit student to the list
        #region Edit Student Function
        [RelayCommand]
        public void EditStudent()
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("Select the student", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                var viewModel = new AddEditStudentWindowVM
                {
                    FirstName = SelectedStudent.FirstName,
                    LastName = SelectedStudent.LastName,
                    Image = SelectedStudent.Image,
                    Id = SelectedStudent.Id,
                    Gender = SelectedStudent.Gender,
                    Telephone = SelectedStudent.Telephone,
                    GPA = SelectedStudent.GPA,
                    DateOfBirth = SelectedStudent.DateOfBirth,
                };

                var window = new AddEditStudentWindow { DataContext = viewModel };
                if (window.ShowDialog() == true)
                {
                    SelectedStudent.FirstName = viewModel.FirstName;
                    SelectedStudent.LastName = viewModel.LastName;
                    SelectedStudent.Image = viewModel.Image;
                    SelectedStudent.Id = viewModel.Id;
                    SelectedStudent.Gender = viewModel.Gender;
                    SelectedStudent.Telephone = viewModel.Telephone;
                    SelectedStudent.GPA = viewModel.GPA;
                    SelectedStudent.DateOfBirth = viewModel.DateOfBirth;

                    Students = new ObservableCollection<Student>(Students);
                }
            }
        }
        #endregion

        //Logic for Delete student to the list
        #region Delete Student Function
        [RelayCommand]
        public void DeleteStudent()
        {
            if (Students.Count == 0)
            {
                MessageBox.Show("Student List is empty.", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (SelectedStudent == null)
            {
                MessageBox.Show("Select the student.", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                var dialogResult = MessageBox.Show($"Do you want to delete {SelectedStudent.FirstName} ?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (dialogResult == MessageBoxResult.Yes)
                    Students.Remove(SelectedStudent);
            }
        } 
        #endregion
    }
}
