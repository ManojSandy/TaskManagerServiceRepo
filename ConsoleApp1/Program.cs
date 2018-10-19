using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BL;
using TaskManager.DL;
using TaskManager.Entities;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BusinessLayer bl = new BusinessLayer();
                bl.Add(new TaskManager.Entities.TaskTable() { TaskId=1, ParentTaskId = 1, TaskName="First Task", Priority = 1, StartDate = System.DateTime.Now, EndDate = System.DateTime.Now });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
