using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class ViewModelFactory
    {
        public static ArticleViewModel Detail(Article art, IEnumerable<Author> authors)
        {
            return new ArticleViewModel
            {
                Article = art,Action = "Detail",ReadOnly = true, ShowAction = false, Authors = authors
            };
        }
        public static ArticleViewModel Create(Article art, IEnumerable<Author> authors)
        {
            return new ArticleViewModel { Article = art, Authors = authors};
        }
        public static ArticleViewModel Edit(Article art,IEnumerable<Author> authors)
        {
            return new ArticleViewModel { Article = art, Action = "Edit", Authors=authors };
        }
        public static AuthorViewModel Home(IEnumerable<Author> authors,IEnumerable<Article> articles,Author host)
        {
            return new AuthorViewModel { Authors = authors, Articles = articles,Author=host };
        }
        public static AuthorViewModel AuthorDetail(Author auth)
        {
            return new AuthorViewModel { Author=auth,Action = "AuthorDetail",ReadOnly = true,ShowAction = false };
        }
        public static AuthorViewModel AuthorCreate(Author auth)
        {
            return new AuthorViewModel { Author = auth};
        }
        public static AuthorViewModel AuthorEdit(Author auth)
        {
            return new AuthorViewModel { Author = auth, Action = "AuthorEdit" };
        }

    }
}
