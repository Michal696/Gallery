using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iw5_2018_team20.BL.Messages
{
    public class DeleteMessage
    {
        public DeleteMessage(Guid exampleId)
        {
            ExampleId = exampleId;
        }

        public Guid ExampleId { get; set; }
    }
}
