using System.ComponentModel.DataAnnotations;

namespace iw5_2018_team20.DAL.Entities
{
    public class PersonEntity : ObjectEntity
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Surname { get; set; }
    }

}