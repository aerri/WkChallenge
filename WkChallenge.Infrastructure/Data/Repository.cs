using WkChallenge.Core.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;

namespace WkChallenge.Infrastructure.Data;

public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
{
	public Repository(AppDbContext context) : base(context) { }
}
