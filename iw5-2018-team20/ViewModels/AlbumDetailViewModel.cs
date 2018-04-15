using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CookBook.App.Commands;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Messages;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.BL.Repositories;
using iw5_2018_team20.Commands;
namespace iw5_2018_team20.ViewModels
{
    public class AlbumDetailViewModel : ViewModelBase
    {
        private readonly AlbumRepository albumRepository;
        private readonly IMessenger messenger;
        private AlbumDetailModel detail;

        public AlbumDetailModel Detail
        {
            get { return detail; }
            set
            {
                if (Equals(value, Detail)) return;

                detail = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveAlbumCommand { get; set; }
        public ICommand DeleteAlbumCommand { get; set; }

        public AlbumDetailViewModel(AlbumRepository albumRepository, IMessenger messenger)
        {
            this.albumRepository = albumRepository;
            this.messenger = messenger;

            SaveAlbumCommand = new SaveAlbumCommand(albumRepository, this, messenger);
            DeleteAlbumCommand = new RelayCommand(DeleteAlbum);

            this.messenger.Register<SelectedMessage>(SelectedAlbum);
            this.messenger.Register<NewMessage>(NewAlbumMessageReceived);
        }

        private void DeleteAlbum()
        {
            if (Detail.Id != Guid.Empty)
            {
                var albumId = Detail.Id;

                Detail = new AlbumDetailModel();
                albumRepository.Remove(albumId);
                messenger.Send(new DeleteMessage(albumId));
            }
        }

        private void NewAlbumMessageReceived(NewMessage obj)
        {
            Detail = new AlbumDetailModel();
        }

        private void SelectedAlbum(SelectedMessage message)
        {
            Detail = albumRepository.FindById(message.Id);
        }

    }
}
