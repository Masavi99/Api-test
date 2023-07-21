using ApiTesting.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiTesting.EF
{
    public class ApiContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> Newslist { get; set; }
    }
}