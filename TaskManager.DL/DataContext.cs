using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities;
using System.Data.Entity;

namespace TaskManager.DL
{
    public class DataContext:DbContext
    {
        public DataContext() : base("name = TaskManagerConnectionString")
        {
            
        }
        public DbSet<TaskTable> Tasks { get; set; }
    }
}
