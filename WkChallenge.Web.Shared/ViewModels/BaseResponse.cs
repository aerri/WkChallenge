namespace WkChallenge.Web.Shared.ViewModels;

public abstract class BaseResponse : BaseMessage
{
	protected BaseResponse(Guid correlationId) { _correlationId = correlationId; }
}
