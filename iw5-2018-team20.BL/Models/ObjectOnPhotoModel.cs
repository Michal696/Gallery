using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using iw5_2018_team20.BL.Models.Base;
using iw5_2018_team20.DAL.Entities;

namespace iw5_2018_team20.BL.Models
{
    public class ObjectOnPhotoModel : BaseModel
    { 
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public PhotoEntity Photo { get; set; }
        public ObjectEntity Object { get; set; }
    }
}
