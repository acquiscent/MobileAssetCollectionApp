using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAssetCollectionApp.ViewModel
{
    public class AssetSetModel : ViewModelBase
    {
        private int _MobileDeviceID;
        public int MobileDeviceID
        {
            get { return _MobileDeviceID; }
            set
            {
                _MobileDeviceID = value;
                OnPropertyChanged("MobileDeviceID");
            }
        }

        private string _AssetLetter;
        public string AssetLetter
        {
            get { return _AssetLetter; }
            set
            {
                _AssetLetter = value;
                OnPropertyChanged("AssetLetter");
            }
        }

        private string _DeviceType;
        public string DeviceType
        {
            get { return _DeviceType; }
            set
            {
                _DeviceType = value;
                OnPropertyChanged("DeviceType");
            }
        }

        private double _ImageWidthPixels;
        public double ImageWidthPixels
        {
            get { return _ImageWidthPixels; }
            set
            {
                _ImageWidthPixels = value;
                OnPropertyChanged("ImageWidthPixels");
            }
        }

        private double _ImageHeightPixels;
        public double ImageHeightPixels
        {
            get { return _ImageHeightPixels; }
            set
            {
                _ImageHeightPixels = value;
                OnPropertyChanged("ImageHeightPixels");
            }
        }

        private List<string> _Attach1Files;
        public List<string> Attach1Files
        {
            get { return _Attach1Files; }
            set
            {
                Attach1FilesString = string.Empty;
                foreach (string s in value)
                {
                    Attach1FilesString = string.IsNullOrEmpty(Attach1FilesString)? s:Attach1FilesString + "," + s;
                }
                _Attach1Files = value;
                OnPropertyChanged("Attach1Files");
            }
        }

        private string _Attach1FilesString;
        public string Attach1FilesString
        {
            get { return _Attach1FilesString; }
            set
            {
                _Attach1FilesString = value;
                OnPropertyChanged("Attach1FilesString");
            }
        }

        private List<string> _Attach2Files;
        public List<string> Attach2Files
        {
            get { return _Attach2Files; }
            set
            {
                Attach2FilesString = string.Empty;
                foreach (string s in value)
                {
                    Attach2FilesString = string.IsNullOrEmpty(Attach2FilesString) ? s : Attach2FilesString + "," + s;
                }
                _Attach2Files = value;
                OnPropertyChanged("Attach2Files");
            }
        }

        private string _Attach2FilesString;
        public string Attach2FilesString
        {
            get { return _Attach2FilesString; }
            set
            {
                _Attach2FilesString = value;
                OnPropertyChanged("Attach2FilesString");
            }
        }

        private string _AssetType;
        public string AssetType
        {
            get { return _AssetType; }
            set
            {
                _AssetType = value;
                OnPropertyChanged("AssetType");
            }
        }
    }
}
