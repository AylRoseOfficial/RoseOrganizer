using System.Collections.ObjectModel;
using System.Windows.Input;
using RoseOrganizer.Commands;
using RoseOrganizer.Models;
using RoseOrganizer.Pages;
using RoseOrganizer.Views;

namespace RoseOrganizer.ViewModel
{
    public class MainViewModel {
        public static MainViewModel Instancia;
        // ICommand Instances
        public ICommand ShowWindowCommand { get; set; }

        // Main Anime Collection Array
        public ObservableCollection<Anime> Animes { get; set; }
        // Secundary Template Grid Array
        public ObservableCollection<GalleryGrid_Template> Templates { get; set; }

        public MainViewModel() {
            Instancia = this;
            /// Return data from database for anime (AnimeManager)
            Animes = AnimeManager.GetAnimes();
            /// New Entry Window Command
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }
        private bool CanShowWindow(object obj) {
            return true;
        }
        private void ShowWindow(object obj) {
            AddAnime addAnimeWin = new AddAnime();
            addAnimeWin.Show();
        }
    }
}
