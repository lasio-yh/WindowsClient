using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Net.Http;
using System.Threading;

namespace MnStudio.Constants
{
    // <summary>
    // Provides an attached property determining the current Bing image and assigning it to an image or imagebrush.
    // </summary>
    public static class BingImage
    {
        public static readonly DependencyProperty UseBingImageProperty = DependencyProperty.RegisterAttached("UseBingImage", typeof(bool), typeof(BingImage), new PropertyMetadata(OnUseBingImageChanged));

        private static BitmapImage cachedBingImage;
        private static void OnUseBingImageChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var newValue = (bool)e.NewValue;
            var image = o as Image;
            var imageBrush = o as ImageBrush;

            if (!newValue || (image == null && imageBrush == null))
                return;

            if (cachedBingImage == null)
            {
                var url = GetCurrentBingImageUrl();
                if (url != null)
                    cachedBingImage = new BitmapImage(url);
            }

            if (cachedBingImage != null)
            {
                if (image != null)
                    image.Source = cachedBingImage;
                else if (imageBrush != null)
                    imageBrush.ImageSource = cachedBingImage;
            }
        }

        private static Uri GetCurrentBingImageUrl()
        {
            var client = new HttpClient();
            var result = client.GetAsync("http://www.bing.com/hpimagearchive.aspx?format=xml&idx=0&n=2&mbl=1&mkt=en-ww");
            if (result.Result.IsSuccessStatusCode)
            {
                using (var stream = result.Result.Content.ReadAsStreamAsync())
                {
                    var doc = XDocument.Load(stream.Result);
                    var url = (string)doc.XPathSelectElement("/images/image/url");
                    return new Uri(string.Format(CultureInfo.InvariantCulture, "http://bing.com{0}", url), UriKind.Absolute);
                }
            }
            return null;
        }


        public static bool GetUseBingImage(DependencyObject o)
        {
            return (bool)o.GetValue(UseBingImageProperty);
        }

        public static void SetUseBingImage(DependencyObject o, bool value)
        {
            o.SetValue(UseBingImageProperty, value);
        }
    }
}
