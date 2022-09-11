namespace WkChallenge.Web.Shared.ViewModels;

public abstract class BaseResponse : BaseMessage
{
	protected BaseResponse(Guid correlationId) { base._correlationId = correlationId; }

	protected BaseResponse() { }
}
