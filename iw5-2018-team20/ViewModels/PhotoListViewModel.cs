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
    public class PhotoListViewModel : ViewModelBase
    {
        private readonly PhotoRepository photoRepository;
        private readonly IMessenger messenger;


        public ObservableCollection<PhotosListModel> Photos { get; set; } = new ObservableCollection<PhotosListModel>();

        public ICommand SelectPhotoCommand { get; }

        public PhotoListViewModel(PhotoRepository photoRepository, IMessenger messenger)
        {
            this.photoRepository = photoRepository;
            this.messenger = messenger;

            SelectPhotoCommand = new RelayCommand(PhotoSelectionChanged);
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
                messenger.Send(new SelectedPhotoMessage { Id = photo.Id });
            }

        }

    }
}
