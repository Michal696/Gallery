using System.ComponentModel.DataAnnotations;
using iw5_2018_team20.DAL.Entities.Base.Implementation;

namespace iw5_2018_team20.DAL.Entities
{
    public class PhotoPersonEntity : EntityBase
    {
        [Required]
        public int positionX { get; set; }
        public int positionY { get; set; }
    }
}
