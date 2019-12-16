using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Entities
{
    public class TaskItem : BaseEntity
    {
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
    }
}