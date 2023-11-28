using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RoseOrganizer.Pages
{
    public partial class GalleryGrid_Template : UserControl
    {
        public static GalleryGrid_Template Instance;

        // Holder Variables
        private string TP_Nombre;
        private string TP_Descripcion;
        private ImageSource TP_Artwork;

        // Public Variables Instance
        public string OriginalName {
            get { return TP_Nombre; }
            set { TP_Nombre = value; Data_Name.Text = value; }
        }
        public ImageSource Artwork {
            get { return TP_Artwork; }
            set { TP_Artwork = value; Data_Artwork.ImageSource = value; }
        }

        public GalleryGrid_Template(string nombre, ImageSource artwork) {
            /// Instancia & Init
            Instance = this;
            InitializeComponent();
            InitData(nombre, artwork);
        }

        public void InitData(string nombre, ImageSource artwork) {
            OriginalName = nombre;
            Artwork = artwork;
        }
    }
}
