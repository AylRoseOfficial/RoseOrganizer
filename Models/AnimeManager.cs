using System.Collections.ObjectModel;

namespace RoseOrganizer.Models {
    internal class AnimeManager {

        /// Coleccion Raiz de Animes (Base de Datos)
        public static ObservableCollection<Anime> _animesDatabase = new ObservableCollection<Anime>() {
         new Anime() { Name= "Absolute Duo", Image="pack://application:,,,/Assets/Avatars/Artwork_Example.png"},
         new Anime() { Name= "NEW GAME", Image="pack://application:,,,/Assets/Avatars/Artwork01.jpg"}
        };

        /// Devolver datos de la base raiz
        public static ObservableCollection<Anime> GetAnimes() {
            return _animesDatabase;
        }

        /// Añadir objeto nuevo a la base de datos raiz
        public static void AddAnime(Anime anime) { 
          _animesDatabase.Add(anime);
        }
    }
}
