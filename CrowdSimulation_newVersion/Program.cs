using System;
using GridMapGenerations;
using Peoples;
using System.Collections;
class test
{
    static void Main(string[] args)
    {
        GridMapGeneration Map = new GridMapGeneration();
        //Console.WriteLine(Map.x);
        //Console.WriteLine(Map.y);
        //Console.WriteLine(Map.GridMap.Length);
        //for (int i = 0; i <= Map.x; i++)
        //{
        //    for (int j = 0; j <= Map.y; j++)
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
        x.Add(19);
        x.Add(20);
        x.Add(21);
        x.Add(22);
        x.Add(23);
        x.Add(24);
        y.Add(0);
        y.Add(0);
        y.Add(0);
        y.Add(0);
        y.Add(0);
        y.Add(0);
        x.Add(37);
        x.Add(38);
        x.Add(39);
        x.Add(40);
        x.Add(41);
        x.Add(42);
        y.Add(50);
        y.Add(50);
        y.Add(50);
        y.Add(50);
        y.Add(50);
        y.Add(50);
        Map.GetGridMap();
        Map.SetExits(x, y);

    }
}