using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GuestBookFullstack.Model;
using GuestBookFullstack.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GuestBookFullstack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ILogger<CommentsController> _logger;
        private readonly ICommentRepository _repository;

        public CommentsController(ILogger<CommentsController> logger, ICommentRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public async Task<SavedCommentModel> Add([FromBody] NewCommentModel model)
        {
            return await _repository.AddAsync(model);
        }

        [HttpGet("{id:guid}")]
        public async Task<SavedCommentModel> GetById(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<SavedCommentModel>> GetAll()
        {
            return await _repository.GetAllAsync();
        }
    }
}