using AutoMapper;
using TestTaskCASPEL.DTO.Book;
using TestTaskCASPEL.DTO.Order;
using TestTaskCASPEL.Models;

namespace TestTaskCASPEL.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
                   //Source, Destination
            CreateMap<Book, CreateBookDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, UpdateBookDTO>().ReverseMap();
            CreateMap<Order, CreateOrderDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();
        }
    }
}
