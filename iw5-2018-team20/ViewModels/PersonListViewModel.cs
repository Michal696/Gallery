using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Messages;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.BL.Repositories;
using iw5_2018_team20.Commands;

namespace iw5_2018_team20.ViewModels
{
    public class PersonListViewModel : ViewModelBase
    {
        private readonly PersonRepository personRepository;
        private readonly IMessenger messenger;
        private PersonListModel detail;


        public ObservableCollection<PersonListModel> Persons { get; set; } = new ObservableCollection<PersonListModel>();

        public ICommand SelectPersonCommand { get; }


        public PersonListViewModel(PersonRepository personRepository, IMessenger messenger)
        {
            this.personRepository = personRepository;
            this.messenger = messenger;

            SelectPersonCommand = new RelayCommand(PersonSelectionChanged);
        }

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

    }
}
