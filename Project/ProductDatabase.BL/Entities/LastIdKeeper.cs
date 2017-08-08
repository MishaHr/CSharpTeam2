namespace ProductDatabase.BL.Entities
{
    internal class LastIdKeeper:BaseEntity
    {

        internal int LastProductId { get; set; }
        public int LastCategoryId { get; set; }
        public int LastManufacturerId { get; set; }
        public int LastSupplierId { get; set; }

        internal LastIdKeeper(int id): base(id)
        {
            
        }

        public override string ToString()
        {
            return string.Format($"{id};{LastProductId};{LastCategoryId};{LastManufacturerId};{LastSupplierId}");
        }
    }
}
