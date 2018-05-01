using iw5_2018_team20.BL.Models.Base;
using System.ComponentModel;

namespace iw5_2018_team20.BL.Models
{
    public class PersonListModel : BaseModel, INotifyPropertyChanged
    {
        private string _firstname;
        public string Firstname
        {
            get { return _firstname;}
            set
            {
                _firstname = value;
                OnPropertyChanged("Firstname");
            }
        }
        public string Surname { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
