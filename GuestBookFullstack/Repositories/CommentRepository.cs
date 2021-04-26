using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GuestBookFullstack.Data;
using GuestBookFullstack.Data.Entities;
using GuestBookFullstack.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GuestBookFullstack.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ILogger<CommentRepository> _logger;
        private readonly GuestBookContext _context;
        private readonly IMapper _mapper;

        public CommentRepository( ILogger<CommentRepository> logger, GuestBookContext context, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SavedCommentModel> AddAsync(NewCommentModel comment)
        {
            var entry = await _context.Comments.AddAsync(_mapper.Map<Comment>(comment));
            await _context.SaveChangesAsync();
            
            _logger.LogDebug("Added new comment. Id: {Id}", entry.Entity.Id);
            
            return _mapper.Map<SavedCommentModel>(entry.Entity);
        }

        public async Task<SavedCommentModel> GetAsync(Guid id)
        {
            var comment = await _context
                .Comments
                .Where(c => id.Equals(c.Id))
                .Include(c => c.Author)
                .FirstAsync();

            _logger.LogDebug("Find comment by id {Id}. Found: {Status}", id, comment != null);
            
            return _mapper.Map<SavedCommentModel>(comment);
        }

        public async Task<ICollection<SavedCommentModel>> GetAllAsync()
        {
            var comments = await _context
                .Comments
                .Include(c => c.Author)
                .OrderByDescending(comment => comment.CreatedAt)
                .ToListAsync();

            _logger.LogDebug("Get all comments. Count: {Count}", comments.Count);

            return _mapper.Map<ICollection<SavedCommentModel>>(comments);
        }
    }
}