using AutoMapper;
using LibraryManegerBackend.Core.Models;
using MessangerBackend.DTO;

namespace MessangerBackend.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Author, AuthorDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Book, BookDTO>().ReverseMap();
        
        CreateMap<Borrow, BorrowDTO>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username)) 
            .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title)); 

        CreateMap<BorrowDTO, Borrow>()
            .ForMember(dest => dest.User, opt => opt.Ignore()) 
            .ForMember(dest => dest.Book, opt => opt.Ignore());
        
    }

   
}