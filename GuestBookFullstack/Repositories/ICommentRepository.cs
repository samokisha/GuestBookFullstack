using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GuestBookFullstack.Model;

namespace GuestBookFullstack.Repositories
{
    public interface ICommentRepository
    {
        Task<SavedCommentModel> AddAsync(NewCommentModel entity);

        Task<SavedCommentModel> GetAsync(Guid id);

        Task<ICollection<SavedCommentModel>> GetAllAsync();
    }
}