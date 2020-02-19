using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLib
{
    public class Player : ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
        public long ID
        {
            get => default;
            set
            {
            }
        }

        public int UserName
        {
            get => default;
            set
            {
            }
        }

        public int NumberOfGame
        {
            get => default;
            set
            {
            }
        }

        public int NumberOFDurak
        {
            get => default;
            set
            {
            }
        }
    }

    public class CopyOfPlayer
    {
    }
}