﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonClassLibrary
{
    public abstract class Character
    {
        private int _life;

        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }

        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)//doesn't allow for characters' life to be larger than max life
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
            }
        }

        //default ctor

        public virtual int CalcBlock()
        {
            return Block;
        }

        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        public virtual int CalcDamage()
        {
            return 0;
        }
    }
}
