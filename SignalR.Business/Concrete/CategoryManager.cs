using System.Linq.Expressions;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Dto.Category;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Concrete;

public class CategoryManager:ICategoryService
{
    private readonly ICategoryDal _repositoryService;

    public CategoryManager(ICategoryDal repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void Add(Category entity)
    {
        _repositoryService.Add(entity);
    }

    public void Update(Category entity)
    {
        _repositoryService.Update(entity);
    }
    
    public int Count(Expression<Func<Category, bool>>? predicate = null)
    {
        return _repositoryService.Count(predicate);
    }

    public CategoryCountDto GetCategoryCountDetailed()
    {
        var allCategories = _repositoryService.Count();
        var activeCategories = _repositoryService.Count(category => category.Status);
        var passiveCategories = _repositoryService.Count(category => !category.Status);

        CategoryCountDto categoryCountDto = new CategoryCountDto
        {
            All = allCategories,
            Active = activeCategories,
            Passive = passiveCategories
        };

        return categoryCountDto;
    }

    public void Delete(Category entity)
    {
        _repositoryService.Delete(entity);
    }

    public Category? GetById(int id)
    {
        return _repositoryService.GetById(id);
    }

    public List<Category> GetAll(Expression<Func<Category, bool>>? predicate = null)
    {
        return _repositoryService.GetAll(predicate);
    }
}