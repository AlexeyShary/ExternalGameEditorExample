namespace Sources.Database.Model
{
    public class LocationObjectEntity
    {
        public int Id { get; internal set; }
        public int CharacterId { get; internal set; }
        public int SpawnPosX { get; internal set; }
        public int SpawnPosY { get; internal set; }
    }
}