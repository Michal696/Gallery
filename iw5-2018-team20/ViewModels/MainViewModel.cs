using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Messages;
using iw5_2018_team20.Commands;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace iw5_2018_team20.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private readonly IMessenger messenger;

        public string Name { get; set; } = "not_inserted";
        public ICommand CreatePhotoCommand { get; set; }
        public ICommand CreatePersonCommand { get; set; }

        public MainViewModel(IMessenger messenger)
        {
            this.messenger = messenger;
            CreatePhotoCommand = new RelayCommand(AddNewPhoto);
            CreatePersonCommand = new RelayCommand(AddNewPerson);
        }
        private void AddNewPhoto()
        {
            messenger.Send(new NewMessage());
        }
        private void AddNewPerson()
        {
            messenger.Send(new NewMessage());
        }

        public void OnLoad()
        {
        }
    }
}
