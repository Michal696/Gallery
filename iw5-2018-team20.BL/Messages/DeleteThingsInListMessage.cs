using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iw5_2018_team20.BL.Messages
{
    public class DeleteThingsInListMessage
    {
        public DeleteThingsInListMessage(Guid thingId)
        {
            ThingId = thingId;
        }

        public Guid ThingId { get; set; }
        
    }
}
