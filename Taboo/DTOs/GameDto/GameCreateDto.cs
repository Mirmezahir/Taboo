﻿using Taboo.Entities;

namespace Taboo.DTOs.GameDto
{
    public class GameCreateDto
    {
     
        public int BannedWordCount { get; set; }
        public int FailCount { get; set; }
        public int Score { get; set; }
        public int SkipCount { get; set; }
        public int Time { get; set; }
      
        public string LanguageCode { get; set; } = null!;
   

    }
}
