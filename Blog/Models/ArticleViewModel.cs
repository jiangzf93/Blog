using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class ArticleViewModel
    {
        public Article Article { get; set; }
        public string Action { get; set; } = "Create";
        public bool ReadOnly { get; set; } = false;
        public bool ShowAction { get; set; } = true;
        public IEnumerable<Author> Authors { get; set; } = Enumerable.Empty<Author>();

    }
}
