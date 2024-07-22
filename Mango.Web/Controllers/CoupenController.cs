using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CoupenController : Controller
    {
        private readonly ICoupenService _coupenService;
        public CoupenController(ICoupenService coupenService)
        {
            _coupenService = coupenService;
        }
        public async Task<IActionResult> CoupenIndex()
        {
            List<CoupenDto>? list = new();
            ResponseDto? response = await _coupenService.GetAllCoupensAsync();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CoupenDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        public async Task<IActionResult> CoupenCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CoupenCreate(CoupenDto coupenDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? responseDto = await _coupenService.CreateCoupensAsync(coupenDto);
                if (responseDto != null && responseDto.IsSuccess)
                {
                    TempData["success"] = "Coupen created successfully!";
                    return RedirectToAction(nameof(CoupenIndex));
                }
            }
            return View(coupenDto);
        }

        public async Task<IActionResult> CoupenDelete(int coupenId)
        {
            ResponseDto? responseDto = await _coupenService.GetCoupenAsync(coupenId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                CoupenDto? model = JsonConvert.DeserializeObject<CoupenDto>(Convert.ToString(responseDto?.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CoupenDelete(CoupenDto coupenDto)
        {
            ResponseDto? responseDto = await _coupenService.DeleteCoupensAsync(coupenDto.CoupenId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                TempData["success"] = "Coupen deleted successfully!";
                return RedirectToAction(nameof(CoupenIndex));
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }

            return View(coupenDto);
        }

    }
}
