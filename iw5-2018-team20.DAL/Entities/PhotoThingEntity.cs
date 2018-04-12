using System;
using iw5_2018_team20.DAL.Entities.Base.Implementation;
using System.ComponentModel.DataAnnotations;

namespace iw5_2018_team20.DAL.Entities
{
    public class PhotoThingEntity : EntityBase
    {
        [Required] public int positionX { get; set; }
        [Required] public int positionY { get; set; }

        [Required] public PhotoEntity Photo { get; set; }
        [Required] public ThingEntity Person { get; set; }
    }
}