

using Mango.Services.ShoppingCartAPI.Models.Dto;
using Mango.Services.ShoppingCartAPI.Service.IService;
using Newtonsoft.Json;

namespace Mango.Services.ShoppingCartAPI.Service
{
    public class CoupenService : ICoupenService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CoupenService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<CoupenDto> GetCoupen(string CoupenCode)
        {
            var client = _httpClientFactory.CreateClient("Coupen");
            var response = await client.GetAsync($"/api/Coupen/GetByCode/{CoupenCode}");
            var apiContet = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContet);
            if (resp != null && resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CoupenDto>(Convert.ToString(resp.Result));
            }
            return new CoupenDto();
        }
    }
}
