using Spire.Barcode;
using System;
using System.Drawing;

namespace SpireBarcode
{
    class Program
    {
        static void Main(string[] args)
        {
            BarcodeSettings.ApplyKey("your key");
            BarcodeSettings barcodeSettings = new BarcodeSettings
            {
                AutoResize = true,
                Data2D = "alabala123",
                QRCodeDataMode = QRCodeDataMode.AlphaNumber,
                QRCodeECL = QRCodeECL.L,
                ForeColor = Color.Black,
                BackColor = Color.White,
                BorderWidth = 5,
                LeftMargin = 5,
                BottomMargin = 5,
                RightMargin = 5,
                TopMargin = 5,
                Type = BarCodeType.QRCode,
            };
            BarCodeGenerator barCodeGenerator = new BarCodeGenerator(barcodeSettings);
            var image = barCodeGenerator.GenerateImage(new Size(1000,1000));
            image.Save("../../qr.png");

            string[] decoded = BarcodeScanner.Scan("../../qr.png", BarCodeType.QRCode);
            
            Console.Read();

        }
    }
}
