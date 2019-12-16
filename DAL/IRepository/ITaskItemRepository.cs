using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    using ORM.Entities;

    public interface ITaskItemRepository
    {
        void Add(TaskItem entity);
        void Update(TaskItem entity);
        void Delete(int id);
        TaskItem GetByID(int id);
        List<TaskItem> CheckEndDate();
    }
}