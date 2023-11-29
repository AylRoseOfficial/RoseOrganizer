﻿using System;
using System.Windows.Media.Imaging;

namespace RoseOrganizer.Functions {
    public class ImageConverter {

        // Function Converter (Text to ImageSource)
        public static BitmapImage Convert(string value) {
            if (value is string) {
                string str = (string) value;
                return new BitmapImage(new Uri(str, UriKind.RelativeOrAbsolute));
            } return null;
        }
    }
}
