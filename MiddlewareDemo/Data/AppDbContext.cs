using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo
{
    public class AppDbContext
    {
        
        public void Add(Request request)
        {
            DB.DbList.Add(request);
        }
    }

    public class AppDbContext2 : DbContext
    {
        public AppDbContext2(DbContextOptions<DbContext> options) : base(options)
        { 
        
        }
    }

    public class DB
    {
        public static List<Request> DbList = new List<Request>();
    }
}
