using DATN.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DATN.Infastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace DATN.Infastructure.Repositories.BaseRepository
{
    public class Repository<T> : IRepository<T> where T : Base
    {
        protected readonly ApplicationDbContext _context;
        protected readonly ApplicationDbContext _context2;


        public Repository(ApplicationDbContext context )
        {
            _context = context;
        }
        public Repository(ApplicationDbContext context, ApplicationDbContext context2)
        {
            _context = context;
            _context2 = context2;
        }
        //#region add
        //public async Task<T> BAddAsync(T entity)
        //{
        //    entity.TimingCreate = System.DateTime.Now;
        //    entity.IsDeleted = false;
        //    if (entity.Imei == "") return null;
        //    await _context.Set<T>().AddAsync(entity);
        //    await _context.SaveChangesAsync();
        //    return entity;
        //}
        //#endregion

        //#region delete
        //public async Task BDeleteAsync(T entity)
        //{
        //    entity.IsDeleted = true;
        //    _context.Entry(entity).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<T> BDeleteByImeiAsync(string imei)
        //{
        //    var entity = await _context.Set<T>().FindAsync(imei);
        //    if (entity != null)
        //    {
        //        if (entity.IsDeleted == false)
        //        {
        //            entity.IsDeleted = true;
        //            _context.Entry(entity).State = EntityState.Modified;
        //            await _context.SaveChangesAsync();
        //            return entity;
        //        }
        //        else return null;
        //    }
        //    else return null;


        //}
        //public async Task BDeleteAsync(Expression<Func<T, bool>> predicate)
        //{
        //    var listExist = _context.Set<T>().Where(a => a.IsDeleted == false);
        //    var listWithCondition = await listExist.Where(predicate).ToListAsync();
        //    foreach (var item in listWithCondition)
        //    {
        //        item.IsDeleted = true;
        //        _context.Entry(item).State = EntityState.Modified;
        //    }
        //    await _context.SaveChangesAsync();
        //}
        //#endregion

        //#region update
        //public async Task<T> BUpdateAsync(T entity)
        //{
        //    entity.TimingUpdate = System.DateTime.Now;
        //    entity.IsDeleted = false;
        //    if (entity.Imei == "") return null;
        //    _context.Entry(entity).State = EntityState.Modified;
        //    var a = await _context.Set<T>().FirstOrDefaultAsync(a => a.Imei.Equals(entity.Imei));
        //    if (a == null)
        //    {
        //        return null;
        //    }
        //    await _context.SaveChangesAsync();
        //    return entity;
        //}
        //public async Task<T> BUndoImeiAsync(T entity)
        //{
        //    entity.TimingUpdate = System.DateTime.Now;
        //    _context.Entry(entity).State = EntityState.Modified;
        //    var a = await _context.Set<T>().FirstOrDefaultAsync(a => a.Imei.Equals(entity.Imei) && a.IsDeleted.Equals(entity.IsDeleted));
        //    if (a != null)
        //    {
        //        entity.IsDeleted = false;
        //        await _context.SaveChangesAsync();
        //        return entity;
        //    }
        //    return null;
        //}

        //public async Task<T> BUpdateTPatchImeiAsync(string imei, JsonPatchDocument TModel)
        //{
        //    var entity = await _context.Set<T>().FindAsync(imei);
        //    entity.TimingUpdate = System.DateTime.Now;
        //    entity.IsDeleted = false;
        //    if (entity != null)
        //    {
        //        TModel.ApplyTo(entity);
        //        await _context.SaveChangesAsync();
        //        return entity;
        //    }
        //    return null;

        //}
        //#endregion

        #region get
        public async Task<T> BFistOrDefaultAsync(Func<T, bool> predicate)
        {
            var listUseCondition = _context.Set<T>().Where(a => a.IsDeleted == false);
            if (!listUseCondition.Any())
            {
                return null;
            }

            var listExist = await listUseCondition.ToListAsync();
            return listExist.FirstOrDefault(predicate);
        }
        //public async Task<T> BFistOrDefaultAsync()
        //{
        //    var listUseCondition = (IQueryable<T>)_context.Set<T>().Where(a => a.IsDeleted == false);
        //    if (!listUseCondition.Any())
        //    {
        //        return null;
        //    }
        //    var listExist = await listUseCondition.ToListAsync();
        //    return listExist.First();
        //}
        //public async Task<IReadOnlyList<T>> BGetAllAsync()
        //{
        //    return await _context.Set<T>().Where(a => a.IsDeleted == false).ToListAsync();
        //}



        //public async Task<IReadOnlyList<T>> BGetPagingAsync(int skip, int pageSize)
        //{
        //    return await _context.Set<T>().Where(a => a.IsDeleted == false).Skip(skip).Take(pageSize).ToListAsync();
        //}
        //public async Task<IReadOnlyList<T>> BGetAsync(Func<T, bool> predicate)
        //{
        //    var listExist = await _context.Set<T>().Where(a => a.IsDeleted == false).ToListAsync();
        //    return listExist.Where(predicate).ToList();
        //}
        //public async Task<int> BGetTotalAsync()
        //{
        //    return await _context.Set<T>().Where(a => a.IsDeleted == false).CountAsync();
        //}


        //public async Task<T> BGetByImeiAsync(string imei)
        //{
        //    var entity = await _context.Set<T>().FirstOrDefaultAsync(t => t.Imei.Equals(imei));
        //    _context.Entry(entity).State = EntityState.Detached;
        //    if (entity?.IsDeleted == true)
        //    {
        //        return null;
        //    }
        //    return entity;
        //}
        //public async Task<IReadOnlyList<T>> BGetMultipleImeiAsync(string imei)
        //{
        //    return await _context.Set<T>().Where(a => a.IsDeleted == false).Where(a => a.Imei == imei).ToListAsync();
        //}
        //public async Task<int> BGetTotalImeiAsync(string imei)
        //{
        //    return await _context.Set<T>().Where(a => a.IsDeleted == false).Where(a => a.Imei == imei).CountAsync();
        //}
        #endregion
    }
}