using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace EE3250_Assignment_1_3921.ViewModels
{
    public partial class AddEditStudentWindowVM : ObservableObject
    {
        public string Id { get; set; }
        public BitmapImage Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //This collection is for ComboBox Item Source
        public ObservableCollection<string> GenderItems { get; set; } = new ObservableCollection<string> {"-Select Your Gender-", "Male", "Female"};
        public string Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Telephone { get; set; }
        public double GPA { get; set; }

        #region Default Constructor
        public AddEditStudentWindowVM()
        {
            Gender = "-Select Your Gender-";
        } 
        #endregion

        //This function is used to upload the image of the student
        #region Photo Upload Button Function
        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == true)
            {
                Image = new BitmapImage(new Uri(openFileDialog.FileName));
                MessageBox.Show("Image Uploaded Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion


        //This function is used to Validate the data of New student or Edit student
        #region Save Button Function
        [RelayCommand]
        public void Save()
        {
            if (Image == null)
            {
                MessageBox.Show("Upload the photo", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(Telephone))
            {
                MessageBox.Show("Fill all the Fields", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!(Gender == "Male" || Gender == "Female"))
            {
                MessageBox.Show("Select your Gender", "Invalid Gender", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (Telephone.Length != 10)
            {
                MessageBox.Show("Contact Number should have 10 integers.", "Invalid Contact Number", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (GPA > 4 || GPA < 0)
            {
                MessageBox.Show("GPA should be between 0 and 4.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Student saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            CloseWindow();
        }
        #endregion

        //This function is used to close the AddEditStudent Window
        #region Cancel Button Function
        [RelayCommand]
        public void Cancel()
        {
            CloseWindow();
        }

        private void CloseWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.DialogResult = true;
                    window.Close();
                }
            }
        } 
        #endregion
    }
}
