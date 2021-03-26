namespace AeldreplejeCore.Core.Entity
{
    public class Route
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Shift Shift { get; set; }
    }
}