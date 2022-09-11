using WkChallenge.Core.Interfaces;

namespace WkChallenge.Core.Models;

public abstract record BaseModel<T> : IAggregateRoot
{
	public T Id { get; init; }
}
