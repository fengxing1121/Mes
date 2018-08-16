using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtWorks.QRCode.Codec;

namespace Mes.Package.Common
{
    public static class CommonView
    {
        public static byte[] get2DBarcode(string barcode)
        {
            try
            {
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                b.BackColor = System.Drawing.Color.White;//图片背景颜色
                b.ForeColor = System.Drawing.Color.Black;//条码颜色
                b.IncludeLabel = true;
                b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
                b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;//code的显示位置
                b.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;//图片格式
                System.Drawing.Font font = new System.Drawing.Font("verdana", 16f);//字体设置
                b.LabelFont = font;
                b.Height = 80;//图片高度设置(px单位)
                b.Width = 400;//图片宽度设置(px单位)
                b.Encode(BarcodeLib.TYPE.CODE128, barcode);//生成图片                        
                byte[] imgData = b.GetImageData(BarcodeLib.SaveTypes.PNG);
                return imgData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static byte[] getQRcode(string qrcode)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 4;
            qrCodeEncoder.QRCodeVersion = 3;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            System.Drawing.Image image = qrCodeEncoder.Encode(qrcode);
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                else if (format.Equals(ImageFormat.Png))
                {
                    image.Save(ms, ImageFormat.Png);
                }
                else if (format.Equals(ImageFormat.Bmp))
                {
                    image.Save(ms, ImageFormat.Bmp);
                }
                else if (format.Equals(ImageFormat.Gif))
                {
                    image.Save(ms, ImageFormat.Gif);
                }
                else if (format.Equals(ImageFormat.Icon))
                {
                    image.Save(ms, ImageFormat.Icon);
                }
                else
                {
                    image.Save(ms, ImageFormat.Png);
                }
                byte[] buffer = new byte[ms.Length];
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }
        public static byte[] getLogoFile(string LogoFile)
        {
            if (!File.Exists(LogoFile))
            {
                return null;
            }
            using (System.Drawing.Image img = Bitmap.FromFile(LogoFile))
            {
                ImageFormat format = img.RawFormat;
                using (MemoryStream ms = new MemoryStream())
                {
                    if (format.Equals(ImageFormat.Jpeg))
                    {
                        img.Save(ms, ImageFormat.Jpeg);
                    }
                    else if (format.Equals(ImageFormat.Png))
                    {
                        img.Save(ms, ImageFormat.Png);
                    }
                    else if (format.Equals(ImageFormat.Bmp))
                    {
                        img.Save(ms, ImageFormat.Bmp);
                    }
                    else if (format.Equals(ImageFormat.Gif))
                    {
                        img.Save(ms, ImageFormat.Gif);
                    }
                    else if (format.Equals(ImageFormat.Icon))
                    {
                        img.Save(ms, ImageFormat.Icon);
                    }
                    else
                    {
                        img.Save(ms, ImageFormat.Png);
                    }
                    byte[] buffer = new byte[ms.Length];
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Read(buffer, 0, buffer.Length);
                    return buffer;
                }
            }
        }
    }
}
