namespace Mango.Web.Models
{
    public class CoupenDto
    {
        public int CoupenId { get; set; }
        public string CoupenCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
