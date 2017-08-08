namespace ProductDatabase.BL.Entities
{
    internal class ShortDescription: BaseEntity
    {
        /// <summary>
        /// Клас який містить коротку інформацію про кожен товар
        /// </summary>
       
        public string DescriptionText { get; set; }

        public ShortDescription(int id): base(id)
        {
           
        }

        public override string ToString()
        {
            return string.Format($"{id};{DescriptionText}");
        }
    }
}
