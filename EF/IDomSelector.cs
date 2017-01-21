using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils.EF
{
    public interface IDomSelector<TEntity, TResult>
        where TEntity : class
    {
        IQueryable<TResult> Select(IQueryable<TEntity> query);
    }
}
