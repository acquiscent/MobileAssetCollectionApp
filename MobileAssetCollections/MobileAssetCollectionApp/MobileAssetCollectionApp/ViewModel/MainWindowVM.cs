using Ionic.Zip;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileAssetCollectionApp.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        clsCommonMethods objcommonMethods = new clsCommonMethods();

        private List<AssetSetModel> _AssetSetList;
        public List<AssetSetModel> AssetSetList
        {
            get { return _AssetSetList; }
            set
            {
                _AssetSetList = value;
                OnPropertyChanged("AssetSetList");
            }
        }
        private AssetSetModel _CurrentAssetSetItem;
        public AssetSetModel CurrentAssetSetItem
        {
            get { return _CurrentAssetSetItem; }
            set
            {
                _CurrentAssetSetItem = value;
                OnPropertyChanged("CurrentAssetSetItem");
            }
        }
        public MainWindowVM()
        {
            AssetSetList = new List<AssetSetModel>();
            AssetSetList = objcommonMethods.LoadExcelSheet();
        }

        private DelegateCommand _Attach1BrowseCommand;
        public DelegateCommand Attach1BrowseCommand
        {
            get
            {
                return this._Attach1BrowseCommand ?? (this._Attach1BrowseCommand = new DelegateCommand(this.Attach1BrowseClick));
            }
        }

        private DelegateCommand _Attach2BrowseCommand;
        public DelegateCommand Attach2BrowseCommand
        {
            get
            {
                return this._Attach2BrowseCommand ?? (this._Attach2BrowseCommand = new DelegateCommand(this.Attach2BrowseClick));
            }
        }

        private void Attach1BrowseClick(object obj)
        {
            if (CurrentAssetSetItem != null)
            {
                if (CurrentAssetSetItem.Attach1Files == null)
                    CurrentAssetSetItem.Attach1Files = new List<string>();
                CurrentAssetSetItem.Attach1Files.AddRange(objcommonMethods.UploadFiles("Image Files (*.png, *.jpg)|*.png;*.jpg", CurrentAssetSetItem.ImageWidthPixels, CurrentAssetSetItem.ImageHeightPixels, true));
                CurrentAssetSetItem.Attach1Files = CurrentAssetSetItem.Attach1Files.Distinct().ToList();
            }
        }

        private void Attach2BrowseClick(object obj)
        {
            if (CurrentAssetSetItem != null)
            {
                if (CurrentAssetSetItem.Attach2Files == null)
                    CurrentAssetSetItem.Attach2Files = new List<string>();
                CurrentAssetSetItem.Attach2Files.AddRange(objcommonMethods.UploadFiles("Design Files (*.svg,*.pi,*.ai)|*.svg,*.pi,*.ai", CurrentAssetSetItem.ImageWidthPixels, CurrentAssetSetItem.ImageHeightPixels, false));
                CurrentAssetSetItem.Attach2Files = CurrentAssetSetItem.Attach2Files.Distinct().ToList();
            }
        }

        private DelegateCommand _PreviewCommand;
        public DelegateCommand PreviewCommand
        {
            get
            {
                return this._PreviewCommand ?? (this._PreviewCommand = new DelegateCommand(this.PreviewClick));
            }
        }

        private void PreviewClick(object obj)
        {
            if (CurrentAssetSetItem != null)
            {
                ImagePreview objpreview = new ImagePreview(CurrentAssetSetItem.Attach1Files);
                objpreview.ShowDialog();
            }
        }

        private DelegateCommand _ZipCommand;
        public DelegateCommand ZipCommand
        {
            get
            {
                return this._ZipCommand ?? (this._ZipCommand = new DelegateCommand(this.ZipClick));
            }
        }

        private void ZipClick(object obj)
        {
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    if (Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Mobile Assets")))
                    {
                        Directory.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Mobile Assets"), true);
                    }
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Mobile Assets"));
                    foreach (AssetSetModel model in AssetSetList)
                    {
                        if (model.Attach1Files != null)
                        {
                            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Mobile Assets", model.AssetType)))
                            {
                                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Mobile Assets", model.AssetType));
                            }
                            foreach (string str in model.Attach1Files)
                            {
                                string fileNameOnly = Path.GetFileNameWithoutExtension(str);
                                string extension = Path.GetExtension(str);
                                string filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Mobile Assets", model.AssetType, fileNameOnly + extension);
                                File.Copy(str, objcommonMethods.FileNameGeneration(filepath, model.AssetLetter));
                            }
                        }
                    }
                    foreach (string directorypath in Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Mobile Assets")))
                    {
                        DirectoryInfo dirinfo = new DirectoryInfo(directorypath);
                        zip.AddDirectory(directorypath, dirinfo.Name);
                    }
                    if (zip.Entries.Count > 0)
                    {
                        string zipfilename = DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + ".zip";
                        zip.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Mobile Assets", zipfilename));
                        MessageView objview = new MessageView(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Mobile Assets", zipfilename), "Copy to Clipboard", "Zip has been created successfully");
                        objview.ShowDialog();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageView objview = new MessageView("Error:" + ex.ToString(), "OK", "Zip Creation have some problems.");
                objview.ShowDialog();
                Console.WriteLine("Folder or file is open.");
            }
        }
    }
}
