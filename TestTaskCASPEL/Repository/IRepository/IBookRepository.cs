using TestTaskCASPEL.Models;

namespace TestTaskCASPEL.Repository.IRepository
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<List<Book>> GetBooksByName(string name);
        bool IsBookExist(string name);
        Task<List<Book>> GetBooksByDate(DateTime releaseDate);
        Task<List<Book>> GetBooksById(int[] id);
    }
}
