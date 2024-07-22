using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface ICoupenService
    {
        Task<ResponseDto?> GetCoupenAsync(string coupenCode);
        Task<ResponseDto?> GetAllCoupensAsync();
        Task<ResponseDto?> GetCoupenAsync(int id);
        Task<ResponseDto?> CreateCoupensAsync(CoupenDto coupenDto);
        Task<ResponseDto?> UpdateCoupensAsync(CoupenDto coupenDto);
        Task<ResponseDto?> DeleteCoupensAsync(int id);

    }
}
