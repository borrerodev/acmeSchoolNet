using Microsoft.EntityFrameworkCore;
using School.Domain.Abstractions;

namespace School.Infrastructure.Repositories;

internal abstract class Repository<T> where T : Entity 
{
    protected readonly SchoolDbContext dbContext;

    public Repository(SchoolDbContext context)
    {
        dbContext = context;
    }
   
   public void Add(T entity)
   {
       dbContext.Add(entity);
   }
}
