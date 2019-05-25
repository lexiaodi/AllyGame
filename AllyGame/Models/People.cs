using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllyGame.Models
{
    public class People
    {
        public string Name
        {
            get;
            set;
        }

        public string OnAttackWord
        {
            get;
            set;
        }

        public int IsInWar
        {
            get;
            set;
        }

        public People(string sname, string sonattackword)
        {
            Name = sname;
            OnAttackWord = sonattackword;
            IsInWar = 0;
        }
    }
}
