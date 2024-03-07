namespace Heartify.Infrastructure.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllReadOnly<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;

        void Edit<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<int> SaveChangesAsync();
    }
}
