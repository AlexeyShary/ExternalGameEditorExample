namespace Sources.Database.Model
{
    public class CharacterActionEntity
    {
        public int Id { get; internal set; }
        public int CharacterId { get; internal set; }
        public string Action { get; internal set; }
    }
}