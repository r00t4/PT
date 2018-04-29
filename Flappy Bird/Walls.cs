using System.Drawing;

namespace Flappy
{
    public class Walls
    {
        Rectangle rUp,rLow;
        public Walls(Rectangle rUp, Rectangle rLow)
        {
            this.rUp = rUp;
            this.rLow = rLow;
        }
    }
}