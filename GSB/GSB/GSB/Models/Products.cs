using SQLite;

namespace XamSQLite.Models
{
    //Declare les type + Nom des Libéllés de la Table
    public class Products
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Famille { get; set; }
        public int Quantity { get; set; }

    }
}
