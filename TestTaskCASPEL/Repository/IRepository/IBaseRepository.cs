namespace TestTaskCASPEL.Repository.IRepository
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetByID(int id);
        Task Create(T item);
        void Update(T item);
        void Delete(int id);
        Task Save();
    }
}
