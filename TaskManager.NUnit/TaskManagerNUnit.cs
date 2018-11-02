using System;

using TaskManager.WebAPI.Controllers;
using TaskManager.BL;
using TaskManager.Entities;
using System.Collections.Generic;
using Moq;
using TaskManager.DL;
using System.Linq;
using NUnit.Framework;

namespace TaskManager.NUnit
{
    [TestFixture]
    public class TaskManagerNUnit
    {
        private BusinessLayer task = new BusinessLayer();


        [TestCase]
        public void GetTasks()
        {
            List<TaskTable> tasks = task.GetAllTask().Where(i => i.TaskId.Equals(1)).ToList();
        }

        [TestCase]
        public void SaveTasks()
        {
            var tasks = new TaskTable { ParentTask = "", TaskName = "Adding Task", StartDate = Convert.ToDateTime("2018-10-18"), EndDate = Convert.ToDateTime("2018-10-18"), Priority = 20, Deleted = false };
            bool added = task.Add(tasks);
            Assert.AreEqual(true,added);
        }

        [TestCase]
        public void UpdateTask()
        {
            var tasks = new TaskTable { TaskId = 1, ParentTask = "", TaskName = "Updated", StartDate = Convert.ToDateTime("2018-10-18"), EndDate = Convert.ToDateTime("2018-10-18"), Priority = 20, Deleted = false };
            bool updated = task.Update(tasks.TaskId, tasks);
            Assert.AreEqual(true, updated);
        }

        [TestCase]
        public void DeleteTask()
        {
            var tasks = new TaskTable { ParentTask = "", TaskName = "to be deleted", StartDate = Convert.ToDateTime("2018-10-18"), EndDate = Convert.ToDateTime("2018-10-18"), Priority = 20, Deleted = false };
            task.Add(tasks);

            List<TaskTable> toBeDeleteTask = task.GetAllTask().Where(i => i.TaskName.Equals("to be deleted") && i.Deleted.Equals(false)).ToList(); 

            bool deleted = task.Delete(toBeDeleteTask[0].TaskId);
            Assert.AreEqual(true, deleted);
        }

    }
    }
