using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iw5_2018_team20.BL.Messages
{
    public class DeletePersonInListMessage 
    {
        public DeletePersonInListMessage(Guid personId)
        {
            PersonId = personId;
        }

        public Guid PersonId { get; set; }
    }
}
