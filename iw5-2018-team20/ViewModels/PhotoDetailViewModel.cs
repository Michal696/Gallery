using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using iw5_2018_team20.Commands;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Messages;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.BL.Repositories;
namespace iw5_2018_team20.ViewModels
{
    public class PhotoDetailViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly PhotoRepository photoRepository;
        private readonly AlbumRepository albumRepository;
        private readonly IMessenger messenger;
        private PhotoDetailModel detail;

        public ObservableCollection<AlbumsListModel> AllAlbums { get; set; } = new ObservableCollection<AlbumsListModel>();

        public Guid SelectedObject { get; set; }
        public string PoznamkaInput { get; set; }


        public PhotoDetailModel Detail
        {
            get { return detail; }
            set
            {
                if (Equals(value, Detail)) return;

                detail = value;
                OnPropertyChanged();
            }
        }

        public ICommand SavePhotoCommand { get; set; }
        public ICommand DeletePhotoCommand { get; set; }
        public ICommand UpdatePhotoCommand { get; set; }

        public PhotoDetailViewModel(PhotoRepository photoRepository, IMessenger messenger)
        {
            albumRepository = new AlbumRepository();

            List<AlbumsListModel> albums = albumRepository.GetAll();

            foreach (var albumListModel in albums)
            {
                AllAlbums.Add(new AlbumsListModel()
                {
                    Id = albumListModel.Id,
                    Name = albumListModel.Name
                });
            }


            this.photoRepository = photoRepository;
            this.messenger = messenger;

            SavePhotoCommand = new SavePhotoCommand(photoRepository, this, messenger);
            DeletePhotoCommand = new RelayCommand(DeletePhoto);
            UpdatePhotoCommand = new RelayCommand(UpdatePhoto);

            this.messenger.Register<SelectedMessage>(SelectedPhoto);
            this.messenger.Register<NewMessage>(NewPhotoMessageReceived);
        }

        private void DeletePhoto()
        {
            if (Detail.Id != Guid.Empty)
            {
                var photoId = Detail.Id;

                Detail = null;
                photoRepository.Remove(photoId);
                messenger.Send(new DeletePhotoMessage(photoId));
            }
        }


        private void UpdatePhoto()
        {
            Mapper mapper = new Mapper();
            if (SelectedObject != Guid.Empty)
            {
                Detail.Album = mapper.MapAlbumDetailModelToAlbumEntity(albumRepository.FindById(SelectedObject));
                var album = albumRepository.FindById(SelectedObject);
                album.Photos.Add(mapper.MapPhotoDetailModelToPhotoEntity(Detail));
            }
            Detail.Note = PoznamkaInput;
            photoRepository.Update(Detail);
        }

        private void NewPhotoMessageReceived(NewMessage obj)
        {
            Detail = new PhotoDetailModel();
        }

        private void SelectedPhoto(SelectedMessage message)
        {
            Detail = photoRepository.FindById(message.Id);
        }

    }
}
