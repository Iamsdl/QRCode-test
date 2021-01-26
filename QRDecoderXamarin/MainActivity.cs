using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using ZXing.Mobile;

namespace QRDecoderXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button scanButton = FindViewById<Button>(Resource.Id.button1);
            TextView text = FindViewById<TextView>(Resource.Id.textView1);
            scanButton.Click += async (sender, e) =>
            {
#if __ANDROID__
                MobileBarcodeScanner.Initialize(Application);
#endif
                var scanner = new MobileBarcodeScanner();
                var result = await scanner.Scan();
                if (result != null)
                    text.Text = result.Text;

            };
        }
    }
}

