namespace ProblemBank.Api.Models
{
    public class ProblemQuestion
    {
        public int Id { get; set; }

        public string QuestionId { get; set; } = "";

        public DateTime AddedAt { get; set; }
    }
}