using System.Collections.Generic;
using iw5_2018_team20.BL.Models.Base;
using iw5_2018_team20.DAL.Entities;

namespace iw5_2018_team20.BL.Models
{
    public class AlbumDetailModel : BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<PhotoEntity> Photos { get; set; } = new List<PhotoEntity>();
    }
}
