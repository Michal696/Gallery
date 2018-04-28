using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Repositories;
using iw5_2018_team20.ViewModels;

namespace iw5_2018_team20.Commands
{
    class DeleteObjectFromPhotoCommand : ICommand
    {
        private readonly PersonRepository personRepository;
        private readonly ThingRepository thingRepository;
        private readonly IMessenger messenger;
        private readonly PhotoDetailViewModel viewModel;

        public DeleteObjectFromPhotoCommand(PersonRepository personRepository, ThingRepository thingRepository, IMessenger messenger)
        {
            this.thingRepository = thingRepository;
            this.personRepository = personRepository;
            this.messenger = messenger;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
