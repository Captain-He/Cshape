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
        static void Main(string[] args)
        {
            GameShow();
            #region 输入玩家姓名 
            Console.WriteLine("请输入玩家A的姓名");
            PlayerName[0] = Console.ReadLine();
            while(PlayerName[0] == "")
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
            Console.WriteLine("{0}的士兵用A表示",PlayerName[0]);
            Console.WriteLine("{0}的士兵用B表示",PlayerName[1]);
            InitailaMap();
            DrawMap();
            while (PlayerPos[0] < 99 && PlayerPos[1] < 99)
            {
                Console.WriteLine("{0}按任意键开始掷骰子", PlayerName[0]);
                Console.ReadKey(true);
                Console.WriteLine("{0}掷出了4", PlayerName[0]);
                PlayerPos[0] += 4;
                Console.ReadKey(true);
                Console.WriteLine("{0}按任意键开始行动", PlayerName[0]);
                Console.ReadKey(true);
                Console.WriteLine("{0}行动完了", PlayerName[0]);
                Console.ReadKey(true);
                if (PlayerPos[0] == PlayerPos[1])
                {
                    Console.WriteLine("玩家{0}踩到了玩家{1}，玩家{2}退6格", PlayerName[0], PlayerName[1], PlayerName[1]);
                    Console.ReadKey(true);
                    PlayerPos[1] -= 6;

                }
                else
                {
                    switch (Maps[PlayerPos[0]])
                    {
                        case 0:
                            Console.WriteLine("玩家{0}踩到了方块，安全。", PlayerName[0]);
                            Console.ReadKey(true);
                            break;
                        case 1:
                            Console.WriteLine("玩家{0}踩到幸运轮盘，请选择1--交换位置 2--轰炸对方");
                            string input = Console.ReadLine();
                            while (true)
                            {
                                if (input == "1")
                                {
                                    Console.WriteLine("玩家{0}选择和玩家{1}交换位置", PlayerName[0], PlayerName[1]);
                                    Console.ReadKey(true);
                                    int temp = PlayerPos[0];
                                    PlayerPos[0] = PlayerPos[1];
                                    PlayerPos[1] = temp;
                                    Console.WriteLine("交换完成！！！按任意键继续游戏！！！");
                                    Console.ReadKey(true);
                                    break;
                                }
                                else if (input == "2")
                                {
                                    Console.WriteLine("玩家{0}选择轰炸玩家{1}，玩家{2}退6格", PlayerName[0], PlayerName[1], PlayerName[1]);
                                    Console.ReadKey(true);
                                    PlayerPos[1] -= 6;
                                    Console.WriteLine("玩家{0}退6格", PlayerName[1]);
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
                            Console.WriteLine("玩家{0}踩到地雷退6格", PlayerName[0]);
                            Console.ReadKey(true);
                            PlayerPos[0] -= 6;
                            break;
                        case 3:
                            Console.WriteLine("玩家{0}踩到暂停，暂停一回合", PlayerName[0]);
                            Console.ReadKey(true);

                            break;
                        case 4:
                            Console.WriteLine("玩家{0}踩到时空隧道，前进10格", PlayerName[0]);
                            PlayerPos[0] += 10;
                            Console.ReadKey(true);
                            break;
                    }
                }
                Console.Clear();
                DrawMap();
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
            for(int i = 64;i>=35;i--)
            {
                Console.Write(DrawStringMap(i));
            }
            Console.WriteLine();
            #endregion

            #region 第二竖
            for (int i = 65; i<=69; i++)
            {
               
                Console.Write(DrawStringMap(i));
                Console.WriteLine();
            }
           
            #endregion

            #region 第三行
            for (int i = 70; i <=99; i++)
            {
                Console.Write(DrawStringMap(i));
            }

            #endregion
            Console.WriteLine();
        }

        public static string  DrawStringMap(int i )
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
    }
}

        

    

