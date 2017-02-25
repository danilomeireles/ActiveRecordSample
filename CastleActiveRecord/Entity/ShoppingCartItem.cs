using Castle.ActiveRecord;
using CastleActiveRecord.Persistence;
using NHibernate.Criterion;

namespace CastleActiveRecord.Entity
{
    [ActiveRecord(Table = "shopping_cart_item", Schema = "my_store")]
    public class ShoppingCartItem : GenericEntity<ShoppingCartItem>
    {
        [PrimaryKey(PrimaryKeyType.Sequence, "id", SequenceName = "my_store.shopping_cart_item_seq")]
        public int Id { get; set; }

        [BelongsTo("shopping_cart_id", ForeignKey = "shopping_cart_fkey", NotNull = true, UniqueKey = "shopping_cart_product_unique")]
        public ShoppingCart ShoppingCart { get; set; }

        [BelongsTo("product_id", ForeignKey = "product_fkey", NotNull = true, UniqueKey = "shopping_cart_product_unique")]
        public Product Product { get; set; }

        [Property("quantity", NotNull = true)]
        public int Quantity { get; set; }

        public static ShoppingCartItem[] GetItemsByShoppingCart(int shoppingCartId)
        {
            DetachedCriteria dc = DetachedCriteria.For<ShoppingCartItem>();
            dc.Add(Expression.Eq("ShoppingCart.Id", shoppingCartId));            
            return FindAll(dc);
        }
    }
}
