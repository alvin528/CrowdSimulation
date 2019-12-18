using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections;
namespace GridMapGenerations
{
    class GridMapGeneration
    {
        public class Bbox
        {
            public double x00 { get; set; }
            public double y00 { get; set; }
            public double x01 { get; set; }
            public double y01 { get; set; }
            public double x10 { get; set; }
            public double y10 { get; set; }
            public double x11 { get; set; }
            public double y11 { get; set; }
        }

        public class Walls
        {
            public Bbox bbox { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public int ifcId { get; set; }
            public string storey { get; set; }
        }

        public class Doors
        {
            public Bbox bbox { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public int ifcId { get; set; }
            public string storey { get; set; }
        }



        public class Furnitures
        {
            public Bbox bbox { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public int ifcId { get; set; }
            public string storey { get; set; }
        }

        public class RootObject
        {
            public List<Walls> walls { get; set; }
            public List<Doors> doors { get; set; }
            public List<Furnitures> furnitures { get; set; }
        }
        public double GetAliquot(double num, double cellsize)
        {
            if (num > 0)
            {
                return (int)(num / cellsize + 1) * cellsize;
            }
            else
                return -(int)(-num / cellsize + 1) * cellsize;
        }
        public int x, y;
        public int[,] GridMap;
        public void GetGridMap()
        {   
            StreamReader r = new StreamReader("C:\\Users\\Huang Han\\Desktop\\walls_doors_furnitures-result.json");
            string jsonText = r.ReadToEnd();
            RootObject bounding = JsonConvert.DeserializeObject<RootObject>(jsonText);
            double[] xMax = new double[4];
            double[] xMin = new double[4];
            xMax[0] = bounding.walls.Max(p => p.bbox.x00);
            xMax[1] = bounding.walls.Max(p => p.bbox.x01);
            xMax[2] = bounding.walls.Max(p => p.bbox.x10);
            xMax[3] = bounding.walls.Max(p => p.bbox.x11);
            xMin[0] = bounding.walls.Min(p => p.bbox.x00);
            xMin[1] = bounding.walls.Min(p => p.bbox.x01);
            xMin[2] = bounding.walls.Min(p => p.bbox.x10);
            xMin[3] = bounding.walls.Min(p => p.bbox.x11);
            //Console.WriteLine(xMax.Max());
            //Console.WriteLine(xMin.Min());
            double[] yMax = new double[4];
            double[] yMin = new double[4];
            yMax[0] = bounding.walls.Max(p => p.bbox.y00);
            yMax[1] = bounding.walls.Max(p => p.bbox.y01);
            yMax[2] = bounding.walls.Max(p => p.bbox.y10);
            yMax[3] = bounding.walls.Max(p => p.bbox.y11);
            yMin[0] = bounding.walls.Min(p => p.bbox.y00);
            yMin[1] = bounding.walls.Min(p => p.bbox.y01);
            yMin[2] = bounding.walls.Min(p => p.bbox.y10);
            yMin[3] = bounding.walls.Min(p => p.bbox.y11);
            //Console.WriteLine(yMax.Max());
            //Console.WriteLine(yMin.Min());
            GridMapGeneration p = new GridMapGeneration();
            double xMin_final = p.GetAliquot(xMin.Min(), 0.4);
            double xMax_final = p.GetAliquot(xMax.Max(), 0.4);
            xMin_final = Math.Round(xMin_final, 1);
            xMax_final = Math.Round(xMax_final, 1);
            //Console.WriteLine(xMin_final);
            //Console.WriteLine(xMax_final);
            double yMin_final = p.GetAliquot(yMin.Min(), 0.4);
            double yMax_final = p.GetAliquot(yMax.Max(), 0.4);
            yMin_final = Math.Round(yMin_final, 1);
            yMax_final = Math.Round(yMax_final, 1);
            //Console.WriteLine(yMin_final);
            //Console.WriteLine(yMax_final);
            int grid_x = (int)(Math.Round((xMax_final - xMin_final) / 0.4));
            int grid_y = (int)(Math.Round((yMax_final - yMin_final) / 0.4));
            //Console.WriteLine(grid_y);
            //Console.WriteLine(grid_x);
            x = grid_x;
            y = grid_y;
            int[,] grid = new int[grid_x + 1, grid_y + 1];
            foreach (Walls wa in bounding.walls)
            {
                int wax0 = (int)(Math.Round((wa.bbox.x00 - xMin_final) / 0.4));
                int wax1 = (int)(Math.Round((wa.bbox.x11 - xMin_final) / 0.4));
                int way0 = (int)(Math.Round((wa.bbox.y00 - yMin_final) / 0.4));
                int way1 = (int)(Math.Round((wa.bbox.y11 - yMin_final) / 0.4));
                //    Console.WriteLine(wax0);
                for (int i = wax0; i <= wax1; i++)
                {
                    for (int j = way0; j <= way1; j++)
                    {
                        grid[i, j] = -1;
                    }
                }
            }
            foreach (Furnitures fr in bounding.furnitures)
            {
                int frx0 = (int)(Math.Round((fr.bbox.x00 - xMin_final) / 0.4));
                int frx1 = (int)(Math.Round((fr.bbox.x11 - xMin_final) / 0.4));
                int fry0 = (int)(Math.Round((fr.bbox.y00 - yMin_final) / 0.4));
                int fry1 = (int)(Math.Round((fr.bbox.y11 - yMin_final) / 0.4));
                //    Console.WriteLine(wax0);
                for (int i = frx0; i <= frx1; i++)
                {
                    for (int j = fry0; j <= fry1; j++)
                    {
                        grid[i, j] = -1;
                    }
                }
            }
            foreach (Doors dr in bounding.doors)
            {
                int drx0 = (int)(Math.Round((dr.bbox.x00 - xMin_final) / 0.4));
                int drx1 = (int)(Math.Round((dr.bbox.x11 - xMin_final) / 0.4));
                int dry0 = (int)(Math.Round((dr.bbox.y00 - yMin_final) / 0.4));
                int dry1 = (int)(Math.Round((dr.bbox.y11 - yMin_final) / 0.4));
                //  Console.WriteLine(drx0);
                for (int i = drx0; i <= drx1; i++)
                {
                    for (int j = dry0; j <= dry1; j++)
                    {
                        grid[i, j] = 0;
                    }
                }
            }
            GridMap = (int[,])grid.Clone(); //clone the map
        }
        public void SetExits(ArrayList a,ArrayList b)
        {
            for(int i = 0; i < a.Count; i++)
            {
                int t2 = (int)a[i];
                int t1 = (int)b[i];
                GridMap[t1, t2] = -2;
            }
        }
    }
}
