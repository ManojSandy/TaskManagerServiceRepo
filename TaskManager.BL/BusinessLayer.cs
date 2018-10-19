using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities;
using TaskManager.DL;
using System.Data.Entity;

namespace TaskManager.BL
{
    public class BusinessLayer
    {
        private DataContext db = new DataContext();

        public bool Add(TaskTable tasks)
        {
            try
            {
                tasks.ParentTask = !string.IsNullOrEmpty(tasks.ParentTask) ? tasks.ParentTask : string.Empty;
                db.Tasks.Add(tasks);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        public DbSet<TaskTable> GetAllTask()
        {
            return db.Tasks;
        }

        public bool Delete(int taskId)
        {
            try
            {
                var query = (from update in db.Tasks.Where(x => x.TaskId == taskId)
                             select update).SingleOrDefault();
                if (query != null)
                {
                    query.TaskId = taskId;
                    query.Deleted = true;

                    db.Entry(query).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(int taskId, TaskTable tasks)
        {
            try
            {
                var query = (from update in db.Tasks.Where(x => x.TaskId == taskId)
                             select update).SingleOrDefault();
                if (query != null)
                {
                    query.TaskId = taskId;
                    query.ParentTask = !string.IsNullOrEmpty(tasks.ParentTask)
                        ? tasks.ParentTask : string.Empty;
                    query.StartDate = tasks.StartDate;
                    query.EndDate = tasks.EndDate;
                    query.Priority = tasks.Priority;
                    query.TaskName = tasks.TaskName;

                    db.Entry(query).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
