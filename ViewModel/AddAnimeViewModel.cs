using System;
using System.Windows.Input;
using RoseOrganizer.Commands;
using RoseOrganizer.Functions;
using RoseOrganizer.Models;
using RoseOrganizer.Pages;
using RoseOrganizer.Views;

namespace RoseOrganizer.ViewModel
{
    public class AddAnimeViewModel {

        // ICommand Instances
        public ICommand AddAnimeCommand { get; set; }

        // AddAnime Bool
        private bool CanAddAnime(object obj) { return true; }

        // Main Variables of Instance
        public string Image { get; set; }
        public string Name { get; set; }

        // Main Anime View Model Init
        public AddAnimeViewModel() {
            // Create command for add anime entry
            AddAnimeCommand = new RelayCommand(AddEntryAnime, CanAddAnime);
        }

        // Add Anime Entry to Data 
        public void AddEntryAnime(object obj) {    

            // String Source returned by FileDialog
            Image = MainWindow.Instancia.GetTempArtwork();

            // Add element to database (main anime list)
            AnimeManager.AddAnime(new Anime() { Name = Name, Image = Image });

            // Add element to the database grid (secundary item list)
            var image = ImageConverter.Convert(Image);
            var template = new GalleryGrid_Template(Name, image);

            // Create element in grid using the data obtained
            GalleryPage.Instancia.GalleryGrid.Items.Add(template);

            // HomePage Variables
            var CurrentDate = GetCurrentDateFormatted();
            var AnimesCount = MainViewModel.Instancia.Animes.Count.ToString();

            // Set new info to Home Page
            HomePage.Instancia.ChangeData(image, Name, CurrentDate, AnimesCount + " Entries Found");

            // Close Instance of Entry Anime
            AddAnime.Instancia.Close();
        }

        // Get Current Date Time (D/M/Y)
        private string GetCurrentDateFormatted() {
            DateTime currentDate = DateTime.Now;
            return currentDate.ToString("dd/MM/yyyy");
        }
    }
}
