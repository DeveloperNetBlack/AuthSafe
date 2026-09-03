using System;
using System.Collections.Generic;
using System.Text;

namespace AuthSafe.Infrastructure.CrossCutting.Wrappers
{
    public class PaginationResult<T> where T : class
    {
        public int Count { get; set; }

        public IQueryable<T> Entities { get; set; } = null!;

    }
}
