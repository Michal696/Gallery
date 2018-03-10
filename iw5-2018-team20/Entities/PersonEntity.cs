using System;
using iw5_2018_team20.Entities.Base.Implementation;
using System.ComponentModel.DataAnnotations;

namespace iw5_2018_team20.Entities
{
    public class PersonEntity : EntityBase
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Surname { get; set; }
    }

}