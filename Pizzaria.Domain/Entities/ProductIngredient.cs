using Pizzaria.Domain.Entities.Base;

namespace Pizzaria.Domain.Entities
{
    public sealed class ProductIngredient : EntityBase
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } 

        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public ProductIngredient(Guid id, Guid productId, Guid ingredientId, DateTimeOffset date)
        {
            Id = id;
            ProductId = productId;
            IngredientId = ingredientId;
            CreatedDate = date;
        }
    }
}
