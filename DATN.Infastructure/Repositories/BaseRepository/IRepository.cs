using DATN.Core.Common;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.BaseRepository
{
    public interface IRepository<T> where T : Base
    {
    //    #region add
    //    Task<T> BAddAsync(T entity);
    //    #endregion

    //    #region delete
    //    Task BDeleteAsync(T entity);
    //    Task<T> BDeleteByImeiAsync(string imei);
    //    Task BDeleteAsync(Expression<Func<T, bool>> predicate);
    //    #endregion

    //    #region update
    //    Task<T> BUpdateAsync(T entity);
    //    Task<T> BUndoImeiAsync(T entity);
    //    Task<T> BUpdateTPatchImeiAsync(string imei, JsonPatchDocument TModel);
    //    #endregion

    //    #region get
        Task<T> BFistOrDefaultAsync(Func<T, bool> predicate);
    //    Task<T> BFistOrDefaultAsync();
    //    Task<IReadOnlyList<T>> BGetAllAsync();

    //    Task<IReadOnlyList<T>> BGetPagingAsync(int skip, int pageSize);
    //    Task<IReadOnlyList<T>> BGetAsync(Func<T, bool> predicate);
    //    Task<int> BGetTotalAsync();

    //    Task<T> BGetByImeiAsync(string imei);
    //    Task<IReadOnlyList<T>> BGetMultipleImeiAsync(string imei);
    //    Task<int> BGetTotalImeiAsync(string imei);
    //    #endregion

    }
}
