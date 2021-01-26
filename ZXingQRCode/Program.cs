using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace ZXingQRCode
{
    class Program
    {
        static void Main(string[] args)
        {
            QRCodeWriter qRCodeWriter = new QRCodeWriter();
            string Contents = "https://play.google.com/store/apps/details?id=com.google.android.youtube&nbsp;ID=alabala";
            Dictionary<EncodeHintType, object> hints = new Dictionary<EncodeHintType, object>();
            hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);

            var bitmatrix = qRCodeWriter.encode(Contents, BarcodeFormat.QR_CODE, 1000, 1000, hints);
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            var bitmap = barcodeWriter.Write(bitmatrix);

            LuminanceSource source = new BitmapLuminanceSource(bitmap);
            var binBitmap = new BinaryBitmap(new HybridBinarizer(source));
            QRCodeReader reader = new QRCodeReader();
            BarcodeReader barcodeReader = new BarcodeReader();
            var result2=barcodeReader.Decode(bitmap).Text;
            string result = reader.decode(binBitmap).Text;


            bitmap.Save("../../qr.bmp");
            

        }
    }
}
