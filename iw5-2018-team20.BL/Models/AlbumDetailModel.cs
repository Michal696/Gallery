using System.Collections.Generic;
using iw5_2018_team20.BL.Models.Base;
using iw5_2018_team20.DAL.Entities;

namespace iw5_2018_team20.BL.Models
{
    class AlbumDetailModel : BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<PhotoEntity> Objects { get; set; } = new List<PhotoEntity>();
    }
}
