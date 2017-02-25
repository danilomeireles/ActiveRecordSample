using Castle.ActiveRecord;
using CastleActiveRecord.Persistence;
using NHibernate.Criterion;
using System;

namespace CastleActiveRecord.Entity
{
    [ActiveRecord(Table = "shopping_cart", Schema = "my_store")]
    public class ShoppingCart : GenericEntity<ShoppingCart>
    {
        [PrimaryKey(PrimaryKeyType.Sequence, "id", SequenceName = "my_store.shopping_cart_seq")]
        public int Id { get; set; }

        [Property("creation_date", NotNull = true)]
        public DateTime CreationDate { get; set; }

        [Property("is_canceled", NotNull = true)]
        public bool IsCanceled { get; private set; }

        [BelongsTo("customer_id", ForeignKey = "customer_fkey", NotNull = true)]
        public Customer Customer { get; set; }
        
        public void Cancel()
        {
            IsCanceled = true;                        
        }     
        
        public static ShoppingCart GetShoppingCartByCustomer(int customerId)
        {
            DetachedCriteria dc = DetachedCriteria.For<ShoppingCart>();
            dc.Add(Expression.Eq("Customer.Id", customerId));
            dc.Add(Expression.Eq("IsCanceled", false));
            return FindOne(dc);            
        }
    }
}