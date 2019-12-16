using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.IRepository;
using DAL.ORM.Entities;

namespace Services
{
    public class TaskItemService : ITaskItemService
    {
        private ITaskItemRepository _iTaskItemRepository;
        public TaskItemService(ITaskItemRepository iTaskItemRepository)
        {
            _iTaskItemRepository = iTaskItemRepository;
        }

        public void Add(TaskItem entity)
        {
            _iTaskItemRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _iTaskItemRepository.Delete(id);
        }

        public TaskItem GetByID(int id)
        {
            return _iTaskItemRepository.GetByID(id);
        }

        public void Update(TaskItem entity)
        {
            _iTaskItemRepository.Update(entity);
        }

        public List<TaskItem> CheckEndDate()
        {
            return _iTaskItemRepository.CheckEndDate();
        }
    }
}
