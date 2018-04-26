using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Repositories;
using iw5_2018_team20.ViewModels;

namespace iw5_2018_team20
{
    class ViewModelLocator
    {
        private readonly Messenger messenger = new Messenger();
        private readonly PhotoRepository photoRepository = new PhotoRepository();
        private readonly AlbumRepository albumRepository = new AlbumRepository();
        private readonly PersonRepository personRepository = new PersonRepository();
        private readonly ThingRepository thingRepository = new ThingRepository();


        public PhotosListViewModel PhotosListViewModel => CreatePhotosListViewModel();
        private PhotosListViewModel CreatePhotosListViewModel()
        {
            return new PhotosListViewModel(photoRepository, messenger);
        }

        public AlbumListViewModel AlbumListViewModel => CreateAlbumListViewModel();
        private AlbumListViewModel CreateAlbumListViewModel()
        {
            return new AlbumListViewModel(albumRepository, messenger);
        }

        public PersonListViewModel PersonListViewModel => CreatePersonListViewModel();
        private PersonListViewModel CreatePersonListViewModel()
        {
            return new PersonListViewModel(personRepository, messenger);
        }

        public ThingsListViewModel ThingsListViewModel => CreateThingsListViewModel();
        private ThingsListViewModel CreateThingsListViewModel()
        {
            return new ThingsListViewModel(thingRepository, messenger);
        }

    }
}
