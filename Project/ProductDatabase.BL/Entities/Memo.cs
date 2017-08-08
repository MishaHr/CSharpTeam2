namespace ProductDatabase.BL.Entities
{
    internal class Memo:BaseEntity
    {
        
        public string MemoText { get; set; }

        public Memo(int id):base (id)
        {
            
        }

        public override string ToString()
        {
            return string.Format($"{id};{MemoText}");
        }
    }
}
