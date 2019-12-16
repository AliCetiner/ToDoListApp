using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    using DAL.ORM.Entities;

    public static class TaskItemGlobalObject
    {
        public static List<TaskItem> entityList = new List<TaskItem>();
    }
}