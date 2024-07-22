using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class CoupenService : ICoupenService
    {
        private readonly IBaseService _baseService;
        public CoupenService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateCoupensAsync(CoupenDto coupenDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = coupenDto,
                Url = SD.CoupenAPIBase + "/api/coupen/"
            });
        }

        public async Task<ResponseDto?> DeleteCoupensAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CoupenAPIBase + "/api/coupen/" + id
            });
        }

        public async Task<ResponseDto?> GetAllCoupensAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CoupenAPIBase + "/api/coupen"
            });
        }

        public async Task<ResponseDto?> GetCoupenAsync(string coupenCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CoupenAPIBase + "/api/coupen/GetByCode" + coupenCode
            });
        }

        public async Task<ResponseDto?> GetCoupenAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CoupenAPIBase + "/api/coupen/" + id
            });
        }

        public async Task<ResponseDto?> UpdateCoupensAsync(CoupenDto coupenDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = coupenDto,
                Url = SD.CoupenAPIBase + "/api/coupen/"
            });
        }
    }
}
