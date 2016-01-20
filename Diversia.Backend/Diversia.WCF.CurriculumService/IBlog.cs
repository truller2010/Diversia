using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Diversia.Core.Filter;
using Diversia.Core.Pager;
using Diversia.Models.BlogPost;

namespace Diversia.WCF.CurriculumService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IBlog
    {
        [OperationContract]
        Page<BlogPostModel> Paginated(FindRequestImpl<SearchFilter> filter);

    }
}
