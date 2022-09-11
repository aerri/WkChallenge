namespace WkChallenge.Web.Shared.Models;

public abstract class BaseMessage
{
	public Guid CorrelationId { get; }

	protected BaseMessage(Guid correlationId)
	{
		CorrelationId = correlationId;
	}
}
