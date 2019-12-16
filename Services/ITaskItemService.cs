using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.ORM.Entities;

namespace Services
{
    public interface ITaskItemService
    {
        void Add(TaskItem entity);
        void Update(TaskItem entity);
        void Delete(int id);
        TaskItem GetByID(int id);
        List<TaskItem> CheckEndDate();
    }
}
