namespace WkChallenge.Web.Shared.Models;

public abstract class BaseResponse : BaseMessage
{
	public BaseResponse(Guid correlationId) : base(correlationId) { }

	public BaseResponse() : base(new Guid()) { }
}
