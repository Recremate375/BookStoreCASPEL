namespace TestTaskCASPEL.Repository.IRepository
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
