using WkChallenge.Core.Interfaces;

namespace WkChallenge.Core.Models;

public class BaseModel<T> : IAggregateRoot
{
	public T Id { get; set; }
}
