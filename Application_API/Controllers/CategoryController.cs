using BusinessObject;
using DataAccess.IRepositories;

namespace HE151124_Nguyen_Van_Nghia.Controllers
{
    public class CategoryController : BaseApiController<Category>
    {
        public CategoryController(ICategoryRepository categoryRepository) : base(categoryRepository)
        {

        }
    }
}
