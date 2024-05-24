using System;

namespace MyDiaryApp.Models.AppDbContext.Entities
{
    public class Diary
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
