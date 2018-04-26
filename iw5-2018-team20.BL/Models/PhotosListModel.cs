using System;
using System.ComponentModel;
using iw5_2018_team20.BL.Models.Base;
using iw5_2018_team20.DAL.Entities;

namespace iw5_2018_team20.BL.Models
{
    public class PhotosListModel : BaseModel, INotifyPropertyChanged
    {
        public FormatType Format { get; set; }
        public AlbumEntity Album { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Dimensions
        {
            get { return Width + " x " + Height; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        private DateTime _CreationTime;
        public DateTime CreationTime
        {
            get { return _CreationTime; }
            set
            {
                _CreationTime = value;
                OnPropertyChanged("CreationTime");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
