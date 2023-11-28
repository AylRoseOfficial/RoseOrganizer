using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using RoseOrganizer.Functions;
using RoseOrganizer.ViewModel;

namespace RoseOrganizer.Views {

    public partial class AddAnime : Window {

        // Main Variables (Globals)
        public string TempArtwork;
        public static AddAnime Instancia;

        /// Main Init
        public AddAnime() {
            /// Get View Model Data
            AddAnimeViewModel mainViewModel = new AddAnimeViewModel();
            this.DataContext = mainViewModel;

            Instancia = this;
            InitializeComponent();

            /// Get Default Image
            var Source = "pack://application:,,,/Assets/Avatars/Artwork_Example.png";
            var Image = ImageConverter.Convert(Source); A_Portada.Source = Image;
        }

        /// MouseDown Event
        private void A_Portada_MouseDown(object sender, MouseButtonEventArgs e) {
            var FileDialog = MainWindow.Instancia.FileDialog;
            FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            FileDialog.Filter = "Media Documents |*.img;*.png;*.jpeg;*.jpg";
            FileDialog.FilterIndex = 2; FileDialog.DefaultExt = ".png";

            /// Show Dialog for Select the Image
            if (FileDialog.ShowDialog() == true) {
                var Artwork = new BitmapImage(new Uri(FileDialog.FileName));

                TempArtwork = Artwork.ToString();
                A_Portada.Source = Artwork;
            }
        }
    }
}
