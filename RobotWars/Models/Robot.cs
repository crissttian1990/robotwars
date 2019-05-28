using System;
namespace RobotWars.Models
{
    public class Robot
    {
        public int positionX { get; set; }
        public int positionY { get; set; }
        public string direction { get; set; }
        public int penalties { get; set; }

        public Robot(int x, int y, string direction)
        {
            this.positionX = x;
            this.positionY = y;
            this.direction = direction;
            this.penalties = 0;
        }
    }
}
