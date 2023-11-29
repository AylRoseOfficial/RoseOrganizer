using System;
using System.Windows.Controls;
using RoseOrganizer.Functions;
using RoseOrganizer.Views;

namespace RoseOrganizer.Pages {
    public partial class GalleryPage : Page {

        // Public Instance Of Object
        public static GalleryPage Instancia;

        // Main Gallery Page Init
        public GalleryPage() {
            InitializeComponent(); Instancia = this;
            this.DataContext = MainWindow.Instancia.DataContext;

            GridInstances();
        }

        // Grid Instances Add using UserControl
        public void GridInstances() {
            foreach (var anime in MainWindow.Instancia.mainViewModel.Animes) {
                var image = ImageConverter.Convert(anime.Image);
                var template = new GalleryGrid_Template(anime.Name, image);

                GalleryGrid.Items.Add(template);
            }
        }
    }
}
