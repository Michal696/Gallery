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
    public class DeleteObjectOnPhotoCommand : ICommand
    {
        private readonly PhotoRepository photoRepository;
        private readonly IMessenger messenger;
        private readonly ObjectsOnPhotoViewModel viewModel;

        public DeleteObjectOnPhotoCommand(ObjectsOnPhotoViewModel viewModel, PhotoRepository photoRepository, IMessenger messenger)
        {
            this.viewModel = viewModel;
            this.photoRepository = photoRepository;
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
