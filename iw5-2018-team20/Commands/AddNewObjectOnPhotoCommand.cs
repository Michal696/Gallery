using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Messages;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.BL.Repositories;
using iw5_2018_team20.DAL.Entities;
using iw5_2018_team20.ViewModels;


namespace iw5_2018_team20.Commands
{
    public class AddNewObjectOnPhotoCommand : ICommand
    {
        private readonly PhotoRepository photoRepository;
        private readonly IMessenger messenger;
        private readonly ObjectsOnPhotoViewModel viewModel;
        public  PhotoDetailModel photoDetailModel;

        public AddNewObjectOnPhotoCommand(ObjectsOnPhotoViewModel viewModel, PhotoRepository photoRepository, PhotoDetailModel photoDetailModel, IMessenger messenger)
        {
            this.viewModel = viewModel;
            this.photoRepository = photoRepository;
            this.messenger = messenger;
            this.photoDetailModel = photoDetailModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Mapper mapper = new Mapper();
            int.TryParse(viewModel.InputPosX, out int posx);
            int.TryParse(viewModel.InputPosY, out int posy);
            photoDetailModel.ObjectsOnPhoto.Add(new ObjectOnPhotoModel()
            {
                Photo = mapper.MapPhotoDetailModelToPhotoEntity(photoDetailModel),
                Object =  new ObjectEntity(){ Id = viewModel.SelectedObject},
                PositionX = posx,
                PositionY = posy
            });

            photoDetailModel = photoRepository.Update(photoDetailModel);
            messenger.Send(new UpdateDetailListsMessage()
            {
                Id = photoDetailModel.Id
            });
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

    }
}
