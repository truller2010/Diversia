#region Diversia Header License

// // Solution: Diversia
// // Project: Diversia.Repository
// //
// // This file is included in the Diversia solution.
// //
// // File created on 14/01/2016   14:54
// //
// // File Modified on 14/01/2016/   14:54
// 
// // Permission is hereby granted, free of charge, to any person obtaining a copy
// // of this software and associated documentation files (the "Software"), to deal
// // in the Software without restriction, including without limitation the rights
// // to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// // copies of the Software, and to permit persons to whom the Software is
// // furnished to do so, subject to the following conditions:
// //
// // The above copyright notice and this permission notice shall be included in all
// // copies or substantial portions of the Software.
// //
// // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// // FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// // AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// // LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// // OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// // SOFTWARE.

#endregion

#region

using System.Reflection;
using FluentNHibernate;
using Diversia.Repository.Abstract;
using NHibernate.Caches.SysCache;
using NHibernate.Cfg;
using NHibernate.Envers.Configuration.Attributes;
using NHibernate.Event;
using Spring.Data.NHibernate;

//using Spring.Data.NHibernate;

#endregion

namespace Diversia.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class FluentNhibernateLocalSessionFactoryObject : LocalSessionFactoryObject
    {
        /// <summary>
        ///     Sets the assemblies to load that contain fluent nhibernate mappings.
        /// </summary>
        /// <value>The mapping assemblies.</value>
        public string[] FluentNhibernateMappingAssemblies { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        protected override void PostProcessConfiguration(Configuration config)
        {
            if (FluentNhibernateMappingAssemblies != null)
            {
                foreach (var assemblyName in FluentNhibernateMappingAssemblies)
                {
                    config.AddMappingsFromAssembly(Assembly.Load(assemblyName));
                }
            }

            config.Properties.Add("nhibernate.envers.Diversia_with_modified_flag", "true");
                //log property data for revisions
            config.IntegrateWithEnvers(new AttributeConfiguration());
            config.SetListener(ListenerType.PreInsert, new DiversiaAuditEventListener());
            config.SetListener(ListenerType.PreUpdate, new DiversiaAuditEventListener());
            config.SetListener(ListenerType.PreDelete, new DiversiaAuditEventListener());
            config.SetListener(ListenerType.PreCollectionRecreate, new DiversiaAuditEventListener());
            config.SetListener(ListenerType.PreCollectionUpdate, new DiversiaAuditEventListener());
            config.SetListener(ListenerType.PreCollectionRemove, new DiversiaAuditEventListener());
            config.Cache(c =>
            {
                c.UseMinimalPuts = true;
                c.UseQueryCache = true;
                c.Provider<SysCacheProvider>();
            });
        }
    }
}