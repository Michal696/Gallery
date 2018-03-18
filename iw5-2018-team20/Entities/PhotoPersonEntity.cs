using System.ComponentModel.DataAnnotations;
using iw5_2018_team20.Entities.Base.Implementation;

namespace iw5_2018_team20.Entities
{
    public class PhotoPersonEntity : EntityBase
    {
        [Required]
        public int positionX { get; set; }
        public int positionY { get; set; }
    }
}
