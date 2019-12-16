using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Services;
using DAL.ORM;
using DAL.ORM.Entities;

namespace ToDoListApplication.Controllers
{
    public class HomeController : Controller
    {
        private ITaskItemService _iTaskItemService;

        public HomeController(ITaskItemService iTaskItemService)
        {
            _iTaskItemService = iTaskItemService;
        }

        public ActionResult Index()
        {
            return View(TaskItemGlobalObject.entityList);
        }

        [HttpPost]
        public JsonResult AddItem(TaskItem entity)
        {
            _iTaskItemService.Add(entity);

            return Json(entity);
        }

        [HttpPost]
        public JsonResult DeleteItem(int id)
        {
            _iTaskItemService.Delete(id);

            return Json(id);
        }

        [HttpPost]
        public JsonResult GetItem(int id)
        {
            TaskItem entity = _iTaskItemService.GetByID(id);

            return Json(entity);
        }

        [HttpPost]
        public JsonResult UpdateItem(TaskItem entity)
        {
            _iTaskItemService.Update(entity);

            return Json(entity);
        }

        [HttpPost]
        public JsonResult CheckItemsEndDate()
        {
            List<TaskItem> taskItems = _iTaskItemService.CheckEndDate();

            return Json(taskItems);
        }


    }
}