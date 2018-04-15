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

        public ThingsListViewModel(ThingRepository thingRepository, IMessenger messenger)
        {
            this.thingRepository = thingRepository;
            this.messenger = messenger;

            SelectThingCommand = new RelayCommand(ThingSelectionChanged);
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

        private void ThingSelectionChanged(object parameter)
        {
            if (parameter is ThingsListModel thing)
            {
                messenger.Send(new SelectedThingMessage { Id = thing.Id });
            }

        }

    }
}
