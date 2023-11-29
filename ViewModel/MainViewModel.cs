using System.Collections.ObjectModel;
using System.Windows.Input;
using RoseOrganizer.Commands;
using RoseOrganizer.Models;
using RoseOrganizer.Pages;
using RoseOrganizer.Views;

namespace RoseOrganizer.ViewModel {
    public class MainViewModel {
        
        // Public Instance of Object
        public static MainViewModel Instancia;

        // ICommand Functions
        public ICommand ShowWindowCommand { get; set; }

        // Bool Show Window
        private bool CanShowWindow(object obj) { return true; }

        // Primary Anime - Collection Array
        public ObservableCollection<Anime> Animes { get; set; }

        // Secundary Anime - Template Grid Array
        public ObservableCollection<GalleryGrid_Template> Templates { get; set; }

        public MainViewModel() {
            Instancia = this;

            // Return data from database for animes array
            Animes = AnimeManager.GetAnimes();
            // New Entry Window Command to Open
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        // Show Window Add Anime
        private void ShowWindow(object obj) {
            AddAnime addAnimeWin = new AddAnime();
            addAnimeWin.Show();
        }
    }
}
