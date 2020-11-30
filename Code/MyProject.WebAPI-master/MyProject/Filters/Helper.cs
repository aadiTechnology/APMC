using Microsoft.AspNetCore.Identity;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Filters
{
    public sealed class Helper
    {
        protected static Random random = new Random();

        public Helper()
        {
        }
        public byte[] GenerateQRCode(string txtQRCode)
        {
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(txtQRCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            byte[] array = BitmapToBytesCode(qrCodeImage);
            File.WriteAllBytes("E:\\BillTrax\\Qr Code Scanner Project\\GeneratedQRCode\\Production QR Codes\\Bethune Biller Support QR Code.png", array);
            return array;
        }
        private Byte[] BitmapToBytesCode(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string GenerateExceptionLogMessage(Exception ex)
        {
            var message = new StringBuilder();
            message.AppendLine(ex.Message);
            message.AppendLine(ex.StackTrace);
            message.AppendLine(ex.ToString());

            if (ex.InnerException != null)
            {
                message.AppendLine("Inner Exception");
                message.AppendLine(ex.InnerException.Message);
                message.AppendLine(ex.InnerException.StackTrace);

                if (ex.InnerException.InnerException != null)
                {
                    message.AppendLine("Second Level Inner Exception");
                    message.AppendLine(ex.InnerException.InnerException.Message);
                    message.AppendLine(ex.InnerException.InnerException.StackTrace);
                }
            }
            return message.ToString();
        }
    }
}
