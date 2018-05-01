using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Messages;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.BL.Repositories;
using iw5_2018_team20.Commands;
using iw5_2018_team20.DAL.Entities;

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

            this.messenger.Register<DeletePhotoMessage>(reload);
        }

        public void reload(DeletePhotoMessage m)
        {
            OnLoad();
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

        public void AddNewPictures(IDataObject dropData)
        {
            var filePaths = ((string[])dropData.GetData(DataFormats.FileDrop));
            if (filePaths == null) return;
            Console.WriteLine(filePaths[0].ToString());
            foreach (var filePath in filePaths)
            {
                Image image;

                try
                {
                    image = Image.FromFile(filePath);
                }
                catch (OutOfMemoryException)
                {
                    Console.Write("File is probably not an image:" + filePath);
                    continue;
                }


                FormatType format;
                if (ImageFormat.Jpeg.Equals(image.RawFormat))
                    format = FormatType.jpeg;
                else if (ImageFormat.Png.Equals(image.RawFormat))
                    format = FormatType.png;
                else if (ImageFormat.Gif.Equals(image.RawFormat))
                    format = FormatType.gif;
                else if (ImageFormat.Bmp.Equals(image.RawFormat))
                    format = FormatType.bmp;
                else if (ImageFormat.Icon.Equals(image.RawFormat))
                    format = FormatType.icon;
                else
                    format = FormatType.unknown;

                PhotoDetailModel newImage = new PhotoDetailModel()
                {
                    CreationTime = File.GetCreationTime(filePath),
                    Height = image.Height,
                    Width = image.Width,
                    Name = filePath,
                    Path = filePath,
                    Format = format
                };

                photoRepository.Insert(newImage);
                OnLoad();
            }
        }
    }
}
