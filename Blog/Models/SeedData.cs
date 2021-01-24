using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models
{
    public static class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {

            context.Database.Migrate();
            if (context.Authors.Count() == 0 && context.Articles.Count() == 0)
            {
                Author host = new Author { AuthorName = "海子", Introduction = "我是查海生", IsHost = true, Title = "海子的春暖花开" };


                context.Articles.AddRange(
                    new Article {Author= host,  Category = "诗歌", Text = "从明天起，做一个幸福的人",Title="面朝大海，春暖花开" });

                context.SaveChanges();
            }
        }

    }
}
