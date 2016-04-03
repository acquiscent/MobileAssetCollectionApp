using MobileAssetCollectionApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MobileAssetCollectionApp
{
    /// <summary>
    /// Interaction logic for MessageView.xaml
    /// </summary>
    public partial class MessageView : Window
    {
        public MessageView()
        {
            InitializeComponent();
        }

        public MessageView(string Messagestring, string buttonstring,string titlestring)
        {
            InitializeComponent();
            MessageVM objvm = new MessageVM(Messagestring,buttonstring,titlestring);
            this.DataContext = objvm;
        }
    }
}
