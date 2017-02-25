using Castle.ActiveRecord;
using CastleActiveRecord.Persistence;

namespace CastleActiveRecord.Entity
{
    [ActiveRecord(Table = "category", Schema = "my_store")]
    public class Category : GenericEntity<Category>
    {
        [PrimaryKey(PrimaryKeyType.Sequence, "id", SequenceName = "my_store.category_seq")]
        public int Id { get; set; }

        [Property("name", SqlType = "varchar", NotNull = true, Unique = true, UniqueKey = "name_unique")]
        public string Name { get; set; }
    }
}