using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoAPP.Models;

namespace TodoAPP.Data
{
    public class TodoAPPContext : DbContext
    {
        public TodoAPPContext (DbContextOptions<TodoAPPContext> options)
            : base(options)
        {
        }

        public DbSet<TodoAPP.Models.Tarefa> Tarefa { get; set; }
    }
}
