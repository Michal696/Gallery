using System.Collections.Generic;
using iw5_2018_team20.DAL.Entities.Base.Implementation;
using System.ComponentModel.DataAnnotations;

namespace iw5_2018_team20.DAL.Entities
{
    public class AlbumEntity : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<PhotoEntity> Photos { get; set; } = new List<PhotoEntity>();

    }
}