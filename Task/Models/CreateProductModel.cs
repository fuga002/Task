using System.Globalization;

namespace Task.Models;

public class CreateProductModel
{
    public required string Name { get; set; }

    public required string Description { get; set; }
    public required string PriceString { get; set; }

    public required int CategoryId { get; set; }

    public required decimal Price
    {
        get => Convert.ToDecimal(PriceString);
        init => PriceString = value.ToString(CultureInfo.InvariantCulture);
    }
}