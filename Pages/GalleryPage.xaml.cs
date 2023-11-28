using System;
using System.Windows.Controls;
using RoseOrganizer.Functions;
using RoseOrganizer.Views;

namespace RoseOrganizer.Pages {
    public partial class GalleryPage : Page
    {
        public static GalleryPage Instancia;
        public GalleryPage() {
            InitializeComponent();
            Instancia = this;
            this.DataContext = MainWindow.Instancia.DataContext;

            foreach (var anime in MainWindow.Instancia.mainViewModel.Animes)
            {
                var image = ImageConverter.Convert(anime.Image);
                var template = new GalleryGrid_Template(anime.Name, image);

                Console.WriteLine(template);
                GalleryGrid.Items.Add(template);
            }
        }
    }
}
