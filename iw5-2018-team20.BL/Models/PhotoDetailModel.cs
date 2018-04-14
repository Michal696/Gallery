using System;
using System.Collections.Generic;
using iw5_2018_team20.BL.Models.Base;
using iw5_2018_team20.DAL.Entities;

namespace iw5_2018_team20.BL.Models
{
    public class PhotoDetailModel : BaseModel
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public FormatType Format { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Note { get; set; }
        public AlbumEntity Album { get; set; }
        public virtual ICollection<ObjectOnPhotoEntity> ObjectsOnPhoto { get; set; } = new List<ObjectOnPhotoEntity>();
    }
}
