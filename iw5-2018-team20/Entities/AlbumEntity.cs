using System;
using iw5_2018_team20.Entities.Base.Implementation;
using System.ComponentModel.DataAnnotations;

namespace iw5_2018_team20.Entities
{
    public class Album : EntityBase
    {
        [Required]
        private string Name { get; set; }
    }
}