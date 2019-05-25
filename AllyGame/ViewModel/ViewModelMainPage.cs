using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllyGame.Models;

namespace AllyGame.ViewModel
{
    public class ViewModelMainPage
    {
        //所有人
        public List<People> AllPerson = new List<People>();
        //记录一共多少英雄
        public int CountPerson
        {
            get;
            set;
        }

        //记录一共多少英雄正在战场；
        public int CountWarPerson
        {
            get;
            set;
        }

        public ViewModelMainPage()
        {
            CountPerson = 6;
            CountWarPerson = 0;
            AllPerson.Add(new People("张无忌", "马上杀到，看我乾坤大挪移   !"));
            AllPerson.Add(new People("赵敏", "敏妹陪你大战恶魔五百回合   !"));
            AllPerson.Add(new People("令狐冲", "马上用易筋经来救你   !"));
            AllPerson.Add(new People("萧峰", "救驾来迟，看我降龙十八掌   !"));
            AllPerson.Add(new People("段誉", "看我大理段氏六脉神剑   !"));
            AllPerson.Add(new People("虚竹", "我不玩虚的，天山折梅手   !"));
        }


        public string WhenGetWar(string WhoNewIn)
        {
            string EnterWord;
            //参战人数增加；
            CountWarPerson++;
            EnterWord = CountWarPerson + "人战团：" + WhoNewIn + "加入战团" + "{";
            for (int i = 0; i < CountPerson; i++)
            {
                if (AllPerson[i].Name == WhoNewIn)
                {
                    AllPerson[i].IsInWar = 1;
                }

                if (AllPerson[i].IsInWar == 1)
                {
                    EnterWord += AllPerson[i].Name + "+";
                }

            }

            //消除最后一个+号
            EnterWord = EnterWord.Substring(0, EnterWord.Length - 1);
            EnterWord += "}";
            return EnterWord;
        }

        public string WhenOutWar(string WhoNewOut)
        {
            string EnterWord;
            CountWarPerson--;
            EnterWord = CountWarPerson + "人战团：" + WhoNewOut + "离开战团";
            if (CountWarPerson != 0)
            {
                EnterWord += "{";
                for (int i = 0; i < CountPerson; i++)
                {
                    if (AllPerson[i].Name == WhoNewOut)
                    {
                        AllPerson[i].IsInWar = 0;
                    }

                    if (AllPerson[i].IsInWar == 1)
                    {
                        EnterWord += AllPerson[i].Name + "+";
                    }

                }
                EnterWord = EnterWord.Substring(0, EnterWord.Length - 1);
                EnterWord += "}";
            }
            return EnterWord;
        }

        public List<string> OnAttack(string BeAttacked)
        {
            List<string> OutputList = new List<string>();
            OutputList.Add("紧急通知：盟友" + BeAttacked + "受到攻击   !");
            foreach (var Ally in AllPerson)
            {
                if (Ally.Name != BeAttacked && Ally.IsInWar == 1)
                {
                    OutputList.Add("[" + Ally.Name + "]" + Ally.OnAttackWord);
                }
            }

            return OutputList;
        }
    }
}
