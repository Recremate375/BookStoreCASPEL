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
            CreateMap<Books, CreateBookDTO>().ReverseMap();
            CreateMap<Books, BookDTO>().ReverseMap();
            CreateMap<Books, UpdateBookDTO>().ReverseMap();
            CreateMap<Orders, CreateOrderDTO>().ReverseMap();
            CreateMap<Orders, OrderDTO>().ReverseMap();
            CreateMap<Orders, UpdateOrderDTO>().ReverseMap();
        }
    }
}
