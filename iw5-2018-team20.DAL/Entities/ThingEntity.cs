using System.ComponentModel.DataAnnotations;

namespace iw5_2018_team20.DAL.Entities
{
    public class ThingEntity : ObjectEntity
    {
        [Required]
        public string Name { get; set; }
    }
}