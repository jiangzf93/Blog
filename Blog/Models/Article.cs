using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Blog.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set;}
        public string Category { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Text { get; set; }
        public string Publication { get; set; }
        public string Site { get; set; }
    }
}
