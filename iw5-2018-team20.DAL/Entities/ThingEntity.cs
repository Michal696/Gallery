using System;
using iw5_2018_team20.DAL.Entities.Base.Implementation;
using System.ComponentModel.DataAnnotations;

namespace iw5_2018_team20.DAL.Entities
{
    public class ThingEntity : EntityBase
    {
        [Required]
        public string Name { get; set; }
    }
}