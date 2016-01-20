using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web.Hosting;

namespace Diversia.WCF.CurriculumService
{
    public class GlobalErrorHandler : IErrorHandler
    {
        // Provide a fault. The Message fault parameter can be replaced, or set to null to suppress
        // reporting a fault.

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            var newEx = new FaultException(
                $"Exception caught at GlobalErrorHandler{Environment.NewLine}Method: {error.TargetSite.Name}{Environment.NewLine}Message:{error.Message}");

            var msgFault = newEx.CreateMessageFault();
            fault = Message.CreateMessage(version, msgFault, newEx.Action);
        }

        // HandleError. Log an error, then allow the error to be handled as usual. Return true if
        // the error is considered as already handled

        public bool HandleError(Exception error)
        {
            var path = HostingEnvironment.ApplicationPhysicalPath;

            using (TextWriter tw = File.AppendText(@"c:\\temp\\error.txt"))
            {
                if (error != null)
                {
                    tw.WriteLine("Exception:{0}{1}Method: {2}{3}Message:{4}",
                        error.GetType().Name, Environment.NewLine, error.TargetSite.Name,
                        Environment.NewLine, error.Message + Environment.NewLine);
                }
                tw.Close();
            }

            return true;
        }
    }
}