using AutoMapper;
using LibraryManegerBackend.Core.Models;
using MessangerBackend.DTO;
using MessangerBackend.DTO.Response;

namespace MessangerBackend.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Author, AuthorDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Book, BookRequest>().ReverseMap();
        CreateMap<Book, BookResponse>().ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        
        CreateMap<Borrow, BorrowDTO>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username)) 
            .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title)); 

        CreateMap<BorrowDTO, Borrow>()
            .ForMember(dest => dest.User, opt => opt.Ignore()) 
            .ForMember(dest => dest.Book, opt => opt.Ignore());
        
    }

   
}