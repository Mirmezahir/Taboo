namespace Taboo.DTOs.GameDto
{
    public class GameGetDto
    {
        public Guid Id { get; set; }
        public int BannedWordCount { get; set; }
        public int FailCount { get; set; }
        public int SkipCount { get; set; }
        public int Score { get; set; }
        public int Time { get; set; }
        public int? SuccesAnswer { get; set; }
        public int? WrongAnswer { get; set; }
    }
}
