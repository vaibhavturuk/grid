using vaibhavgrid.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace vaibhavgrid.Controllers
{
    public class JQGridController : Controller
    {
        SalesContext db = new SalesContext();
        // GET: JQGrid
        //public JsonResult GetStudents(string sidx, string sort, int page=1, int rows=1)
        //{
        //    SalesContext db = new SalesContext();
        //    sort = (sort == null) ? "" : sort;
        //    int pageIndex = Convert.ToInt32(page) - 1;
        //    int pageSize = rows;

        //    var userList = db.TblCustomers.Select(
        //            t => new
        //            {
        //                t.CustomerId,
        //                t.CustomerName,
        //                t.Address,
        //                t.MobileNo,
        //                t.PhoneNo,
        //                t.City,
        //                t.District,
        //                t.State
        //            });
        //    int totalRecords = userList.Count();
        //    var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
        //    if (sort.ToUpper() == "DESC")
        //    {
        //        userList = userList.OrderByDescending(t => t.CustomerName);
        //        userList = userList.Skip(pageIndex * pageSize).Take(pageSize);
        //    }
        //    else
        //    {
        //        userList = userList.OrderBy(t => t.CustomerName);
        //        userList = userList.Skip(pageIndex * pageSize).Take(pageSize);
        //    }
        //    var jsonData = new
        //    {
        //        total = totalPages,
        //        page,
        //        records = totalRecords,
        //        rows = userList
        //    };
        //    return Json(jsonData, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult GetValues(string sidx, string sord, int page = 1, int rows = 1) //Gets the todo Lists.  
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var Results = db.TblCustomers.Select(
                t => new
                {
                    t.CustomerId,
                    t.CustomerName,
                    t.Address,
                    t.MobileNo,
                    t.PhoneNo,
                    t.City,
                    t.District,
                    t.State
                });
            int totalRecords = Results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                Results = Results.OrderByDescending(s => s.CustomerId);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Results = Results.OrderBy(s => s.CustomerId);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Results
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {

            //// Get the model (setup) of the grid defined in the /Models folder.
            //var gridModel = new OrdersJqGridModel();
            //var ordersGrid = gridModel.OrdersGrid;

            //// Setting the DataUrl to an action (method) in the controller is required.
            //// This action will return the data needed by the grid
            //ordersGrid.DataUrl = Url.Action("SearchGridDataRequested");

            //// customize the default Orders grid model with custom settings
            //// NOTE: you need to call this method in the action that fetches the data as well,
            //// so that the models match
            //SetUpGrid(ordersGrid);

            //// Pass the custmomized grid model to the View
            //return View(gridModel);
            return View();
        }
    }
}