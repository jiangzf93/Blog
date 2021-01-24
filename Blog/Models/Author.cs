using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Introduction { get; set; }
        public string Title { get; set; }
        public bool IsHost { get; set; } = false;
        public IEnumerable<Article> Articles { get; set; }
    }
}
