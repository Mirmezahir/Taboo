namespace Taboo.DTOs.WordDTO
{
    public class WordForGameDto
    {
        public  int  Id { get; set; }
        public string Text { get; set; }
        public List<string> BannedWord { get; set; }

    }
}
