using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Messages;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.BL.Repositories;
using iw5_2018_team20.Commands;
using iw5_2018_team20.DAL.Entities;

namespace iw5_2018_team20.ViewModels
{
    public class PersonListViewModel : ViewModelBase
    {
        private readonly PersonRepository personRepository;
        private readonly IMessenger messenger;
        public string Firstname { get; set; }
        public string Surname { get; set; }

        private PersonListModel selectedPerson;

        public ObservableCollection<PersonListModel> Persons { get; set; } = new ObservableCollection<PersonListModel>();

        
        public ICommand SelectPersonCommand { get; }
        public ICommand DeletePersonCommand { get; }

        public AddNewPersonInListCommand AddNewPerson { get; }

        public PersonListViewModel(PersonRepository personRepository, IMessenger messenger)
        {

            Firstname = "Zadaj prve meno";
            Surname = "Zadaj prezvisko";

            personRepository = new PersonRepository();

            List<PersonListModel> persons = personRepository.GetAll();

            this.personRepository = personRepository;
            this.messenger = messenger;

            DeletePersonCommand = new RelayCommand(DeletePersonInList);
            SelectPersonCommand = new RelayCommand(SelectPersonInList);
            AddNewPerson = new AddNewPersonInListCommand(this, personRepository, selectedPerson, messenger);

            this.messenger.Register<NewMessage>(NewPersonMessageReceived);
        }

        void SelectPersonInList(object param)
            { // param is null
                if (param is PersonListModel m)
                {
                    selectedPerson = m;
                }

            }

        void DeletePersonInList()
        {
            if (selectedPerson != null) {
                personRepository.Remove(selectedPerson.Id);
                messenger.Send(new DeletePersonListsMessage()
                {
                    Id = selectedPerson.Id
                });
            }
            else
                Console.WriteLine("No person is selected.");
        }


        public void OnLoad()
        {
            Persons.Clear();

            var persons = personRepository.GetAll();
            foreach (var person in persons)
            {
                Persons.Add(person);
            }
        }

        private void PersonSelectionChanged(object parameter)
        {
            if (parameter is PersonListModel person)
            {
                messenger.Send(new SelectedMessage { Id = person.Id });
            }

        }
        private void NewPersonMessageReceived(NewMessage obj)
        {
            selectedPerson = new PersonListModel();
        }


    }
}
