namespace WkChallenge.Core.Models;

public class Product : BaseModel<int>
{
	public string Name { get; set; }

	public Product(string name)
	{
		Name = name;
	}
}
