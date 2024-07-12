using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR8.Data;
using SignalR8.Models;

namespace SignalR8.Controllers;

 public class NurseRequestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _oHostEnvironment;

        public NurseRequestController(ApplicationDbContext context, IWebHostEnvironment oHostEnvironment)
        {
            _context = context;
            _oHostEnvironment = oHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
           
            var x = await _context.NurseRequest.ToListAsync();
            return View(x);
        }
         public IActionResult Create()
         {
             return View();
         }

        [HttpPost]
        public async Task<IActionResult> Create(AddNurseRequestViewModel addNurseRequest)
        {
            var nurseRequest = new NurseRequest()
            {
                ReqDate = addNurseRequest.ReqDate,
                ReqTime = addNurseRequest.ReqTime,
                EndDate = addNurseRequest.EndDate,
                EndTime = addNurseRequest.EndTime,
                UserId = addNurseRequest.UserId,
                Department = addNurseRequest.Department,
                StartPoint = addNurseRequest.StartPoint,
                EndPoint = addNurseRequest.EndPoint,
                MaterialType = addNurseRequest.MaterialType,
                UrentType = addNurseRequest.UrentType,
                PatientType = addNurseRequest.PatientType,
                PoterFname = addNurseRequest.PoterFname,
                Remark = addNurseRequest.Remark,
                QN = addNurseRequest.QN,
                QNName = addNurseRequest.QNName,
                QNAge = addNurseRequest.QNAge,
                QNSex = addNurseRequest.QNSex,
            };

             await _context.NurseRequest.AddAsync(nurseRequest);
             await _context.SaveChangesAsync();
            return RedirectToAction("Index","NurseRequest");
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var y = await _context.NurseRequest.FirstOrDefaultAsync(x => x.JobId == id);

            if (y != null)
            {
                var viewModel = new UpdateNurseRequestViewModel()
                {
                    JobId = y.JobId,
                    ReqDate = y.ReqDate,
                    ReqTime = y.ReqTime,
                    EndDate = y.EndDate,
                    EndTime = y.EndTime,
                    UserId = y.UserId,
                    Department = y.Department,
                    StartPoint = y.StartPoint,
                    EndPoint = y.EndPoint,
                    MaterialType = y.MaterialType,
                    UrentType = y.UrentType,
                    PatientType = y.PatientType,
                    PoterFname = y.PoterFname,
                    Remark = y.Remark,
                    QN = y.QN,
                    QNName = y.QNName,
                    QNAge = y.QNAge,
                    QNSex = y.QNSex,
                };

                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateNurseRequestViewModel model)
        {
            var z = await _context.NurseRequest.FindAsync(model.JobId);

            if (z != null)
            {
                z.ReqDate = model.ReqDate;
                z.ReqTime = model.ReqTime;
                z.EndDate = model.EndDate;
                z.EndTime = model.EndTime;
                z.UserId = model.UserId;
                z.Department = model.Department;
                z.StartPoint = model.StartPoint;
                z.EndPoint = model.EndPoint;
                z.MaterialType = model.MaterialType;
                z.UrentType = model.UrentType;
                z.PatientType = model.PatientType;
                z.PoterFname = model.PoterFname;
                z.Remark = model.Remark;
                z.QN = model.QN;
                z.QNName = model.QNName;
                z.QNAge = model.QNAge;
                z.QNSex = model.QNSex;

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
         [HttpPost]
        public async Task<IActionResult> Delete(UpdateNurseRequestViewModel model)
        {
            var a = await _context.NurseRequest.FindAsync(model.JobId);

            if (a != null)
            {
                _context.NurseRequest.Remove(a);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }