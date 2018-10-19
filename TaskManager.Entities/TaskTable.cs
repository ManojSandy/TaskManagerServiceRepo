using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace TaskManager.Entities
{
    [Table("TaskManagerTable")]
    public class TaskTable
    {
        [Key]
        public int TaskId { get; set; }
        public string ParentTask { get; set; }
        [StringLength(50)]
        public string TaskName { get; set; }
        public int Priority { get; set; }
        [Column(TypeName ="Date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        public bool Deleted { get; set; }

    }
}
