using Microsoft.Win32;
using MobileAssetCollectionApp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MobileAssetCollectionApp
{
    public class clsCommonMethods
    {
        public List<string> UploadFiles(string Extension,double width,double height,bool IsFirstAttach)
        {
            List<string> returnValue = new List<string>();
            bool confirmed = false;
            OpenFileDialog openfiledialog=null;
            while (!confirmed)
            {
                openfiledialog = new OpenFileDialog();
                openfiledialog.Filter = Extension;
                openfiledialog.Multiselect = true;
                bool? result = openfiledialog.ShowDialog();
                if (result == true)
                {
                    if (IsFirstAttach)
                    {
                        foreach (string str in openfiledialog.FileNames)
                        {
                            BitmapImage img = new BitmapImage(new Uri(str, UriKind.RelativeOrAbsolute));
                            if (img.Width == width && img.Height == height)
                            {
                                confirmed = true;
                                returnValue = openfiledialog.FileNames.ToList();
                            }
                            else
                            {
                                confirmed = false;
                                returnValue = new List<string>();
                                MessageView objview = new MessageView("Uploaded image dimensions are not correct. Try to upload images with "+ width+"x"+height +"dimension.", "OK", "Image Uploading have some problems.");
                                objview.ShowDialog();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    confirmed = true;
                    returnValue = new List<string>();
                }
            }
            return returnValue;
        }

        public List<AssetSetModel> LoadExcelSheet()
        {
            List<AssetSetModel> List = new List<AssetSetModel>();
            string[] lines = File.ReadAllLines("ExcelData/asset_chart.csv").Skip(1).ToArray();

            int i = 0;
            foreach (string line in lines)
            {
                string[] item = line.Split(',');
                AssetSetModel model=new AssetSetModel
                {
                    AssetLetter = item[0],
                    DeviceType = item[1],
                    AssetType = item[2],
                    ImageWidthPixels = Convert.ToDouble(item[3].Split('x')[0].Trim()),
                    ImageHeightPixels = Convert.ToDouble(item[3].Split('x')[1].Trim())
                };
                Console.WriteLine(""+i);
                i++;
                List.Add(model);
            }
            return List;
        }

        public string FileNameGeneration(string fullPath,string AssetLetter)
        {
            int count = 1;
            string fileNameOnly = Path.GetFileNameWithoutExtension(fullPath);
            string extension = Path.GetExtension(fullPath);
            string path = Path.GetDirectoryName(fullPath);
            string newFullPath = fullPath;

            while (File.Exists(newFullPath))
            {
                string tempFileName = string.Format("{0}_{1}_{2}", fileNameOnly, AssetLetter, count++);
                newFullPath = Path.Combine(path, tempFileName + extension);
            }
            return newFullPath;
        }
    }
}
