using System;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace Diversia.WCF.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public class ExceptionMarshallingMessageInspector : IClientMessageInspector
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="correlationState"></param>
        void IClientMessageInspector.AfterReceiveReply(ref Message reply, object correlationState)
        {
            if (!reply.IsFault) return;
            // Create a copy of the original reply to allow default processing of the message
            var buffer = reply.CreateBufferedCopy(Int32.MaxValue);
            var copy = buffer.CreateMessage();  // Create a copy to work with
            reply = buffer.CreateMessage();         // Restore the original message

            var faultDetail = ReadFaultDetail(copy);
            var exception = faultDetail as Exception;
            if (exception != null)
            {
                throw exception;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        object IClientMessageInspector.BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reply"></param>
        /// <returns></returns>
        private static object ReadFaultDetail(Message reply)
        {
            const string detailElementName = "Detail";

            using (var reader = reply.GetReaderAtBodyContents())
            {
                // Find <soap:Detail>
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.LocalName == detailElementName)
                    {
                        break;
                    }
                }

                // Did we find it?
                if (reader.NodeType != XmlNodeType.Element || reader.LocalName != detailElementName)
                {
                    return null;
                }

                // Move to the contents of <soap:Detail>
                if (!reader.Read())
                {
                    return null;
                }

                // Deserialize the fault
                NetDataContractSerializer serializer = new NetDataContractSerializer();
                try
                {
                    return serializer.ReadObject(reader);
                }
                catch (FileNotFoundException)
                {
                    // Serializer was unable to find assembly where exception is defined 
                    return null;
                }
            }
        }
    }
}
