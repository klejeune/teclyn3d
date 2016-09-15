namespace Assets.Core.ValueTypes
{
    public struct TileLocation
    {
        public int X { get { return y; } }
        public int Y { get { return x; } }

        private readonly int x;
        private readonly int y;

        public TileLocation(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}