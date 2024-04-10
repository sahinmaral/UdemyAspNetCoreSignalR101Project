using System.Linq.Expressions;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Concrete;

public class TestimonialManager:ITestimonialService
{
    private readonly ITestimonialDal _repositoryService;

    public TestimonialManager(ITestimonialDal repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void Add(Testimonial entity)
    {
        _repositoryService.Add(entity);
    }

    public void Update(Testimonial entity)
    {
        _repositoryService.Update(entity);
    }

    public void Delete(Testimonial entity)
    {
        _repositoryService.Delete(entity);
    }

    public Testimonial? GetById(int id)
    {
        return _repositoryService.GetById(id);
    }
    
    public int Count(Expression<Func<Testimonial, bool>>? predicate = null)
    {
        return _repositoryService.Count(predicate);
    }

    public List<Testimonial> GetAll(Expression<Func<Testimonial, bool>>? predicate = null)
    {
        return _repositoryService.GetAll(predicate);
    }
}