using AutoMapper;
using BusinessObject;
using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    internal class OrderDetailRepository : GenericRepository<Models.OrderDetail, BusinessObject.OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(EStoreContext eStoreContext, IMapper mapper) : base(eStoreContext, mapper) { }

        public IEnumerable<SaleReportModel> GetSaleReports(DateTime startDate, DateTime endDate, bool descendingOrder = true)
        {
            var temp = Set.Include(ordd => ordd.Order).Include(ordd => ordd.Product).Where(ordd => ordd.Order.OrderDate >= startDate && ordd.Order.OrderDate <= endDate)
                .GroupBy(ordd => new { ordd.ProductId })
                .Select(grp => new SaleReportModel()
                {
                    ProductId = grp.Key.ProductId,
                    TotalMoneySale = (grp.Sum(groupData => groupData.Quantity) * grp.Sum(groupData => groupData.UnitPrice)) * (decimal)grp.Sum(groupData => groupData.Discount ?? 100) / 100,
                    TotalQuantitySale = grp.Sum(groupData => groupData.Quantity)

                });
            var data = from dt in temp
                       join product in context.Products
                       on dt.ProductId equals product.ProductId
                       select new SaleReportModel()
                       {
                           Product = mapper.Map<Models.Product, BusinessObject.Product>(product),
                           ProductId = product.ProductId,
                           TotalMoneySale = dt.TotalMoneySale,
                           TotalQuantitySale = dt.TotalQuantitySale
                       };
            return data.OrderByDescending(dt => dt.TotalMoneySale);

        }
    }
}
