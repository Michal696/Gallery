using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Messages;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.BL.Repositories;
using iw5_2018_team20.Commands;
using iw5_2018_team20.DAL;
using iw5_2018_team20.DAL.Entities;

namespace iw5_2018_team20.ViewModels
{
    public class ObjectsOnPhotoViewModel : ViewModelBase
    {

        private readonly PhotoRepository photoRepository;
        private readonly ThingRepository thingRepository;
        private readonly PersonRepository personRepository;
        private readonly IMessenger messenger;
        private PhotoDetailModel Detail;
        public string InputPosX { get; set; }
        public string InputPosY { get; set; }

        public Guid SelectedObject { get; set; }


        public ObservableCollection<ObjectOnPhotoModel> ThingsOnPhoto { get; set; } = new ObservableCollection<ObjectOnPhotoModel>();
        public ObservableCollection<ObjectOnPhotoModel> PersonsOnPhoto { get; set; } = new ObservableCollection<ObjectOnPhotoModel>();

        public ObservableCollection<ObjectsListModel> AllObjects { get; set; } = new ObservableCollection<ObjectsListModel>();
        public ICommand DeletePersonOnPhotoCommand { get; }
        public ICommand DeleteThingOnPhotoCommand { get; }
        public ICommand ThingSelectionChanged { get; }
        public ICommand PersonSelectionChanged { get; }

        private ObjectOnPhotoModel selectedPerson;
        private ObjectOnPhotoModel selectedThing;
        public AddNewObjectOnPhotoCommand AddNewObject { get; }

        public ObjectsOnPhotoViewModel(PhotoRepository photoRepository, IMessenger messenger)
        {
            InputPosX = "Souradnice X";
            InputPosY = "Souradnice Y";

            thingRepository = new ThingRepository();
            personRepository = new PersonRepository();

            List<ThingsListModel> things = thingRepository.GetAll();
            List<PersonListModel> persons = personRepository.GetAll();

            foreach (var thingsListModel in things)
            {
                AllObjects.Add(new ObjectsListModel()
                {
                    Id = thingsListModel.Id,
                    Name = thingsListModel.Name
                });
            }

            foreach (var personsListModel in persons)
            {
                AllObjects.Add(new ObjectsListModel()
                {
                    Id = personsListModel.Id,
                    Name = personsListModel.Firstname + " " + personsListModel.Surname
                });
            }


            this.photoRepository = photoRepository;
            this.messenger = messenger;

            DeletePersonOnPhotoCommand = new RelayCommand(DeletePersonOnPhoto);
            PersonSelectionChanged = new RelayCommand(selectPerson);

            DeleteThingOnPhotoCommand = new RelayCommand(DeleteThingOnPhoto);
            ThingSelectionChanged = new RelayCommand(selectThing);

            AddNewObject = new AddNewObjectOnPhotoCommand(this, photoRepository, Detail, messenger);

            this.messenger.Register<SelectedMessage>(SelectedPhoto);
            this.messenger.Register<NewMessage>(NewPhotoMessageReceived);
            this.messenger.Register<UpdateDetailListsMessage>(UpdateLists);
        }
        void selectThing(object param)
        {
            if (param is ObjectOnPhotoModel m)
            {
                selectedThing = m;
            }
        }

        void DeleteThingOnPhoto()
        {
            if (selectedThing != null)
                DeleteObjectOnPhoto(selectedThing);
            else
                Console.WriteLine("No thing is selected.");
        }

        void selectPerson(object param)
        {
            if (param is ObjectOnPhotoModel m)
            {
                selectedPerson = m;
            }
        }

        void DeletePersonOnPhoto()
        {
            if (selectedPerson != null)
                DeleteObjectOnPhoto(selectedPerson);
            else
                Console.WriteLine("No person is selected.");
        }

        void DeleteObjectOnPhoto(ObjectOnPhotoModel m)
        {
            Detail.ObjectsOnPhoto.Remove(m);
            photoRepository.Update(Detail);

            messenger.Send(new UpdateDetailListsMessage()
            {
                Id = Detail.Id
            });
        }

        public void OnLoad()
        {
            ThingsOnPhoto.Clear();
            PersonsOnPhoto.Clear();
        }

        private void NewPhotoMessageReceived(NewMessage obj)
        {
            Detail = new PhotoDetailModel();
        }

        private void UpdateLists(UpdateDetailListsMessage msg)
        {
            SelectedPhoto(new SelectedMessage()
            {
                Id = msg.Id
            });
        }

        private void SelectedPhoto(SelectedMessage message)
        {
            Detail = photoRepository.FindById(message.Id);
            AddNewObject.photoDetailModel = Detail;
            ThingsOnPhoto.Clear();
            PersonsOnPhoto.Clear();
            foreach (var objectOnPhotoModel in Detail.ObjectsOnPhoto)
            {
                if (objectOnPhotoModel.Object.GetType() == typeof(ThingEntity))
                {
                    ThingsOnPhoto.Add(objectOnPhotoModel);
                }
                else
                {
                    PersonsOnPhoto.Add(objectOnPhotoModel);
                }
            }
        }


    }
}
