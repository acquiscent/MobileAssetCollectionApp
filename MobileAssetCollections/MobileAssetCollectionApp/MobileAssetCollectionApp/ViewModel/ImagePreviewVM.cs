using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MobileAssetCollectionApp.ViewModel
{
    public class ImagePreviewVM : ViewModelBase
    {
        private List<string> _ImagePathList;
        public List<string> ImagePathList
        {
            get { return _ImagePathList; }
            set
            {
                _ImagePathList = value;
                OnPropertyChanged("ImagePathList");
            }
        }

        private BitmapImage _PreviewImage;
        public BitmapImage PreviewImage
        {
            get { return _PreviewImage; }
            set
            {
                _PreviewImage = value;
                OnPropertyChanged("PreviewImage");
            }
        }

        public ImagePreviewVM(List<string> list)
        {
            ImagePathList = list;
            if (ImagePathList.Count > 0)
            {
                PreviewImage = new BitmapImage(new Uri(ImagePathList[0],UriKind.RelativeOrAbsolute));
            }
        }

        private DelegateCommand _NextCommand;
        public DelegateCommand NextCommand
        {
            get
            {
                return this._NextCommand ?? (this._NextCommand = new DelegateCommand(this.NextClick));
            }
        }

        private void NextClick(object obj)
        {
            if (ImagePathList.Count > 0)
            {
                PreviewImage = new BitmapImage(new Uri((ImagePathList.IndexOf(PreviewImage.UriSource.LocalPath.ToString()) < ImagePathList.Count - 1 ? ImagePathList.ElementAt(ImagePathList.IndexOf(PreviewImage.UriSource.LocalPath.ToString()) + 1) : ImagePathList.ElementAt(0)), UriKind.RelativeOrAbsolute));
            }
        }

        private DelegateCommand _PreviousCommand;
        public DelegateCommand PreviousCommand
        {
            get
            {
                return this._PreviousCommand ?? (this._PreviousCommand = new DelegateCommand(this.PreviousClick));
            }
        }

        private void PreviousClick(object obj)
        {
            if (ImagePathList.Count > 0)
            {
                PreviewImage = new BitmapImage(new Uri((ImagePathList.IndexOf(PreviewImage.UriSource.LocalPath.ToString()) > 0 ? ImagePathList.ElementAt(ImagePathList.IndexOf(PreviewImage.UriSource.LocalPath.ToString()) - 1) : ImagePathList.ElementAt(ImagePathList.Count - 1)), UriKind.RelativeOrAbsolute));
            }
        }

    }
}
