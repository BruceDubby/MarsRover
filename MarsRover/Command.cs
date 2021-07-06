using System;
namespace MarsRover
{
    public class Command
    {
        public string CommandType { get; set; }
        public int NewPostion { get; set; }
        public string NewMode { get; set; }


        public Command() { }

        public Command(string newMode)
        {
        }

        //Command type has to be either MOVE or MODE_CHANGE 

        public Command(string commandType, string newMode)
        {

            this.NewMode = newMode;
            this.CommandType = commandType;
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
        }

        public Command(string commandType, int value)
        {
            this.CommandType = commandType;
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
            this.NewPostion = value;
        }

    }
}