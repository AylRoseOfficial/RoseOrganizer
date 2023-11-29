using System.Windows.Controls;
using System.Windows.Media;

namespace RoseOrganizer.Pages {
    public partial class GalleryGrid_Template : UserControl {

        // Public Instance of Object
        public static GalleryGrid_Template Instance;

        // Holder Variables
        private string TP_Name;
        private ImageSource TP_Artwork;

        // Public Variables Instance
        public string OriginalName { get { return TP_Name; } set { TP_Name = value; Data_Name.Text = value; }}
        public ImageSource Artwork { get { return TP_Artwork; } set { TP_Artwork = value; Data_Artwork.ImageSource = value; }}

        // Init User Control Event
        public GalleryGrid_Template(string nombre, ImageSource artwork) {
            /// Instancia & Init
            Instance = this;
            InitializeComponent();

            InitData(nombre, artwork);
        }

        // Init Data Function
        public void InitData(string nombre, ImageSource artwork) {
            OriginalName = nombre; Artwork = artwork;
        }
    }
}
