using BusinessObject;

namespace DataAccess.IRepositories
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        public IEnumerable<SaleReportModel> GetSaleReports(DateTime startDate, DateTime endDate, bool descendingOrder = true);
    }
}
