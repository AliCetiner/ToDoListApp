using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    using ORM;
    using ORM.Entities;    
    using IRepository;

    public class TaskItemRepository : ITaskItemRepository
    {
        public void Add(TaskItem entity)
        {
            int lastID = TaskItemGlobalObject.entityList.Count > 0 
                        ? TaskItemGlobalObject.entityList.OrderByDescending(x => x.ID).FirstOrDefault().ID 
                        : 0;
            entity.ID = ++lastID;
            TaskItemGlobalObject.entityList.Add(entity);
        }

        public void Update(TaskItem entity)
        {
            foreach (TaskItem item in TaskItemGlobalObject.entityList)
            {
                if (item.ID == entity.ID)
                {
                    item.Description = entity.Description;
                    item.EndDate = entity.EndDate;
                }
            }
        }

        public void Delete(int id)
        {
            TaskItemGlobalObject.entityList.RemoveAll(x => x.ID == id);
        }

        public TaskItem GetByID(int id)
        {
            TaskItem entity = TaskItemGlobalObject.entityList.Where(x => x.ID == id).FirstOrDefault();

            return entity;
        }


        public List<TaskItem> CheckEndDate()
        {
            List<TaskItem> resultList = TaskItemGlobalObject.entityList
               .Where(x => x.EndDate.Date == DateTime.Now.Date && x.EndDate.Hour == DateTime.Now.Hour && x.EndDate.Minute == DateTime.Now.Minute)
               .ToList();

            return resultList;
        }


    }
}