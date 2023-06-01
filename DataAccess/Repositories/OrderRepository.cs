using AutoMapper;
using BusinessObject;
using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    internal class OrderRepository : GenericRepository<Models.Order, BusinessObject.Order>, IOrderRepository
    {
        public OrderRepository(EStoreContext eStoreContext, IMapper mapper) : base(eStoreContext, mapper) { }
    }
}
