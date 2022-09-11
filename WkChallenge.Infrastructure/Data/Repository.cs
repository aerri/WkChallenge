using Ardalis.Specification.EntityFrameworkCore;
using WkChallenge.Core.Interfaces;

namespace WkChallenge.Infrastructure.Data;

public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
{
	public Repository(AppDbContext context) : base(context)
	{
	}
}
