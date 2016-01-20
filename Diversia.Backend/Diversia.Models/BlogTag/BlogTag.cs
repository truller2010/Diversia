#region Diversia Header License

// // Solution: Diversia
// // Project: Diversia.Models
// //
// // This file is included in the Diversia solution.
// //
// // File created on 14/01/2016   14:52
// //
// // File Modified on 14/01/2016/   14:52
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

using System.Collections.Generic;
using Diversia.Models.BlogPostTagMap;
using FluentNHibernate.Mapping;
using Newtonsoft.Json;

#endregion

namespace Diversia.Models.BlogTag
{
    /// <summary>
    /// 
    /// </summary>
    public class BlogTagModel
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string UrlSlug { get; set; }
        public virtual string Description { get; set; }

        [JsonIgnore]
        public virtual IList<BlogPostTagMapModel> Posts { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class BlogTagMap : ClassMap<BlogTagModel>
    {
        public BlogTagMap()
        {
            Table("BlogTag");
            LazyLoad();
            Id(x => x.ID);
            Map(x => x.Name).Length(50).Not.Nullable();
            Map(x => x.UrlSlug).Length(50).Not.Nullable();
            Map(x => x.Description).Length(200);
            HasMany(x => x.Posts).KeyColumn("Tag_id");
        }
    }
}