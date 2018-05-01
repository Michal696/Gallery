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
    public class ThingsListViewModel : ViewModelBase
    {
        private readonly ThingRepository thingRepository;
        private readonly IMessenger messenger;


        public ObservableCollection<ThingsListModel> Things { get; set; } = new ObservableCollection<ThingsListModel>();

        public ICommand SelectThingCommand { get; }
        public string Name { get; set; }

        private ThingsListModel detail;

        public ThingsListModel Detail
        {
            get { return detail; }
            set
            {
                if (Equals(value, Detail)) return;

                detail = value;
                OnPropertyChanged();
            }
        }     

        public ICommand SelectThingsCommand { get; }
        public ICommand AddThingsCommand { get; }
        public ICommand DeleteThingsCommand { get; }

        public ThingsListViewModel(ThingRepository thingRepository, IMessenger messenger)
        {
            Name = "Zadaj nazov";
            this.thingRepository = thingRepository;
            this.messenger = messenger;

            SelectThingsCommand = new RelayCommand(SelectThingsInList);
            AddThingsCommand = new RelayCommand(AddThingsInList);
            DeleteThingsCommand = new RelayCommand(DeleteThingsInList);

            this.messenger.Register<DeleteThingsInListMessage>(Reload);
            this.messenger.Register<SelectedThingsMessage>(SelectedThings);
        }

        private void SelectThingsInList(object parameter)
        {
            if (parameter is ThingsListModel things)
            {
                messenger.Send(new SelectedThingsMessage { Id = things.Id });
            }

        }

        void AddThingsInList()
        {
            var things = new ThingsListModel();
            things.Name = Name;
            thingRepository.Insert(things);
            OnLoad();
        }



        public void Reload(DeleteThingsInListMessage m)
        {
            OnLoad();
        }

        public void OnLoad()
        {
            Things.Clear();
            var things = thingRepository.GetAll();
            foreach (var thing in things)
            {
                Things.Add(thing);
            }
        }
        void DeleteThingsInList()
        {
            if (detail != null)
            {
                thingRepository.Remove(detail.Id);
                messenger.Send(new DeleteThingsInListMessage(detail.Id));
                detail = null;
            }
            else
                Console.WriteLine("No things is selected.");

        }

        private void SelectedThings(SelectedThingsMessage message)
        {
            Detail = thingRepository.GetById(message.Id);
        }



    }
}
