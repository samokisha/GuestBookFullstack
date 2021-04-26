using AutoMapper;
using GuestBookFullstack.Data.Entities;
using GuestBookFullstack.Model;

namespace GuestBookFullstack.MapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentTypeModel, CommentType>();
            CreateMap<GuestModel, Guest>();
            CreateMap<NewCommentModel, Comment>();
            
            CreateMap<CommentType, CommentTypeModel>();
            CreateMap<Guest, GuestModel>();
            CreateMap<Comment, SavedCommentModel>();
        }
    }
}