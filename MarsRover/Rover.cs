using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }


        public Rover(int position)
        {
            this.Position = position;
            this.Mode = "NORMAL";            
            this.GeneratorWatts = 110;

        }
        public Rover(int position, string mode, int generatorWatts)
        {
            //Sets Mode to "NORMAL"
            //Sets Position to position
            //Sets default value for generatorWatts to 110
            Position = position;
            Mode = mode;            
            GeneratorWatts = generatorWatts;            

        }

        
        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts;
        }

        public void ReceiveMessage(Message message)
        {

            Command[] commandArray = message.Commands;
            Rover rove = new Rover(0);
            int newPosition = Position;
            Command cmdtype = new Command();

            foreach (Command cmd in commandArray)
            {

                //Check to see if mode is low power, if so it cannot not move so position equals 0
                
                
                if(Mode.Equals("LOW_POWER") || GeneratorWatts<50)
                    {
                    break;
                    //throw new Exception ("Cannot move while in low power");
                    }

                //else if (Mode.Equals("NORMAL") && cmd.CommandType.Equals("MOVE"))
                //    {
                //    Position = cmdtype.NewPostion;
                //    }

                do
                {
                    if (Mode.Equals("NORMAL"))
                    {
                        this.Mode = "LOW_POWER";
                    }
                    else
                    {
                        this.Mode = "NORMAL";
                    }
                } while (Mode.Equals("MODE_CHANGE"));

                

                
                //if(newCommand1.CommandType=="MOVE")
                //{
                //    this.Position = newCommand1.NewPostion;
                //}

            }




            



        }
    }
}