using System.ComponentModel.DataAnnotations;
using iw5_2018_team20.DAL.Entities.Base.Implementation;

namespace iw5_2018_team20.DAL.Entities
{
    public class ObjectOnPhotoEntity : EntityBase
    {
        [Required] public int PositionX { get; set; }
        [Required] public int PositionY { get; set; }

        [Required] public PhotoEntity Photo { get; set; }
        [Required] public ObjectEntity Object { get; set; }
    }
}
