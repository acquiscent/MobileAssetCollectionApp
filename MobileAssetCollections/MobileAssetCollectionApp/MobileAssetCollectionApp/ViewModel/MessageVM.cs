using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAssetCollectionApp.ViewModel
{
    public class MessageVM : ViewModelBase
    {
        public MessageVM(string messagestring, string buttonstring,string titlestring)
        {
            MessageString = messagestring;
            ButtonString = buttonstring;
            TitleString = titlestring;
        }

        private string _MessageString;
        public string MessageString
        {
            get { return _MessageString; }
            set
            {
                _MessageString = value;
                OnPropertyChanged("MessageString");
            }
        }

        private string _TitleString;
        public string TitleString
        {
            get { return _TitleString; }
            set
            {
                _TitleString = value;
                OnPropertyChanged("TitleString");
            }
        }


        private string _ButtonString;
        public string ButtonString
        {
            get { return _ButtonString; }
            set
            {
                _ButtonString = value;
                OnPropertyChanged("ButtonString");
            }
        }

        private DelegateCommand _ButtonCommand;
        public DelegateCommand ButtonCommand
        {
            get
            {
                return this._ButtonCommand ?? (this._ButtonCommand = new DelegateCommand(this.ButtonClick));
            }
        }

        private void ButtonClick(object obj)
        {
            if (ButtonString.Contains("Copy"))
            {
                System.Windows.Clipboard.SetText(MessageString);
            }
        }
    }
}
