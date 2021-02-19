using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _18896_FinalProject
{
    public class FileManager
    {
        //Variables to use in FormDecode.cs
        private static int currentLineNum = 0;
        private int lineCount;
        public static bool fileLoaded = false, canDelete = true;
        private string filePath = string.Empty, fileContent = string.Empty;
        private Stream fileStream;
        private string[] fileData;
        //

        string liveFacesDetectedEncoded = @"program_files\liveFacesDetectedEncoded.csv";
        string lineToSave;
        int[,] resolutions = { { 1280, 720},
                               { 640, 480 }, 
                               { 320, 240 } };

        public void EncodeAndSaveImage(Bitmap b, bool[] radioValues)
        {
            //Set resolution based on bool table
            int imageResolution = Array.IndexOf(radioValues, true);
            Bitmap resizedImage = ResizeImage(b, resolutions[imageResolution, 0], resolutions[imageResolution, 1]);

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                using (MemoryStream m = new MemoryStream())
                {
                    resizedImage.Save(m, ImageFormat.Png);

                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    lineToSave = base64String;

                    //DateTime -> Byte[] -> Base64String (ready to save)
                    string base64dateToSave = Convert.ToBase64String(BitConverter.GetBytes(DateTime.Now.Ticks));

                    //String -> Byte[] -> Baser64String 
                    string base64resToSave = Convert.ToBase64String(
                        System.Text.Encoding.ASCII.GetBytes(resolutions[imageResolution, 0].ToString()
                        + 'x' + resolutions[imageResolution, 1].ToString())
                        );

                    lineToSave = lineToSave + ';' + base64dateToSave + ';' + base64resToSave;

                    m.Flush();
                }

                using (FileStream fs = new FileStream(liveFacesDetectedEncoded, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    { 
                        sw.WriteLine(lineToSave);
                        sw.Flush();
                        fs.Flush();
                    }
                }

            }).Start();
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public void OpenFileAndDecodeImages(PictureBox pictureBox, Label infoLabel, Label resLabel, Label dateLabel)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"\program_files\";
                openFileDialog.RestoreDirectory = true;

                try
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        //Read the contents of the file into a stream
                        fileStream = openFileDialog.OpenFile();

                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            //Read first LINE!
                            fileContent = reader.ReadLine();
                            lineCount = File.ReadAllLines(filePath).Length;
                            //TO FIX - WHEN FILE IS EMPTY OR FILE IS NOT VALID!
                            if (fileContent != null)
                            {

                                fileData = fileContent.Split(';');
                                byte[] byteImage = Convert.FromBase64String(fileData[0]);

                                //Convert byte to bitmap
                                Image decodedImage;
                                using (var ms = new MemoryStream(byteImage))
                                {
                                    decodedImage = Image.FromStream(ms);
                                }
                                //Show decoded image
                                pictureBox.Image = decodedImage;
                                infoLabel.Text = (currentLineNum + 1) + " / " + lineCount;

                                EncondeDateAndResolution(dateLabel, resLabel);
                                fileLoaded = true;
                                reader.Close();
                                reader.Dispose();
                            }
                            else
                            {
                                fileLoaded = false;
                                MessageBox.Show("File could not be loaded!", "Critical Error!");
                            }
                        }
                    }
                }
                catch (Exception er)
                {
                    fileLoaded = false;
                    MessageBox.Show("File could not be loaded!", "Critical Error!");
                }
            }
        }

        public void DeleteDecodedImage(PictureBox pictureBox)
        {
            if (fileLoaded)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Are you sure you want to delete this image? This operation can not be undone...", "Deleting Image from file",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes && canDelete)
                {
                    canDelete = false;
                    int count = 0;
                    string line;

                    //Copy file to memory
                    List<string> fileContent = new List<string>();
                    StreamReader file = new StreamReader(filePath);
                    while ((line = file.ReadLine()) != null)
                    {
                        if (count == currentLineNum)
                        {
                            //dont save
                        }
                        else
                        {
                            //save
                            fileContent.Add(line);
                        }
                        count++;
                    }
                    file.Close();
                    file.Dispose();

                    //Clear the file
                    File.WriteAllText(filePath, string.Empty);

                    //Save file with new data
                    using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            foreach (string l in fileContent)
                            {
                                sw.WriteLine(l);
                                sw.Flush();
                                fs.Flush();
                            }
                        }
                    }

                    lineCount--;
                    currentLineNum = 0;
                    if (lineCount == 0)
                    {
                        fileLoaded = false;
                    }
                    pictureBox.Image = Image.FromFile(@"pictures\deleted_info.png");
                }
            }
        }

        public void PickNextEncodedImageLeft(PictureBox pictureBox, Label infoLabel, Label dateLabel, Label resLabel)
        {
            if (fileLoaded)
            {
                //Left button
                canDelete = true;
                currentLineNum--;
                if (currentLineNum < 0)
                {
                    if (lineCount != 1)
                        currentLineNum = lineCount - 1;
                    else
                        currentLineNum++;
                }

                string line = File.ReadLines(filePath).Skip(currentLineNum).Take(1).First();
                fileData = line.Split(';');
                byte[] byteImage = Convert.FromBase64String(fileData[0]);

                Image decodedImage;
                using (var ms = new MemoryStream(byteImage))
                {
                    decodedImage = Image.FromStream(ms);
                    ms.Close();
                    ms.Flush();
                    ms.Dispose();
                }
                pictureBox.Image = decodedImage;
                infoLabel.Text = (currentLineNum + 1) + " / " + lineCount;
                EncondeDateAndResolution(dateLabel, resLabel);
            }
        }

        public void PickNextEncodedImageRight(PictureBox pictureBox, Label infoLabel, Label dateLabel, Label resLabel)
        {
            if (fileLoaded)
            {
                //Right button
                canDelete = true;
                currentLineNum++;
                if (currentLineNum > lineCount - 1)
                {
                    currentLineNum = 0;
                }
                string line = File.ReadLines(filePath).Skip(currentLineNum).Take(1).First();
                fileData = line.Split(';');
                byte[] byteImage = Convert.FromBase64String(fileData[0]);

                Image decodedImage;
                using (var ms = new MemoryStream(byteImage))
                {
                    decodedImage = Image.FromStream(ms);
                    ms.Close();
                    ms.Dispose();
                    ms.Flush();
                }
                pictureBox.Image = decodedImage;
                infoLabel.Text = (currentLineNum + 1) + " / " + lineCount;
                EncondeDateAndResolution(dateLabel, resLabel);
            }
        }

        public void ImageExport()
        {
            if (fileLoaded && canDelete)
            {
                //save file as png/jpg/
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = @"C:\";
                saveFileDialog.Title = "Export image";
                saveFileDialog.DefaultExt = "png";

                //saveFileDialog.Filter = "Images|*.png;*.bmp;*.jpg";
                saveFileDialog.Filter = "JPeg Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp|Gif Image|*.gif";

                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                ImageFormat format = ImageFormat.Png;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //encode file
                    string line = File.ReadLines(filePath).Skip(currentLineNum).Take(1).First().Split(';')[0];
                    byte[] imgByte = Convert.FromBase64String(line);
                    Image decodedImage;

                    using (var ms = new MemoryStream(imgByte))
                    {
                        decodedImage = Image.FromStream(ms);
                        ms.Close();
                        ms.Dispose();
                        ms.Flush();
                    }

                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            format = ImageFormat.Jpeg;
                            break;

                        case 2:
                            format = ImageFormat.Bmp;
                            break;

                        case 3:
                            format = ImageFormat.Gif;
                            break;
                    }

                    decodedImage.Save(saveFileDialog.FileName, format);
                }
            }
        }

        public void FormDecodeBack()
        {
            fileLoaded = false;
            canDelete = true;
        }

        private void EncondeDateAndResolution(Label dateLabel, Label resLabel)
        {
            //Encode date
            byte[] byteDate = Convert.FromBase64String(fileData[1]);
            DateTime myDateTime = DateTime.FromBinary(BitConverter.ToInt64(byteDate, 0));
            dateLabel.Text = myDateTime.ToString();

            //Encode resolution
            byte[] byteResolution = Convert.FromBase64String(fileData[2]);
            string resolutionToShow = Encoding.ASCII.GetString(byteResolution);
            resLabel.Text = resolutionToShow;
        }
    }
}
