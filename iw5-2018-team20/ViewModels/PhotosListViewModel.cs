using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Messages;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.BL.Repositories;
using iw5_2018_team20.Commands;

namespace iw5_2018_team20.ViewModels
{
    public class PhotosListViewModel : ViewModelBase
    {
        private readonly PhotoRepository photoRepository;
        private readonly IMessenger messenger;


        public ObservableCollection<PhotosListModel> Photos { get; set; } = new ObservableCollection<PhotosListModel>();

        public ICommand SelectPhotoCommand { get; }
        public ICommand SortByNameCommand { get; }
        public ICommand SortByTimeCommand { get; }

        public PhotosListViewModel(PhotoRepository photoRepository, IMessenger messenger)
        {
            this.photoRepository = photoRepository;
            this.messenger = messenger;

            CvsPhotos = new CollectionViewSource();
            CvsPhotos.Source = this.Photos;
            CvsPhotos.Filter += ApplyFilter;

            SelectPhotoCommand = new RelayCommand(PhotoSelectionChanged);
            SortByNameCommand = new RelayCommand(SortByName);
            SortByTimeCommand = new RelayCommand(SortByTime);
        }

        void SortByName()
        {
            List<PhotosListModel> listModels = Photos.ToList();
            listModels.Sort((emp1, emp2) => emp1.Name.CompareTo(emp2.Name));
            Photos.Clear();
            foreach (var photosListModel in listModels)
            {
                Photos.Add(photosListModel);
            }
        }

        void SortByTime()
        {
            Console.WriteLine("Sorting by time");
            List<PhotosListModel> listModels = Photos.ToList();
            listModels.Sort((emp1, emp2) => emp1.CreationTime.CompareTo(emp2.CreationTime));
            Photos.Clear();
            foreach (var photosListModel in listModels)
            {
                Photos.Add(photosListModel);
            }
        }

        public void OnLoad()
        {
            Photos.Clear();

            var photos = photoRepository.GetAll();
            foreach (var photo in photos)
            {
                Photos.Add(photo);
            }
        }

        private void PhotoSelectionChanged(object parameter)
        {
            if (parameter is PhotosListModel photo)
            {
                messenger.Send(new SelectedMessage { Id = photo.Id });
            }
        }

        private string filter;

        public string Filter
        {
            get { return this.filter; }
            set
            {
                this.filter = value;
                OnFilterChanged();
            }
        }

        private void OnFilterChanged()
        {
            CvsPhotos.View.Refresh();
        }

        internal CollectionViewSource CvsPhotos { get; set; }
        public ICollectionView AllPhotos
        {
            get { return CvsPhotos.View; }
        }

        void ApplyFilter(object sender, FilterEventArgs e)
        {
            PhotosListModel svm = (PhotosListModel)e.Item;

            if (string.IsNullOrWhiteSpace(this.Filter) || this.Filter.Length == 0) {
                e.Accepted = true;
            } else
            {
                e.Accepted = svm.Name.ToLower().Contains(Filter.ToLower());
            }
        }
    }
}
