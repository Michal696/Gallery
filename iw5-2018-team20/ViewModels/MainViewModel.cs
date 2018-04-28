using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Messages;
using iw5_2018_team20.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace iw5_2018_team20.ViewModels
{
    class MainViewModel
    {
        private readonly IMessenger messenger;

        public string Name { get; set; } = "Nenacteno";
        public ICommand CreatePersonCommand { get; set; }

        public MainViewModel(IMessenger messenger)
        {
            this.messenger = messenger;
            CreatePersonCommand = new RelayCommand(AddNewPerson);
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
