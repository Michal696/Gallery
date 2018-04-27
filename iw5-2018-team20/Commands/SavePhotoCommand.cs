using System;
using System.Windows.Input;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Messages;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.BL.Repositories;
using iw5_2018_team20.ViewModels;

namespace CookBook.App.Commands
{
    public class SavePhotoCommand : ICommand
    {
        private readonly PhotoRepository photoRepository;
        private readonly PhotoDetailViewModel viewModel;
        private readonly IMessenger messenger;
       
        public SavePhotoCommand(PhotoRepository photoRepository, PhotoDetailViewModel viewModel, IMessenger messenger)
        {
            this.photoRepository = photoRepository;
            this.viewModel = viewModel;
            this.messenger = messenger;
        }

        public bool CanExecute(object parameter)
        {
            return true;
            //return viewModel.Detail?.Duration.TotalMinutes > 0;
        }

        public void Execute(object parameter)
        {
            if (viewModel.Detail.Id == Guid.Empty)
            {
                photoRepository.Insert(viewModel.Detail);
            }
            else
            {
                photoRepository.Update(viewModel.Detail);
            }

            messenger.Send(new UpdatedPhotoMessage(viewModel.Detail));
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
