using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApp.Services;
using WebApp.Models.View_Models;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SalesRecordsController : Controller
    {

        private readonly SalesRecordsService _salesRecordService;
        private readonly SellerService _sellerService;

        public SalesRecordsController(SalesRecordsService salesRecordService, SellerService sellerService)
        {
            _salesRecordService = salesRecordService;
            _sellerService = sellerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {

            if(!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year,1,1);
            }

            if(!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }


            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordService.FindByDateAsync(minDate,maxDate);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {

            if(!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year,1,1);
            }

            if(!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordService.FindByDateGroupingAsync(minDate,maxDate);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var sellers = await _sellerService.FindAllAsync();
            var viewModel = new SalesRecordViewModel{Sellers = sellers};
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (SalesRecord salesRecord)
        {
            await _salesRecordService.InsertAsync(salesRecord);
            return RedirectToAction(nameof(SimpleSearch));
        }
    }
}