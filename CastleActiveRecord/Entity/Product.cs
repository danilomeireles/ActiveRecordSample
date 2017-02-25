using Castle.ActiveRecord;
using CastleActiveRecord.Persistence;
using NHibernate.Criterion;

namespace CastleActiveRecord.Entity
{
    [ActiveRecord(Table="product", Schema="my_store")]
    public class Product : GenericEntity<Product>
    {
        [PrimaryKey(PrimaryKeyType.Sequence, "id", SequenceName = "my_store.product_seq")]
        public int Id { get; set; }

        [Property("name", SqlType="varchar", NotNull = true)]
        public string Name { get; set; }
        
        [Property("price", SqlType="money", NotNull = true)]
        public decimal Price { get; set; }

        [BelongsTo("category_id", ForeignKey = "category_fkey", NotNull = true)]
        public Category Category { get; set; }

        public static Product[] GetProductsByCategory(int categoryId)
        {
            DetachedCriteria dc = DetachedCriteria.For<Product>();
            dc.Add(Expression.Eq("Category.Id", categoryId));
            dc.AddOrder(Order.Asc("Name"));
            return FindAll(dc);
        }
    }
}
