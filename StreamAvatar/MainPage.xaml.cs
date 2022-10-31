using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using System.Numerics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StreamAvatar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(612, 381);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            //It's best to add all the images used and then flip which ones are active
        }

        //private void MoveCursor()
        //{
        //    Point pointerPosition = Windows.UI.Core.CoreWindow.GetForCurrentThread().PointerPosition;
            
        //    //assuming these 
        //    int swidth = horizontal;
        //    int sheight = vertical;

        //    xletter = 0;
        //    yletter = 0;
            

        //    float x = 0;
        //    float y = 0;
        //    //check if pointerpostion is null
        //    if (pointerPosition != null)
        //    {
        //        float fx = ((float)pointerPosition.X - xletter) / swidth;
        //        float fy = ((float)pointerPosition.Y - yletter) / sheight;
        //        if (fx > 1) { fx = 1; }
        //        if (fx < 0) { fx = 0; }
        //        if (fy < 0) { fy = 0; }
        //        if (fy > 1) { fy = 1; }
        //        x = -97 * fx + 44 * fy + 184;
        //        y = -76 * fx - 40 * fy + 324;
        //    }
        //}

        private void AddImage(object sender, TappedRoutedEventArgs e)
        {
            BitmapImage bimg = new BitmapImage(new Uri("ms-appx:///Assets/mousel.png"));
           
            Image img = new Image();
            img.Height = 50;
            img.Width = 50;
            img.Source = bimg;
            img.PointerMoved += MoveImage;

            Canvas.SetLeft(img, e.GetPosition(imageArea).X - img.Width / 2);
            Canvas.SetTop(img, e.GetPosition(imageArea).Y - img.Height / 2);
            imageArea.Children.Add(img);
        }

        private void MoveImage(object sender, PointerRoutedEventArgs e)
        {
            Point cursorPosition = Windows.UI.Core.CoreWindow.GetForCurrentThread().PointerPosition;
            Vector3 cursorInWindow = new Vector3((float)(cursorPosition.X - Window.Current.Bounds.X), (float)(cursorPosition.Y - Window.Current.Bounds.Y), 0);
            ((Image) sender).Translation = cursorInWindow;
        }
    }
}
