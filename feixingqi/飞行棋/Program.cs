using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 飞行棋
{
    class Program
    {
        static int[] Maps = new int[100];//设置静态字段模拟全局变量,
        static int[] PlayerPos = new int[2];
        static string[] PlayerName = new string[2];
        static bool[] Flages = new bool[2];
        static void Main(string[] args)
        {
            GameShow();
            #region 输入玩家姓名 
            Console.WriteLine("请输入玩家A的姓名");
            PlayerName[0] = Console.ReadLine();
            while (PlayerName[0] == "")
            {
                Console.WriteLine("玩家A的姓名不能为空，请从新输入");
                PlayerName[0] = Console.ReadLine();
            }
            Console.WriteLine("请输入玩家B的姓名");
            PlayerName[1] = Console.ReadLine();
            while (PlayerName[1] == "" || PlayerName[1] == PlayerName[0])
            {
                if (PlayerName[1] == "")
                {
                    Console.WriteLine("玩家A的姓名不能为空，请从新输入");
                    PlayerName[1] = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("玩家B的名字不能和玩家A相同，请重新输入");
                    PlayerName[1] = Console.ReadLine();

                }
            }
            #endregion
            Console.Clear();
            GameShow();
            Console.WriteLine("{0}的士兵用A表示", PlayerName[0]);
            Console.WriteLine("{0}的士兵用B表示", PlayerName[1]);
            InitailaMap();
            DrawMap();
            while (PlayerPos[0] < 99 && PlayerPos[1] < 99)
            {
                if (Flages[0] == false)
                {
                    PlayGame(0);
                }
                else
                {
                    Flages[0] = false;
                }
                if (PlayerPos[0] >= 99)
                {
                    Console.WriteLine("玩家{0}无耻地赢了玩家{1}",PlayerName[0],PlayerName[1]);
                    break;
                }

                if (Flages[1] == false)
                {
                    PlayGame(1);
                }
                else
                {
                    Flages[1] = false;
                }
                if (PlayerPos[1] >= 99)
                {
                    Console.WriteLine("玩家{0}无耻地赢了玩家{1}", PlayerName[1], PlayerName[0]);
                    break;
                }
            }

            Console.ReadKey();
        }

        public static void GameShow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("***************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("***************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("***************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*********飞行棋************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("***************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***************************");
            Console.WriteLine("游戏规则： ");
            Console.WriteLine("如果玩家A踩到了玩家B 玩家B退6格 ");
            Console.WriteLine("踩到地雷 退6格 ");
            Console.WriteLine("踩到时空隧道 进10格 ");
            Console.WriteLine("踩到幸运轮盘  选择1交换位置 选择2轰炸对方 使对方退6格 ");
            Console.WriteLine("踩到了暂停 暂停一回合 ");
            Console.WriteLine("方块，正常游戏 ");
        }
        public static void InitailaMap()
        {
            int[] Luckyturn = { 6, 23, 40, 55, 69, 83 };
            for (int i = 0; i < Luckyturn.Length; i++)
            {
                // int index = Luckyturn[i];
                Maps[Luckyturn[i]] = 1;
            }
            int[] LandMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };
            for (int i = 0; i < LandMine.Length; i++)
            {

                Maps[LandMine[i]] = 2;
            }
            int[] pause = { 9, 27, 60, 93 };
            for (int i = 0; i < pause.Length; i++)
            {

                Maps[pause[i]] = 3;
            }
            int[] tumeTunnel = { 20, 29, 45, 63, 72, 88, 90 };
            for (int i = 0; i < tumeTunnel.Length; i++)
            {

                Maps[tumeTunnel[i]] = 4;
            }
        }
        public static void DrawMap()
        {
            Console.WriteLine("幸运轮盘：☉  地雷：☆  暂停：▲  时空隧道：卐");
            #region 第一行
            for (int i = 0; i < 30; i++)
            {
                Console.Write(DrawStringMap(i));
            }

            Console.WriteLine();
            #endregion

            #region 第一竖
            for (int i = 30; i < 35; i++)
            {
                for (int j = 0; j <= 28; j++)
                {
                    Console.Write("  ");
                }
                Console.Write(DrawStringMap(i));
                Console.WriteLine();
            }
            #endregion

            #region 第二行
            for (int i = 64; i >= 35; i--)
            {
                Console.Write(DrawStringMap(i));
            }
            Console.WriteLine();
            #endregion

            #region 第二竖
            for (int i = 65; i <= 69; i++)
            {

                Console.Write(DrawStringMap(i));
                Console.WriteLine();
            }

            #endregion

            #region 第三行
            for (int i = 70; i <= 99; i++)
            {
                Console.Write(DrawStringMap(i));
            }

            #endregion
            Console.WriteLine();
        }

        public static string DrawStringMap(int i)
        {
            string str = "";
            #region 画图
            if (PlayerPos[0] == PlayerPos[1] && PlayerPos[1] == i)
            {
                str = "<>";
            }
            else if (PlayerPos[0] == i)
            {
                str = "A";
            }
            else if (PlayerPos[1] == i)
            {
                str = "B";
            }
            else
            {
                switch (Maps[i])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        str = "□";
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        str = "☉";
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        str = "☆";
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        str = "▲";
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        str = "卐";
                        break;
                }
            }
            #endregion
            return str;
        }

        /// <summary>
        /// 玩游戏
        /// </summary>
        public static void PlayGame(int playerNumber)
        {
            Random r = new Random();
            int rNumber = r.Next(1,7);
            Console.WriteLine("{0}按任意键开始掷骰子", PlayerName[playerNumber]);
            Console.ReadKey(true);
            Console.WriteLine("{0}掷出了{1}", PlayerName[playerNumber],rNumber);
            PlayerPos[playerNumber] += rNumber;
            ChangePos();
            Console.ReadKey(true);
            Console.WriteLine("{0}按任意键开始行动", PlayerName[playerNumber]);
            Console.ReadKey(true);
            Console.WriteLine("{0}行动完了", PlayerName[playerNumber]);
            Console.ReadKey(true);
            if (PlayerPos[playerNumber] == PlayerPos[1 - playerNumber])
            {
                Console.WriteLine("玩家{0}踩到了玩家{1}，玩家{2}退6格", PlayerName[playerNumber], PlayerName[1 - playerNumber], PlayerName[1 - playerNumber]);
                PlayerPos[1 - playerNumber] -= 6;
                ChangePos();
                Console.ReadKey(true);

            }
            else
            {
                switch (Maps[PlayerPos[playerNumber]])
                {
                    case 0:
                        Console.WriteLine("玩家{0}踩到了方块，安全。", PlayerName[playerNumber]);
                        Console.ReadKey(true);
                        break;
                    case 1:
                        Console.WriteLine("玩家{0}踩到幸运轮盘，请选择1--交换位置 2--轰炸对方");
                        string input = Console.ReadLine();
                        while (true)
                        {
                            if (input == "1")
                            {
                                Console.WriteLine("玩家{0}选择和玩家{1}交换位置", PlayerName[playerNumber], PlayerName[1 - playerNumber]);
                                Console.ReadKey(true);
                                int temp = PlayerPos[playerNumber];
                                PlayerPos[playerNumber] = PlayerPos[1 - playerNumber];
                                PlayerPos[1 - playerNumber] = temp;
                                Console.WriteLine("交换完成！！！按任意键继续游戏！！！");
                                Console.ReadKey(true);
                                break;
                            }
                            else if (input == "2")
                            {
                                Console.WriteLine("玩家{0}选择轰炸玩家{1}，玩家{2}退6格", PlayerName[playerNumber], PlayerName[1 - playerNumber], PlayerName[1 - playerNumber]);
                                Console.ReadKey(true);
                                PlayerPos[1 - playerNumber] -= 6;
                                ChangePos();
                                Console.WriteLine("玩家{0}退6格", PlayerName[1 - playerNumber]);
                                Console.ReadKey(true);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("只能输入1或者2 ， 1--交换位置  2--轰炸对方");
                                input = Console.ReadLine();
                            }
                        }
                        break;

                    case 2:
                        Console.WriteLine("玩家{0}踩到地雷退6格", PlayerName[playerNumber]);
                        Console.ReadKey(true);
                        PlayerPos[playerNumber] -= 6;
                        ChangePos();
                        break;
                    case 3:
                        Console.WriteLine("玩家{0}踩到暂停，暂停一回合", PlayerName[playerNumber]);
                        Flages[playerNumber] = true;
                        Console.ReadKey(true);

                        break;
                    case 4:
                        Console.WriteLine("玩家{0}踩到时空隧道，前进10格", PlayerName[playerNumber]);
                        PlayerPos[playerNumber] += 10;
                        ChangePos();
                        Console.ReadKey(true);
                        break;
                }
            }
            ChangePos();
            Console.Clear();
            DrawMap();
        }

        public static void ChangePos()
        {
            if(PlayerPos[0] < 0)
            {
                PlayerPos[0] = 0;
            }
            if (PlayerPos[0] >= 99)
            {
                PlayerPos[0] = 99;
            }
            if (PlayerPos[1] < 0)
            {
                PlayerPos[1] = 0;
            }
            if (PlayerPos[1] >= 99)
            {
                PlayerPos[1] = 99;
            }
        }


    }
}
 
        

    

