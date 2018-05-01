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
using System.Windows.Navigation;
using System.Windows.Shapes;
using iw5_2018_team20.ViewModels;

namespace iw5_2018_team20.Views
{
    /// <summary>
    /// Interakční logika pro PhotoDetailView.xaml
    /// </summary>
    public partial class PhotoDetailView : UserControl
    {
        public PhotoDetailView()
        {
            InitializeComponent();
            Loaded += PhotoDetailView_Loaded;
        }

        private void PhotoDetailView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is PhotoDetailViewModel viewModel)
            {
                viewModel.OnLoad();
            }
        }
    }
}
