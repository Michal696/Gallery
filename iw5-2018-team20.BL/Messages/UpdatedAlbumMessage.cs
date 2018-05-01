using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iw5_2018_team20.BL.Models;

namespace iw5_2018_team20.BL.Messages
{
    public class UpdatedAlbumMessage
    {
        public AlbumDetailModel Model { get; set; }
        public UpdatedAlbumMessage(AlbumDetailModel model)
        {
            Model = model;
        }
    }
}
