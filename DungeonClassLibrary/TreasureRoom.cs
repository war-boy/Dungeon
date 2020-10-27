using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonClassLibrary
{
    public class TreasureRoom
    {
        public string DisplayClosedChest()
        {
            string chestClosedPic = @"



                     __________
                    /\_________\
                    | \         \
                    | |----oo---|
                    \ |         |
                     \|_________|





            ";
            return (chestClosedPic);
        }
        public string DisplayOpenChest()
        {
            string chestOpenPic= @"



                     __________
                    /\____;;___\
                    | /        /
                    `. _______ .
                    |\         \
                    | |---------|
                    \ |         |
                     \|_________|





            ";
            return (chestOpenPic);  
        }
    }
}
