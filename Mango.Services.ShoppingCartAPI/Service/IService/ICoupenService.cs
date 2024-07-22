using Mango.Services.ShoppingCartAPI.Models.Dto;

namespace Mango.Services.ShoppingCartAPI.Service.IService
{
    public interface ICoupenService
    {
        Task<CoupenDto> GetCoupen(string couponCode);
    }
}
