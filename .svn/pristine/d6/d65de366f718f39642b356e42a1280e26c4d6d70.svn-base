using Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace AI070.Helpers
{
    /// <summary>
    /// Utility
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Get installed printer
        /// </summary>
        /// <returns>Collection of printer name</returns>
        public static ICollection<string> GetInstalledPrinters()
        {
            var installedPrinters = new List<string>();

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                installedPrinters.Add(printer);
            }

            return installedPrinters;
        }
        public static void DeleteFile(string filename)
        {
            if (System.IO.File.Exists(filename))
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                System.IO.File.Delete(filename);
            }
        }

        /// <summary>
        /// Get default printer
        /// </summary>
        /// <returns>Default printer name</returns>
        public static string GetDefaultPrinter()
        {
            var defaultPrinter = string.Empty;

            var setting = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                setting.PrinterName = printer;
                if (setting.IsDefaultPrinter)
                {
                    defaultPrinter = printer;
                    break;
                }
            }

            return defaultPrinter;
        }

        /// <summary>
        /// Get printer by name
        /// </summary>
        /// <param name="printerName">Printer name</param>
        /// <returns>Find pronter result or default printer</returns>
        public static string GetPrinterByName(string printerName)
        {
            var result = string.Empty;

            var setting = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                if (printer.Equals(printerName, StringComparison.InvariantCultureIgnoreCase))
                {
                    result = printer;
                    break;
                }
            }

            if (string.IsNullOrWhiteSpace(result)) result = GetDefaultPrinter();

            return result;
        }
        public static bool CheckExistPrinterByName(string printerName)
        {
            bool result = false;

            var setting = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                if (printer.Equals(printerName, StringComparison.InvariantCultureIgnoreCase))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        //print from base64/svg
        public static bool PrintImage(string base64ImageString, string printerName, PaperKind paperSize, bool isLandscape, out string messages)
        {
            bool isExist = CheckExistPrinterByName(printerName);
            if (isExist)
            {
                try
                {
                    //printerName = GetPrinterByName(printerName);
                    //if (!isLandscape.HasValue) isLandscape = false;

                    //enable if want generate image
                    //var filename = string.Format("E://test_{0}.png", DateTime.Now.Ticks);

                    PrintDocument pd = new PrintDocument();
                    pd.PrinterSettings.PrinterName = printerName;
                    //pd.PrinterSettings.PrintFileName = filename;

                    //var ps = new PrinterSettings();
                    //IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
                    //var size = paperSizes.First<PaperSize>(d => d.Kind == paperSize);
                    //pd.DefaultPageSettings.PaperSize = paper;

                    PaperSize paperA3 = new PaperSize();
                    paperA3.Width = 1169;
                    paperA3.Height = 1654;
                    paperA3.PaperName = "A3";


                    PaperSize paperA4 = new PaperSize();
                    paperA4.Width = 827;
                    paperA4.Height = 1169;
                    paperA4.PaperName = "A4";
                    
                    if (paperSize == PaperKind.A3)
                        pd.DefaultPageSettings.PaperSize = paperA3;
                    else
                        pd.DefaultPageSettings.PaperSize = paperA4;

                    Margins margins = new Margins(25, 25, 25, 25);
                    pd.DefaultPageSettings.Margins = margins;
                    pd.DefaultPageSettings.Landscape = isLandscape;
                    pd.PrintPage += (sender, args) =>
                    {
                        Image i = Base64ToImage(base64ImageString);

                        Rectangle m = args.MarginBounds;
                        args.Graphics.DrawImage(i, args.MarginBounds);
                        //enable if want generate image
                        //i.Save(filename, ImageFormat.Png);
                    };
                    pd.Print();
                }
                catch (Exception ex)
                {
                    messages = ex.Message;
                    return false;
                }
            }
            else
            {
                messages = "Printer Not Available";
                return false;

            }
            messages = "Printed Successfully";
            return true;
        }
        public static bool PrintFromImage(string imagePath, out string messages, string printerName = null, PaperKind? paperSize = PaperKind.A4, bool? isLandscape = false)
        {
            bool isExist = CheckExistPrinterByName(printerName);
            if (isExist)
            {
                try
                {
                   

                    PrintDocument pd = new PrintDocument();
                    pd.PrinterSettings.PrinterName = printerName;
                    
                    pd.PrinterSettings.DefaultPageSettings.PrinterResolution = pd.PrinterSettings.PrinterResolutions[0];

                    //use installed printer setting papersize
                    var ps = new PrinterSettings();
                    ps.PrinterName = printerName;
                    pd.PrinterSettings = ps;
                    IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
                    PaperSize size = paperSizes.First<PaperSize>(d => d.Kind == paperSize);
                    pd.DefaultPageSettings.PaperSize = size;

                    Margins margins = new Margins(20, 40, 20, 30); 
                    if (paperSize == PaperKind.A4)
                    {
                         margins = new Margins(5, 40, 10, 40);
                    }
                    
                    pd.DefaultPageSettings.Margins = margins;
                    pd.DefaultPageSettings.Landscape = isLandscape.Value;
                    pd.DefaultPageSettings.Color = false;
                    var fileIsGenerated = false;
                    while (!fileIsGenerated)
                    {
                        //System.Threading.Thread.Sleep(1000);
                        fileIsGenerated = System.IO.File.Exists(imagePath);
                    }
                    pd.PrintPage += (sender, args) =>
                    {
                        

                        Image newImage = new Bitmap(args.MarginBounds.Width, args.MarginBounds.Height);
                        using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                        {
                            using (Image original = Image.FromStream(fs))
                            {

                                using (Graphics gr = Graphics.FromImage(newImage))
                                {
                                    gr.SmoothingMode = SmoothingMode.HighQuality;
                                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                    gr.DrawImage(original, new Rectangle(0, 0, args.MarginBounds.Width, args.MarginBounds.Height));
                                }
                                args.Graphics.DrawImage(original, args.MarginBounds);
                            }
                        }
                        
                        //args.Graphics.DrawImage(newImage, args.MarginBounds);
                        //newImage.Dispose();
                    };
                    pd.Print();
                }
                catch (Exception ex)
                {
                    //if (!System.IO.File.Exists(imagePath))
                    //{
                    //    messages = "Image Not Available" + imagePath;
                    //}
                    //else
                    //{
                    //    messages = ex.Message;
                    //}
                    messages = ex.Message;
                    return false;
                }
            }
            else
            {
                messages = "Printer Not Available";
                return false;

            }
            //File.Delete(filename);
            messages = "Printed Successfully";
            return true;
        }
        public static Image CreateNonIndexedImage(string path)
        {
            using (var sourceImage = Image.FromFile(path))
            {
                var targetImage = new Bitmap(sourceImage.Width, sourceImage.Height,
                  PixelFormat.Format32bppArgb);
                using (var canvas = Graphics.FromImage(targetImage))
                {
                    canvas.DrawImageUnscaled(sourceImage, 0, 0);
                }
                return targetImage;
            }
        }

        [DllImport("Kernel32.dll", EntryPoint = "CopyMemory")]
        private extern static void CopyMemory(IntPtr dest, IntPtr src, uint length);

        public static Image CreateIndexedImage(string path)
        {
            using (var sourceImage = (Bitmap)Image.FromFile(path))
            {
                var targetImage = new Bitmap(sourceImage.Width, sourceImage.Height,
                  sourceImage.PixelFormat);
                var sourceData = sourceImage.LockBits(
                  new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                  ImageLockMode.ReadOnly, sourceImage.PixelFormat);
                var targetData = targetImage.LockBits(
                  new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                  ImageLockMode.WriteOnly, targetImage.PixelFormat);
                CopyMemory(targetData.Scan0, sourceData.Scan0,
                  (uint)sourceData.Stride * (uint)sourceData.Height);
                sourceImage.UnlockBits(sourceData);
                targetImage.UnlockBits(targetData);
                //targetImage.Palette = sourceImage.Palette;
                return targetImage;
            }
        }
        /// <summary>
        /// Image to base 64 string
        /// </summary>
        /// <param name="image">Image to be converted</param>
        /// <param name="format">Image format</param>
        /// <returns>base 64 string image</returns>
        public static string ImageToBase64(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        /// <summary>
        /// base 64 string to image
        /// </summary>
        /// <param name="base64String">Base 64 string image</param>
        /// <returns>Image result</returns>
        public static Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        /// <summary>
        /// Convert svg string to png image
        /// </summary>
        /// <param name="svgString">Svg string</param>
        /// <param name="filename">Filename</param>
        /// <returns>Convertion result</returns>
        public static bool SvgToImage(string svgString, string filename = null)
        {
            ///var strSVG = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\" version=\"1.1\">   <rect width=\"200\" height=\"100\" stroke=\"black\" stroke-width=\"6\" fill=\"green\"/></svg>";
            ////var strSVG = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"1000\" height=\"1000\" version=\"1.1\">   <rect width=\"200\" height=\"100\" stroke=\"black\" stroke-width=\"6\" fill=\"green\"/><rect width=\"30\" height=\"30\" stroke=\"orange\" stroke-width=\"2\" fill=\"red\"/><ellipse cx=\"210\" cy=\"45\" rx=\"170\" ry=\"15\" style=\"fill:yellow\"/></svg>";
            //var strSVG = "<svg style=\"overflow: hidden; position: relative;\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"1082\" version=\"1.1\" height=\"365\"><rect transform=\"matrix(1,0,0,1,0,0)\" x=\"50\" y=\"50\" width=\"200\" height=\"300\" rx=\"0\" ry=\"0\" fill=\"white\" stroke=\"red\" opacity=\"1\" stroke-width=\"3\"></rect><circle transform=\"matrix(1,0,0,1,0,0)\" cx=\"75\" cy=\"75\" r=\"50\" fill=\"white\" stroke=\"red\" opacity=\"1\" stroke-width=\"3\"></circle><text transform=\"matrix(1,0,0,1,0,0)\" style=\"text-anchor: middle; font: normal normal normal 48px/normal 10px &quot;Arial&quot;;\" x=\"150\" y=\"75\" text-anchor=\"middle\" font=\"10px &quot;Arial&quot;\" stroke=\"none\" fill=\"red\" opacity=\"1\" font-size=\"48px\"><tspan dy=\"-11.63076923076923\">sample</tspan></text>,<text transform=\"matrix(1,0,0,1,0,0)\" style=\"text-anchor: middle; font: normal normal normal 48px/normal 10px &quot;Arial&quot;;\" x=\"150\" y=\"75\" text-anchor=\"middle\" font=\"10px &quot;Arial&quot;\" stroke=\"none\" fill=\"red\" opacity=\"1\" font-size=\"48px\"><tspan dy=\"46.52307692307693\">text</tspan></text><path transform=\"matrix(1,0,0,1,0,0)\" fill=\"black\" stroke=\"red\" d=\"M50,50L200,150\" opacity=\"1\" stroke-width=\"3\"></path></svg>";

            if (string.IsNullOrWhiteSpace(filename)) filename = string.Format("C://temp//test_{0}.png", DateTime.Now.Ticks);
            var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(svgString));
            var svg = SvgDocument.Open(stream);
            svg.Draw().Save(filename, ImageFormat.Png);

            return true;
        }
    }
}