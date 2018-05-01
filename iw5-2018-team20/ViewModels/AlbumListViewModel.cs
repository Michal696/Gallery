using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Messages;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.BL.Repositories;
using iw5_2018_team20.Commands;

namespace iw5_2018_team20.ViewModels
{
    public class AlbumListViewModel : ViewModelBase
    {
        public string AlbumName { get; set; }

        private readonly AlbumRepository albumRepository;
        private readonly IMessenger messenger;

        public ObservableCollection<AlbumsListModel> Albums { get; set; } = new ObservableCollection<AlbumsListModel>();

        public ICommand SelectAlbumCommand { get; }
        public ICommand AddAlbumCommand { get; }

        public AlbumListViewModel(AlbumRepository albumRepository, IMessenger messenger)
        {
            AlbumName = "Nové album";

            this.albumRepository = albumRepository;
            this.messenger = messenger;

            AddAlbumCommand = new RelayCommand(AddAlbum);
            SelectAlbumCommand = new RelayCommand(AlbumSelectionChanged);


            this.messenger.Register<DeleteAlbumMessage>(Reload);
        }


        public void Reload(DeleteAlbumMessage m)
        {
            OnLoad();
        }

        public void OnLoad()
        {
            Albums.Clear();

            var albums = albumRepository.GetAll();
            foreach (var album in albums)
            {
                Albums.Add(album);
            }
        }

        private void AlbumSelectionChanged(object parameter)
        {
            if (parameter is AlbumsListModel album)
            {
                messenger.Send(new SelectedAlbumMessage { Id = album.Id });
            }

        }

        void AddAlbum()
        {
            var album = new AlbumDetailModel();
            album.Name = AlbumName;
            albumRepository.Insert(album);
            OnLoad();
        }

    }
}
