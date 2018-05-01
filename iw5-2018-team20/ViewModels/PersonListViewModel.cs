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

        private PersonListModel detail;

        public PersonListModel Detail
        {
            get { return detail; }
            set
            {
                if (Equals(value, Detail)) return;

                detail = value;
                OnPropertyChanged();
            }
        }

      
        public ObservableCollection<PersonListModel> Persons { get; set; } = new ObservableCollection<PersonListModel>();

        
        public ICommand SelectPersonCommand { get; }
        public ICommand AddPersonCommand { get; }
        public ICommand DeletePersonCommand { get; }
        
        public PersonListViewModel(PersonRepository personRepository, IMessenger messenger)
        {

            Firstname = "Zadaj prve meno";
            Surname = "Zadaj prezvisko";

            List<PersonListModel> persons = personRepository.GetAll();

            this.personRepository = personRepository;
            this.messenger = messenger;


            SelectPersonCommand = new RelayCommand(SelectPersonInList);
            AddPersonCommand = new RelayCommand(AddPersonInList);
            DeletePersonCommand = new RelayCommand(DeletePersonInList);

            this.messenger.Register<DeletePersonInListMessage>(Reload);
            this.messenger.Register<SelectedPersonMessage>(SelectedPerson);

        }

        private void SelectPersonInList(object parameter)
            {
            if (parameter is PersonListModel person)
            {
                messenger.Send(new SelectedPersonMessage { Id = person.Id });
            }

        }

        void AddPersonInList()
        {
            var person = new PersonListModel();
            person.Firstname = Firstname;
            person.Surname = Surname;
            personRepository.Insert(person);
            OnLoad();
        }



        public void Reload(DeletePersonInListMessage m)
        {
            OnLoad();
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
        void DeletePersonInList()
        {
            if (detail != null)
            {
                personRepository.Remove(detail.Id);
                messenger.Send(new DeletePersonInListMessage(detail.Id));
            }
            else
                Console.WriteLine("No person is selected.");
            
        }

        private void SelectedPerson(SelectedPersonMessage message)
        {
            Detail = personRepository.GetById(message.Id);
        }

        private void AlbumSelectionChanged(object parameter)
        {
            if (parameter is AlbumsListModel album)
            {
                messenger.Send(new SelectedAlbumMessage { Id = album.Id });
            }

        }



    }
}
