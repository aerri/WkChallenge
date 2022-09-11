namespace WkChallenge.Core.Models;

public record Category : BaseModel<int>
{
	public string Name { get; set; } = string.Empty;
}
