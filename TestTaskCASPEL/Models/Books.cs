using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskCASPEL.Models
{
    
    public class Books
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
