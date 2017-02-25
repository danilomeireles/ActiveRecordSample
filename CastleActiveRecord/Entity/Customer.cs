using Castle.ActiveRecord;
using CastleActiveRecord.Persistence;

namespace CastleActiveRecord.Entity
{
    [ActiveRecord(Table = "customer", Schema = "my_store")]
    public class Customer : GenericEntity<Customer>
    {
        [PrimaryKey(PrimaryKeyType.Sequence, "id", SequenceName = "my_store.customer_seq")]
        public int Id { get; set; }

        [Property("first_name", SqlType = "varchar", NotNull = true)]
        public string FirstName { get; set; }

        [Property("last_name", SqlType = "varchar", NotNull = true)]
        public string LastName { get; set; }     
        
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }  
    }
}
