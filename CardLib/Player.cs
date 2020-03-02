using System;

namespace CardLib
{
    public class Player : ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }

        public long ID;

        public string UserName;
        public string Password;

        public int NumberOfGame;

        public int NumberOfDurak;
        public string EmailAddress;
        
        public Player(int id, string userName, string password, int numberOfGame, int numberOfDurak, string emailAddress)
        {
            ID = id;
            UserName = userName;
            Password = password;
            NumberOfDurak = numberOfDurak;
            NumberOfGame = numberOfGame;
            EmailAddress = emailAddress;
        }
        public Player(string userName, string password, string emailAddress)
        {
            ID = 0;
            UserName = userName;
            Password = password;
            NumberOfDurak = 0;
            NumberOfGame = 0;
            EmailAddress = emailAddress;
        }

        public Player()
        { }


        public override string ToString()
        {
            return (ID + ", " + UserName + ", " + Password + ", " + NumberOfDurak +
                ", " + NumberOfGame + ", " + EmailAddress);
        }
    }
    public class CopyOfPlayer
    {
    }
}