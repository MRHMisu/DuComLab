using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace CyberCenter
{
    public class GlobalErrorHandler : IErrorHandler
    {

        public bool HandleError(Exception error)
        {
            // log the actual exception for the IT Team to investigate
            // return true to indicate that the exception is handled
            return true;
        }

        public void ProvideFault(Exception error,
                                 System.ServiceModel.Channels.MessageVersion version,
                                 ref System.ServiceModel.Channels.Message fault)
        {
            if (error is FaultException)
                return;

            // Return a general service error message to the client
            FaultException faultException = new FaultException("A general service error occured");
            MessageFault messageFault = faultException.CreateMessageFault();
            fault = Message.CreateMessage(version, messageFault, null);
        }
    }
}
