using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProblemBank.Api.Data;
using ProblemBank.Api.Models;

namespace ProblemBank.Api.Controllers
{
    [ApiController]
    [Route("api/problem-questions")]
    public class ProblemQuestionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProblemQuestionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return await _context.ProblemQuestions
                .Select(q => q.QuestionId)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProblemRequest request)
        {
            var exists = await _context.ProblemQuestions
                .AnyAsync(q => q.QuestionId == request.QuestionId);

            if (exists) return Conflict();

            _context.ProblemQuestions.Add(new ProblemQuestion
            {
                QuestionId = request.QuestionId,
                AddedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{questionId}")]
        public async Task<IActionResult> Delete(string questionId)
        {
            var item = await _context.ProblemQuestions
                .FirstOrDefaultAsync(q => q.QuestionId == questionId);

            if (item == null) return NotFound();

            _context.ProblemQuestions.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Clear()
        {
            _context.ProblemQuestions.RemoveRange(_context.ProblemQuestions);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    public class AddProblemRequest
    {
        public string QuestionId { get; set; } = "";
    }
}