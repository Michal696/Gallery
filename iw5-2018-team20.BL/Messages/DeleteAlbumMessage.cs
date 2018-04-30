using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iw5_2018_team20.BL.Messages
{
    public class DeleteAlbumMessage
    {
        public DeleteAlbumMessage(Guid albumId)
        {
            AlbumId = albumId;
        }

        public Guid AlbumId { get; set; }
    }
}
