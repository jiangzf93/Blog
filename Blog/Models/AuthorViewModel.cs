using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class AuthorViewModel
    {
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        public Author Author { get; set; }
        public string Action { get; set; } = "AuthorCreate";
        public bool ReadOnly { get; set; } = false;
        public bool ShowAction { get; set; } = true;

    }
}
