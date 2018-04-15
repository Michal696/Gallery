using System;
using System.Windows.Input;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Messages;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.BL.Repositories;
using iw5_2018_team20.ViewModels;

namespace CookBook.App.Commands
{
    public class SaveAlbumCommand : ICommand
    {
        private readonly AlbumRepository albumRepository;
        private readonly AlbumDetailViewModel viewModel;
        private readonly IMessenger messenger;

        public SaveAlbumCommand(AlbumRepository albumRepository, AlbumDetailViewModel viewModel, IMessenger messenger)
        {
            this.albumRepository = albumRepository;
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
                albumRepository.Insert(viewModel.Detail);
            }
            //else
            //{
            //    albumRepository.Update(viewModel.Detail);
            //}

            messenger.Send(new UpdatedAlbumMessage(viewModel.Detail));
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
