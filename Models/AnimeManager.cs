using System.Collections.ObjectModel;

namespace RoseOrganizer.Models {
    internal class AnimeManager {

        // Get all entries from database main
        public static ObservableCollection<Anime> GetAnimes() { return _animesDatabase; }

        // Add new element to the database main
        public static void AddAnime(Anime anime) { _animesDatabase.Add(anime); }

        // Anime Collection (Main DataBase)
        public static ObservableCollection<Anime> _animesDatabase = new ObservableCollection<Anime>() {

         //new Anime() { Name= "Absolute Duo", Image="pack://application:,,,/Assets/Avatars/Artwork_Example.png"},
         //new Anime() { Name= "NEW GAME", Image="pack://application:,,,/Assets/Avatars/Artwork01.jpg"}

        };
    }
}
