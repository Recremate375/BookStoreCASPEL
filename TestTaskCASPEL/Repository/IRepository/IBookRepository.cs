using TestTaskCASPEL.Models;

namespace TestTaskCASPEL.Repository.IRepository
{
    public interface IBookRepository : IBaseRepository<Books>
    {
        Task<List<Books>> GetBooksByName(string name);
        bool IsBookExist(string name);
        Task<List<Books>> GetBooksByDate(DateOnly releaseDate);
    }
}
