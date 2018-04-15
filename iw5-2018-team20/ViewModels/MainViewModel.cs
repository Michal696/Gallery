using System;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Messages;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.BL.Repositories;
using iw5_2018_team20.Commands;

namespace iw5_2018_team20.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMessenger messenger;

        public string Name { get; set; } = "not_inserted";
        public ICommand CreatePhotoCommand { get; set; }

        public MainViewModel(IMessenger messenger)
        {
            this.messenger = messenger;
            CreatePhotoCommand = new RelayCommand(AddNewPhoto);
        }

        private void AddNewPhoto()
        {
            messenger.Send(new NewPhotoMessage());
        }

        public void OnLoad()
        {
        }
    }
}