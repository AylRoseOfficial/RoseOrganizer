using System;
using Microsoft.Win32;
using System.Windows;
using System.IO;
using System.Text.RegularExpressions;
using RoseOrganizer.ViewModel;
using System.Windows.Media.Imaging;

namespace RoseOrganizer.Views {
    public partial class MainWindow : Window {

        // Public Instance of Object
        public static MainWindow Instancia;

        // Main Variables (Global)
        public MainViewModel mainViewModel = new MainViewModel();
        public OpenFileDialog FileDialog = new OpenFileDialog();

        // Initialize Prompts of the Program
        public MainWindow() {
            // Instance and Init
            Instancia = this; 
            InitializeComponent();
           
            this.DataContext = mainViewModel;

            // Create Main Pages
            PGallery.Navigate(new System.Uri("Pages/GalleryPage.xaml", UriKind.RelativeOrAbsolute));
            HomePage.Navigate(new System.Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));        

            // Set User Preferences
            SetUserProfileImage();
        }

        /// Pages Functions
        private void rdHome_Click(object sender, RoutedEventArgs e) {
            // Set it Hidden
            AboutPage.Visibility = Visibility.Hidden;
            PGallery.Visibility = Visibility.Hidden;

            // Show new Page
            HomePage.Visibility = Visibility.Visible;
            HomePage.Navigate(new System.Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void rdGallery_Click(object sender, RoutedEventArgs e) {
            // Set it Hidden
            AboutPage.Visibility = Visibility.Hidden;
            HomePage.Visibility = Visibility.Hidden;

            // Show new Page
            PGallery.Visibility = Visibility.Visible;
            PGallery.Navigate(new System.Uri("Pages/GalleryPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void rdAbout_Click(object sender, RoutedEventArgs e) {
            // Set it Hidden
            HomePage.Visibility = Visibility.Hidden;
            PGallery.Visibility = Visibility.Hidden;

            // Show new Page
            AboutPage.Visibility = Visibility.Visible;
            AboutPage.Navigate(new System.Uri("Pages/AboutPage.xaml", UriKind.RelativeOrAbsolute));
        }

        /// Other events featured
        // Event - "Change user profile image"
        private void Profile_MouseClick(object sender, RoutedEventArgs e) {
            // Init of File Dialog
            FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            FileDialog.Filter = "Media Documents |*.img;*.png;*.jpeg;*.jpg";
            FileDialog.FilterIndex = 2; FileDialog.DefaultExt = ".png";

            // Show File Dialog
            if (FileDialog.ShowDialog() == true) {
                // Set FileName & New File Path 
                var FileName = FileDialog.FileName;
                var NewFilePath = GetUniqueFilePath(FileName);

                // Copy new image to save data folder
                File.Copy(FileName, NewFilePath);

                // Save image in user preferences
                Properties.Settings.Default.ProfileImage = NewFilePath;
                Properties.Settings.Default.Save();

                // Change image of user to new one
                ProfilePicture.ImageSource = new BitmapImage(new Uri(NewFilePath));
            }
        }

        /// Functions Primary & Generals
        // Get unique path for user image
        public static string GetUniqueFilePath(string filePath) {
            if (File.Exists(filePath)) {
                var DirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string FolderPath = Path.Combine(DirectoryPath, "RoseOrganizer");
                string FileName = Path.GetFileNameWithoutExtension(filePath);
                string FileExtension = Path.GetExtension(filePath);
                int FileCount = 0;

                if (!Directory.Exists(FolderPath)) {
                    Directory.CreateDirectory(FolderPath);
                }

                Match regex = Regex.Match(FileName, @"^(.+) \((\d+)\)$");

                if (regex.Success) {
                    FileName = regex.Groups[1].Value;
                    FileCount = int.Parse(regex.Groups[2].Value);
                }

                do {
                    FileCount++;
                    string newFileName = $"{FileName} ({FileCount}){FileExtension}";
                    filePath = Path.Combine(FolderPath, newFileName);
                } while (File.Exists(filePath));
            }
            return filePath;
        }
        // Set image to user (default or added)
        public void SetUserProfileImage() {
            // Set or Get Image of User
            if (string.IsNullOrEmpty(Properties.Settings.Default.ProfileImage))
                ProfilePicture.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Avatars/Artwork_Example.png"));
            else
                ProfilePicture.ImageSource = new BitmapImage(new Uri(Properties.Settings.Default.ProfileImage));
        }
        // Temporal return for Image Data
        public string GetTempArtwork() {
            // Return temporal image when creating grid instance
            return AddAnime.Instancia.TempArtwork;
        }
    }
}
