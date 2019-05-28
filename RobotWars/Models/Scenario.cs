using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotWars.Models
{
    public class Scenario
    {
        public int width { get; set; }
        public int height { get; set; }
        public Robot robot { get; set; }

        public Scenario(int _width, int _height){
            this.width = _width;
            this.height = _height;
        }

        public bool createRobot(int x, int y, string direction){

            // Checking if the robot can be added in the position (scenario)
            if(y > this.height || x > this.width)
            {
                Console.WriteLine("The position of the robot is out of the scenario");
                return false;
            }

            // Checking if the robot can be added in the position (direcction)
            if (!(direction.ToLower().Equals("n") || direction.ToLower().Equals("s") || direction.ToLower().Equals("e") || direction.ToLower().Equals("w")))
            {
                Console.WriteLine("The direction only can be one of the four cardinal compass points (N, S, E and W).");
                return false;
            }

            // Creating new robot
            this.robot = new Robot(x, y, direction);
            return true;
        }

        public bool instructionForRobot(string instruction)
        {
            // Checking if the robot can be added in the position (direcction)
            if (!(instruction.ToLower().Equals("l") || instruction.ToLower().Equals("r") || instruction.ToLower().Equals("m")))
            {
                Console.WriteLine("There are only 3 valid instructions in the form of single alphabetic characters - ‘L’, ‘R’ and ‘M’.");
                return false;
            }

            // Checking if it is a direction instruction
            if (instruction.ToLower().Equals("l"))
            {
                switch(this.robot.direction.ToLower())
                {
                    case "n":
                        this.robot.direction = "w";
                        break;
                    case "w":
                        this.robot.direction = "s";
                        break;
                    case "s":
                        this.robot.direction = "e";
                        break;
                    case "e":
                        this.robot.direction = "n";
                        break;
                }
            }
            else if(instruction.ToLower().Equals("r"))
            {
                switch (this.robot.direction.ToLower())
                {
                    case "n":
                        this.robot.direction = "e";
                        break;
                    case "e":
                        this.robot.direction = "s";
                        break;
                    case "s":
                        this.robot.direction = "w";
                        break;
                    case "w":
                        this.robot.direction = "n";
                        break;
                }
            }
            else
            {
                // Checking direction
                int auxRobotX = this.robot.positionX;
                int auxRobotY = this.robot.positionY;
                switch (this.robot.direction.ToLower())
                {
                    case "n":
                        auxRobotY += 1;
                        break;
                    case "e":
                        auxRobotX += 1;
                        break;
                    case "s":
                        auxRobotY -= 1;
                        break;
                    case "w":
                        auxRobotX -= 1;
                        break;
                }

                // Checking if the position can be changed
                if((auxRobotY > -1 && auxRobotY <= this.height) && (auxRobotX > -1 && auxRobotX <= this.width))
                {
                    this.robot.positionY = auxRobotY;
                    this.robot.positionX = auxRobotX;
                }
                else{
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - ");
                    Console.WriteLine("Penalty: the robot will remain in the same position!! ");
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - ");
                    this.robot.penalties += 1;
                }
            }

            // Displaying robot position
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - ");
            Console.WriteLine("Postition x:" + this.robot.positionX + ", y:" + this.robot.positionY + ", d:" + this.robot.direction);
            Console.WriteLine("Penalties:" + this.robot.penalties);
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - ");
            return true;

        }
    }
}
