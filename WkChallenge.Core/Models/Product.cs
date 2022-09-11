namespace WkChallenge.Core.Models;

public record Product : BaseModel<int>
{
	public string Name { get; set; } = string.Empty;
}
