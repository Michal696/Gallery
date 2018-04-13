using System;
using iw5_2018_team20.BL.Models.Base;
using iw5_2018_team20.DAL.Entities;

namespace iw5_2018_team20.BL.Models
{
    class PhotosListModel : BaseModel
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public FormatType Format { get; set; }
        public AlbumEntity Album { get; set; }
    }
}
