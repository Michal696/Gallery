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
    public class AddNewPersonInListCommand : ICommand
    {
        private readonly PersonListViewModel viewModel;
        private readonly PersonRepository personRepository;
        public PersonListModel personListModel;
        private readonly IMessenger messenger;
        public AddNewPersonInListCommand(PersonListViewModel viewModel, PersonRepository personRepository, PersonListModel personListModel, IMessenger messenger)
        {
            this.viewModel = viewModel;
            this.personRepository = personRepository;
            this.personListModel =  personListModel;
            this.messenger = messenger;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            personListModel = new PersonListModel();
            personListModel.Firstname = viewModel.Firstname;
            personListModel.Surname = viewModel.Surname;

            personListModel = personRepository.Insert(personListModel);

            messenger.Send(new AddNewPersonMessage()
            {
                Id = personListModel.Id
            });
            viewModel.OnLoad();
        }
    }
}
