using System;
using System.ServiceModel.Configuration;

namespace Diversia.WCF.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public class ExceptionMarshallingElement : BehaviorExtensionElement
    {
        /// <summary>
        /// 
        /// </summary>
        public override Type BehaviorType
        {
            get { return typeof(ExceptionMarshallingBehavior); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override object CreateBehavior()
        {
            return new ExceptionMarshallingBehavior();
        }
    }
}
