using System;
using Microsoft.Win32;
using System.Windows;
using System.IO;
using System.Text.RegularExpressions;
using RoseOrganizer.ViewModel;
using System.Windows.Media.Imaging;

namespace RoseOrganizer.Views {
    public partial class MainWindow : Window {

        // Main Variables (Global)
        public static MainWindow Instancia;
        public MainViewModel mainViewModel = new MainViewModel();
        public OpenFileDialog FileDialog = new OpenFileDialog();

        /// Initialize Prompts of the Program
        public MainWindow() {
            // Instancia & Init de Programa 
            Instancia = this; 
            InitializeComponent();
           
            this.DataContext = mainViewModel;

            // Pagina de Inicio (Crear)
            PGallery.Navigate(new System.Uri("Pages/GalleryPage.xaml", UriKind.RelativeOrAbsolute));
            HomePage.Navigate(new System.Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));        

            // Init Propiedas de Programa Principal
            SetUserProfileImage();
        }

        /// Pages Functions
        private void rdHome_Click(object sender, RoutedEventArgs e) {
            // Colocar en Hidden
            AboutPage.Visibility = Visibility.Hidden;
            PGallery.Visibility = Visibility.Hidden;

            // Enseñar Nueva Pagina
            HomePage.Visibility = Visibility.Visible;
            HomePage.Navigate(new System.Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void rdGallery_Click(object sender, RoutedEventArgs e) {
            // Colocar en Hidden
            AboutPage.Visibility = Visibility.Hidden;
            HomePage.Visibility = Visibility.Hidden;

            // Enseñar Nueva Pagina
            PGallery.Visibility = Visibility.Visible;
            PGallery.Navigate(new System.Uri("Pages/GalleryPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void rdAbout_Click(object sender, RoutedEventArgs e) {
            // Colocar en Hidden
            HomePage.Visibility = Visibility.Hidden;
            PGallery.Visibility = Visibility.Hidden;

            // Enseñar Nueva Pagina
            AboutPage.Visibility = Visibility.Visible;
            AboutPage.Navigate(new System.Uri("Pages/AboutPage.xaml", UriKind.RelativeOrAbsolute));
        }

        /// Other events featured
        // Event "Change user profile image"
        private void Profile_MouseClick(object sender, RoutedEventArgs e) {
            /// Init de File Dialog
            FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            FileDialog.Filter = "Media Documents |*.img;*.png;*.jpeg;*.jpg";
            FileDialog.FilterIndex = 2; FileDialog.DefaultExt = ".png";

            /// Mostrar File Dialog
            if (FileDialog.ShowDialog() == true) {
                /// Set FileName & New File Path 
                var FileName = FileDialog.FileName;
                var NewFilePath = GetUniqueFilePath(FileName);

                /// Copiar Documento a Carpeta Especial
                File.Copy(FileName, NewFilePath);

                /// Guardar nueva imagen en cache settings
                Properties.Settings.Default.ProfileImage = NewFilePath;
                Properties.Settings.Default.Save();

                /// Cambiar imagen de perfil a la nueva
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
            /// Poner Imagen Default o Guardada
            if (string.IsNullOrEmpty(Properties.Settings.Default.ProfileImage))
                ProfilePicture.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Avatars/Artwork_Example.png"));
            else
                ProfilePicture.ImageSource = new BitmapImage(new Uri(Properties.Settings.Default.ProfileImage));
        }
        // Return temporal image data
        public string GetTempArtwork() {
            /// Retornar la imagen temporal al crear grid
            return AddAnime.Instancia.TempArtwork;
        }
    }
}
