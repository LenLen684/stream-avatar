using System;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using System.Numerics;
using Windows.UI.Core;

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
            //Application.Run(new ApplicationContext());

            //This only works for when the cursor passes over the window:
            //Window.Current.CoreWindow.PointerMoved += CoreWindowMoveImage;
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
            
            //Bugs the image adding
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
        
        private void CoreWindowMoveImage(CoreWindow sender, PointerEventArgs e)
        {
            Point cursorPosition = Windows.UI.Core.CoreWindow.GetForCurrentThread().PointerPosition;
            Vector3 cursorInWindow = new Vector3((float)(cursorPosition.X - Window.Current.Bounds.X), (float)(cursorPosition.Y - Window.Current.Bounds.Y), 0);


            mouseImage.Translation = cursorInWindow;
        }
    }
}
