﻿#region Diversia Header License

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

using Diversia.Core.Filter;
using Diversia.Core.Pager;
using Diversia.Models.BlogArchives;
using Diversia.Models.BlogPost;
using Diversia.Repository.Abstract;

#endregion

namespace Diversia.Repository.BlogPost
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBlogPostRepository : ISupportsSave<BlogPostModel, int>, IDao<BlogPostModel, int>,
        IQueryableDao<BlogPostModel, int>, ISearchableDao<BlogPostModel, int, SearchFilter>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Page<BlogPostModel> PaginatedByTag(FindRequestImpl<SearchFilter> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Page<BlogPostModel> PaginatedByCategory(FindRequestImpl<SearchFilter> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Page<BlogPostModel> PaginatedByIdTitle(FindRequestImpl<SearchFilter> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Page<BlogPostModel> PaginatedByArchives(FindRequestImpl<SearchFilter> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        BlogArchivesModel GetArchives(int year);
    }
}