using AutoMapper;
using DataAccess.IRepositories;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    internal class CategoryRepository : GenericRepository<Category, BusinessObject.Category>, ICategoryRepository
    {
        public CategoryRepository(EStoreContext eStoreContext, IMapper mapper)
            : base(eStoreContext, mapper)
        {

        }
    }
}
