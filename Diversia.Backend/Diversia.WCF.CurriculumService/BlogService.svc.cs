using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Diversia.Models.BlogPost;
using Diversia.Service.BlogPost;

namespace Diversia.WCF.CurriculumService
{

    [GlobalErrorBehaviorAttribute(typeof(GlobalErrorHandler))]
    [DataContract]
    public class BlogService : IBlog
    {
        private IBlogPostService BlogPostService;

        public IEnumerable<BlogPostModel> GetAll()
        {
            return BlogPostService.GetAll();
        }

    }
}
