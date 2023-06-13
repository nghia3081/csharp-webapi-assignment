using DataAccess.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace HE151124_Nguyen_Van_Nghia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController<T> : ControllerBase
        where T : class
    {
        protected readonly IGenericRepository<T> repository;
        public BaseApiController(IGenericRepository<T> genericRepository)
        {
            repository = genericRepository;
        }
        [HttpGet]
        public virtual async Task<IEnumerable<T>> Get(string? include)
        {
            return await repository.GetAll(include);
        }
        [HttpGet("{id}")]
        public virtual async Task<T> Get(int id)
        {
            return await repository.Find(entityKeys: id);
        }
        [HttpPost]
        public virtual async Task<T> Create(T businessObject)
        {
            return await repository.Create(businessObject);
        }
        [HttpPut]
        public virtual async Task<T> Update(T businessObject)
        {
            return await repository.Update(businessObject);
        }
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await repository.Delete(entityKeys: id);
            return NoContent();
        }
    }
}
