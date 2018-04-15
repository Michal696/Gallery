using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iw5_2018_team20.BL
{
    public interface IMessenger
    {
        void Register<TMessage>(Action<TMessage> action);
        void Send<TMessage>(TMessage message);
        void UnRegister<TMessage>(Action<TMessage> action);
    }
}
