using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManager.WebAPI.Controllers;
using TaskManager.BL;
using TaskManager.Entities;
using System.Collections.Generic;

namespace TaskManager.NUnit
{
    [TestClass]
    public class TaskManager
    {
        [TestMethod]
        public void GetAllTasks()
        {
            var testTasks = GetTestTasks();
            var controller = new TaskManagerController();

            var result = controller.GetAllTasks() as List<TaskTable>;
            Assert.AreEqual(testTasks.Count, result.Count);
        }

        private List<TaskTable> GetTestTasks()
        {
            var testProducts = new List<TaskTable>();
            testProducts.Add(new TaskTable { TaskId = 1, ParentTask = "", TaskName = "Sandy", StartDate = Convert.ToDateTime("2018-10-18"), EndDate = Convert.ToDateTime("2018-10-18"), Priority = 20, Deleted = false});
           
            return testProducts;
        }
    }
}
