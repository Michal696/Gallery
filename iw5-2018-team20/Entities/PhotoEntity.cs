using System;
using System.ComponentModel.DataAnnotations;
using iw5_2018_team20.Entities.Base.Implementation;

namespace iw5_2018_team20.Entities
{
    class PhotoEntity : EntityBase
    {
        [Required] public string Name { get; set; }
        public DateTime CreationTime{ get; set; }
        public FormatType Format{ get; set; }
        public int Width{ get; set; }
        public int Height{ get; set; }
        public string Note{ get; set; }
        public Album Album{ get; set; }
    }

    enum FormatType
    {
        Jpeg,
        Jpg,
        Png,
        Svn,
        Gif
    }
}
