using System.Windows.Controls;
using System.Windows.Media;

namespace RoseOrganizer.Pages {

    public partial class HomePage : Page {
        public static HomePage Instancia;

        public HomePage() {
            InitializeComponent();
            Instancia = this;
        }

        public void ChangeData(ImageSource Img, string name, string date, string count) {
            Home_Artwork.Source = Img;
            Anime_HomeName.Content = name;
            Anime_HomeDate.Content = date;
            Anime_HomeCount.Content = count;
        }
    }
}
