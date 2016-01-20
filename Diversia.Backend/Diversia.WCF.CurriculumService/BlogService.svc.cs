using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.WebControls;
using Diversia.Core.Filter;
using Diversia.Core.Pager;
using Diversia.Models.BlogPost;
using Diversia.Service.BlogPost;
using FizzWare.NBuilder;

namespace Diversia.WCF.CurriculumService
{

    [GlobalErrorBehaviorAttribute(typeof(GlobalErrorHandler))]
    [DataContract]
    public class BlogService : IBlog
    {
        
        public Page<BlogPostModel> Paginated(FindRequestImpl<SearchFilter> filter)
        {
            var logs = Builder<BlogPostModel>.CreateListOfSize(10).Build();
            return new Page<BlogPostModel>(logs,1,10,logs.Count,filter.PageRequest.Sort,logs.Count,10);
        }
    }
}
