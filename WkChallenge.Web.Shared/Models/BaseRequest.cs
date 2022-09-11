namespace WkChallenge.Web.Shared.Models;

public abstract class BaseRequest : BaseMessage
{
	protected BaseRequest(Guid correlationId) : base(correlationId) { }
}
