using iw5_2018_team20.ViewModels;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Repositories;
using System;

namespace iw5_2018_team20
{
    public class ViewModelLocator
    {
        private readonly Messenger messenger = new Messenger();
        private readonly AlbumRepository albumRepository = new AlbumRepository();
        private readonly PersonRepository personRepository = new PersonRepository();
        private readonly PhotoRepository photoRepository = new PhotoRepository();
        private readonly ThingRepository thingRepository = new ThingRepository();

        public AlbumsListViewModel albumListViewModel => CreateAlbumListViewModel();
        public AlbumDetailViewModel albumDetailViewModel => CreateAlbumDetailViewModel();
        public PersonListViewModel personListViewModel => CreatePersonListViewModel();
        public PhotosListViewModel photoListViewModel => CreatePhotoListViewModel();
        public PhotoDetailViewModel photoDetailViewModel => CreatePhotoDetailViewModel();
        public ThingsListViewModel thingListViewModel => CreateThingListViewModel();
        public MainViewModel MainViewModel => CreateMainViewModel();

        private AlbumListViewModel CreateAlbumListViewModel()
        {
            return new AlbumListViewModel(albumRepository, messenger);
        }

        private AlbumDetailViewModel CreateAlbumDetailViewModel()
        {
            return new AlbumDetailViewModel(albumRepository, messenger);
        }

        private PersonListViewModel CreatePersonListViewModel()
        {
            return new PersonListViewModel(personRepository, messenger);
        }

        private PhotoListViewModel CreatePhotoListViewModel()
        {
            return new PhotoListViewModel(photoRepository, messenger);
        }

        private PhotoDetailViewModel CreatePhotoDetailViewModel()
        {
            return new PhotoDetailViewModel(photoRepository, messenger);
        }

        private ThingListViewModel CreateThingListViewModel()
        {
            return new ThingListViewModel(thingRepository, messenger);
        }

        private MainViewModel CreateMainViewModel()
        {
            return new MainViewModel(messenger);
        }
    }
}