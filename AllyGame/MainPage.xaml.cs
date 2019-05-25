using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using AllyGame.ViewModel;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace AllyGame
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //定义一个成员；
        public ViewModelMainPage AllCharacter = new ViewModelMainPage();
        public string[] NameList = { "张无忌", "赵敏", "令狐冲", "萧峰", "段誉", "虚竹" };
        //表示人数
        public int NameCount;
        public string TextOut;
        //控制按钮能点不能点
        public bool[] ButtonEnable = { false, false, false, false, false, false };
        public MainPage()
        {

            this.InitializeComponent();
            TextOut = "";
            NameCount = 6;
        }


        private void GetInWar_Checked(object sender, RoutedEventArgs e)
        {
            string OutWord;
            var WhoNewIn = (sender as CheckBox).Tag.ToString();

            OutWord = AllCharacter.WhenGetWar(WhoNewIn);
            TextOut += OutWord + "\n\n";
            //把相应按钮变为可使用
            for (int i = 0; i < NameCount; i++)
            {
                if (NameList[i] == WhoNewIn)
                    ButtonEnable[i] = true;
            }

            Bindings.Update();

        }

        private void GetInWar_Unchecked(object sender, RoutedEventArgs e)
        {
            string OutWord;
            var WhoNewOut = (sender as CheckBox).Tag.ToString();
            OutWord = AllCharacter.WhenOutWar(WhoNewOut);
            TextOut += OutWord + "\n\n";

            //把相应按钮变为不可使用；
            for (int i = 0; i < NameCount; i++)
            {
                if (NameList[i] == WhoNewOut)
                    ButtonEnable[i] = false;
            }
            Bindings.Update();

        }

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            List<string> AttackWord = new List<string>();
            var WhoGetAttack = (sender as Button).Tag.ToString();
            AttackWord = AllCharacter.OnAttack(WhoGetAttack); //得到了人员要说的话；

            for (int i = 0; i < AttackWord.Count; i++)
            {
                TextOut += AttackWord[i] + "\n";
            }
            TextOut += "\n";
            Bindings.Update();
        }
    }
}
