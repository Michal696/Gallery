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
    /// Interaction logic for PhotoListView.xaml
    /// </summary>
    public partial class PhotoListView : UserControl
    {
        public PhotoListView()
        {
            InitializeComponent();
            Loaded += PhotosListView_Loaded;
        }

        private void PhotosListView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is PhotosListViewModel viewModel)
            {
                viewModel.OnLoad();
            }
        }

        private void OnDropMethod(object sender, DragEventArgs e)
        {
            ((PhotosListViewModel)this.DataContext).AddNewPictures(e.Data);
            e.Handled = true;
        }
    }
}
