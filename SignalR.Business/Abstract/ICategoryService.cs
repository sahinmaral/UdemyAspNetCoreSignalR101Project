using SignalR.Dto.Category;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Abstract;

public interface ICategoryService:IGenericService<Category>
{
    public CategoryCountDto GetCategoryCountDetailed();
}