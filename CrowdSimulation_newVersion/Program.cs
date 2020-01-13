using System;
using GridMapGenerations;
using Peoples;
using System.Collections;
using astar;

class test
{
    public int Distence(int x,int y,int a,int b)
    {
        return (x - a) * (x - a) + (y - b) + (y - b);
    }
    public void move(People p,GridMapGeneration M)
    {
        int temp_d = 999999999;
        for(int i = -1; i <= 1; i++)
        {
            for(int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                    continue;
                if (M.GridMap[(int)p.path_x[p.path_x.Count-1] + i, (int)p.path_y[p.path_y.Count-1] + j] == -1)
                    continue;
                else
                {
                    int d = Distence((int)p.path_x[p.path_x.Count-1] + i, (int)p.path_y[p.path_y.Count-1] + j, p.Goal_x, p.Goal_y);
                    if (d < temp_d)
                    {
                        temp_d=d;
                        p.move_x = (int)p.path_x[p.path_x.Count-1] + i;
                        p.move_y = (int)p.path_y[p.path_y.Count-1] + j;
                    }
                }
            }
        }
    }
    static void Main(string[] args)
    {
        GridMapGeneration Map = new GridMapGeneration();
        //Console.WriteLine(Map.x);
        //Console.WriteLine(Map.y);
        //Console.WriteLine(Map.GridMap.Length);
        //for (int i = 0; i <= Map.y; i++)
        //{
        //    for (int j = 0; j <= Map.x; j++)
        //    {
        //        if (Map.GridMap[i, j] == -1)
        //            Console.Write("■");
        //        if (Map.GridMap[i, j] == 0)
        //            Console.Write("□");
        //    }
        //    Console.WriteLine();
        //}
        ArrayList x = new ArrayList();
        ArrayList y = new ArrayList();
        y.Add(19);
        y.Add(20);
        y.Add(21);
        y.Add(22);
        y.Add(23);
        y.Add(24);
        x.Add(0);
        x.Add(0);
        x.Add(0);
        x.Add(0);
        x.Add(0);
        x.Add(0);
        y.Add(37);
        y.Add(38);
        y.Add(39);
        y.Add(40);
        y.Add(41);
        y.Add(42);
        x.Add(50);
        x.Add(50);
        x.Add(50);
        x.Add(50);
        x.Add(50);
        x.Add(50);
        Map.GetGridMap();
        Map.SetExits(x, y);
        //for (int i = 0; i <= Map.y; i++)
        //{
        //    for (int j = 0; j <= Map.x; j++)
        //    {
        //        if (Map.GridMap[j, i] == -1)
        //            Console.Write("■");
        //        if (Map.GridMap[j, i] == 0)
        //            Console.Write("□");
        //        if (Map.GridMap[j, i] == -2)
        //            Console.Write("--");
        //    }
        //    Console.WriteLine();
        //}
        People[] p = new People[8]
        {
        new People(),
        new People(),
        new People(),
        new People(),
        new People(),
        new People(),
        new People(),
        new People(),};
        //Console.WriteLine(Map.GridMap.Length); 
        //Console.WriteLine(Map.GridMap.GetLength(0)); //第一维长度 51
        //Console.WriteLine(Map.GridMap.GetLength(1)); //第二维长度 59
        Random rd = new Random();
        Console.WriteLine("agents:");
        for(int i = 0; i <8; i++)
        {
            while (Map.GridMap[p[i].start_x, p[i].start_y] != 0)
            {
                p[i].start_x = rd.Next(1, 50);
                p[i].start_y = rd.Next(1, 58);
            }
            Map.GridMap[p[i].start_x, p[i].start_y] = -3;
            p[i].FindGoal(x, y);
            Console.WriteLine("-   goal: [" + p[i].Goal_x + ", " + p[i].Goal_y + "]");
            Console.WriteLine("    name: agent"+i);
            Console.WriteLine("    start: [" + p[i].start_x + ", " + p[i].start_y + "]");
        }
        for (int i = Map.y; i >=0; i--)
        {
            for (int j = 0; j <= Map.x; j++)
            {
                if (Map.GridMap[j, i] == -1)
                    Console.Write("■");
                if (Map.GridMap[j, i] == 0)
                    Console.Write("□");
                if (Map.GridMap[j, i] == -2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("■");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (Map.GridMap[j, i] == -3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("■");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine();
        }
        //
        int[,] newArray = new int[Map.GridMap.GetUpperBound(1) + 1, Map.GridMap.GetUpperBound(0) + 1]; // 构造转置二维数组
        for (int i = 0; i <= Map.GridMap.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= Map.GridMap.GetUpperBound(1); j++)
            {
                if (Map.GridMap[i, j] == -1)
                newArray[j, i] = 1;
                else
                    newArray[j, i] = 0;
            }
        }
        // Astar astar = new Astar(newArray);
        Console.WriteLine("schedule:");
        for (int j = 0; j <8; j++)
        {
            Astar astar = new Astar(newArray);
            Point start = new Point(p[j].start_y, p[j].start_x);
            Point end = new Point(p[j].Goal_y, p[j].Goal_x);
            var parent = astar.FindPath(start, end, false);


            while (parent != null)
            {
                // Console.WriteLine(parent.Y + "," + parent.X);
                p[j].path_x.Add(parent.Y);
                p[j].path_y.Add(parent.X);
                parent = parent.ParentPoint;
            }
            Console.WriteLine("  agent" + j+":");
            //Console.WriteLine(p[j].path_x.Count - 1);
            for (int i = p[j].path_x.Count - 1; i >= 0; i--)
            {
                Console.WriteLine("  - t: " + (p[j].path_x.Count - 1 - i));
                Console.WriteLine("    x: " + p[j].path_x[i]);
                Console.WriteLine("    y: " + p[j].path_y[i]);
                //Console.WriteLine(p[j].path_x[i] + "," + p[j].path_y[i]);
                Map.GridMap[(int)p[j].path_x[i], (int)p[j].path_y[i]] = -4;
            }
            Map.GridMap[(int)p[j].path_x[p[j].path_x.Count - 1], (int)p[j].path_y[p[j].path_x.Count - 1]] = -3;
            Map.GridMap[(int)p[j].path_x[0], (int)p[j].path_y[0]] = -2;
        }
        for (int i = Map.y; i >=0 ; i--)
        {
            for (int j = 0; j <= Map.x; j++)
            {
                if (Map.GridMap[j, i] == -1)
                    Console.Write("■");
                if (Map.GridMap[j, i] == 0)
                    Console.Write("□");
                if (Map.GridMap[j, i] == -2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("■");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (Map.GridMap[j, i] == -3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("■");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (Map.GridMap[j, i] == -4)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("■");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine();
        }

        //
    }
}