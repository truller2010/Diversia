﻿#region KotikoBlog Header License

// // Solution: KotikoBlog
// // Project: KotikoBlog.Backend
// //
// // This file is included in the KotikoBlog solution.
// //
// // File created on 14/01/2016   14:38
// //
// // File Modified on 14/01/2016/   14:38
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

#endregion

namespace Diversia.Models.Response.BlogArchives
{
    /// <summary>
    /// 
    /// </summary>
    public class BlogArchivesResponse
    {
        public virtual IList<ArchiveResponse> Archives { get; set; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class ArchiveResponse
    {
        public virtual string year { get; set; }
        public virtual string Month { get; set; }
        public virtual string MonthName { get; set; }
        public virtual string Total { get; set; }
    }
}