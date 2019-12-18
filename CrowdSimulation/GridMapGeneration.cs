using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace GridMapGeneration
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
        public double GetAliquot(double num,double cellsize)
        {
            if (num > 0)
            {
                return (int)(num / cellsize + 1) * cellsize;
            }
            else
                return -(int)(-num / cellsize + 1) * cellsize;
        }
        static void Main(string[] args)
        {
            StreamReader r = new StreamReader("C:\\Users\\Huang Han\\Desktop\\walls_doors_furnitures-result.json");
            string jsonText = r.ReadToEnd();
            // string jsonText = "{\"walls\":[{\"bbox\":{\"x00\":-9.925,\"y00\":11.075,\"x01\":-9.925,\"y01\":11.425,\"x10\":9.575,\"y10\":11.075,\"x11\":9.575,\"y11\":11.425},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:Íâ²¿ - ´ø×©Óë½ðÊôÁ¢½îÁú¹Ç¸´ºÏÇ½:207713\",\"ifcId\":229,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-9.575,\"y00\":-1.287,\"x01\":-9.575,\"y01\":-1.163,\"x10\":-4.912,\"y10\":-1.287,\"x11\":-4.912,\"y11\":-1.163},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:ÄÚ²¿ - Æö¿éÇ½ 100:208176\",\"ifcId\":624,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":5.150,\"y00\":6.013,\"x01\":5.150,\"y01\":6.137,\"x10\":9.575,\"y10\":6.013,\"x11\":9.575,\"y11\":6.137},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:ÄÚ²¿ - Æö¿éÇ½ 100:207864\",\"ifcId\":510,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-2.038,\"y00\":-0.212,\"x01\":-2.038,\"y01\":-0.088,\"x10\":3.062,\"y10\":-0.212,\"x11\":3.062,\"y11\":-0.088},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:ÄÚ²¿ - Æö¿éÇ½ 100:232098\",\"ifcId\":1294,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":5.026,\"y00\":2.463,\"x01\":5.026,\"y01\":2.587,\"x10\":9.575,\"y10\":2.463,\"x11\":9.575,\"y11\":2.587},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:ÄÚ²¿ - Æö¿éÇ½ 100:232354\",\"ifcId\":1370,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":2.938,\"y00\":-11.075,\"x01\":2.938,\"y01\":-5.137,\"x10\":3.062,\"y10\":-11.075,\"x11\":3.062,\"y11\":-5.137},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:ÄÚ²¿ - Æö¿éÇ½ 100:245467\",\"ifcId\":7543,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":2.938,\"y00\":-0.088,\"x01\":2.938,\"y01\":11.075,\"x10\":3.062,\"y10\":-0.088,\"x11\":3.062,\"y11\":11.075},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:ÄÚ²¿ - Æö¿éÇ½ 100:232135\",\"ifcId\":1332,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-9.575,\"y00\":-11.425,\"x01\":-9.575,\"y01\":-11.075,\"x10\":9.925,\"y10\":-11.425,\"x11\":9.925,\"y11\":-11.075},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:Íâ²¿ - ´ø×©Óë½ðÊôÁ¢½îÁú¹Ç¸´ºÏÇ½:207715\",\"ifcId\":377,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-9.575,\"y00\":2.913,\"x01\":-9.575,\"y01\":3.037,\"x10\":-4.788,\"y10\":2.913,\"x11\":-4.788,\"y11\":3.037},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:ÄÚ²¿ - Æö¿éÇ½ 100:208085\",\"ifcId\":548,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":9.575,\"y00\":-11.075,\"x01\":9.575,\"y01\":11.425,\"x10\":9.925,\"y10\":-11.075,\"x11\":9.925,\"y11\":11.425},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:Íâ²¿ - ´ø×©Óë½ðÊôÁ¢½îÁú¹Ç¸´ºÏÇ½:207716\",\"ifcId\":415,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-2.162,\"y00\":-0.212,\"x01\":-2.162,\"y01\":11.075,\"x10\":-2.038,\"y10\":-0.212,\"x11\":-2.038,\"y11\":11.075},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:ÄÚ²¿ - Æö¿éÇ½ 100:232054\",\"ifcId\":1256,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-9.575,\"y00\":6.563,\"x01\":-9.575,\"y01\":6.687,\"x10\":-2.162,\"y10\":6.563,\"x11\":-2.162,\"y11\":6.687},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:ÄÚ²¿ - Æö¿éÇ½ 100:208448\",\"ifcId\":662,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-4.912,\"y00\":-1.287,\"x01\":-4.912,\"y01\":2.913,\"x10\":-4.788,\"y10\":-1.287,\"x11\":-4.788,\"y11\":2.913},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:ÄÚ²¿ - Æö¿éÇ½ 100:208139\",\"ifcId\":586,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-9.925,\"y00\":-11.425,\"x01\":-9.925,\"y01\":11.075,\"x10\":-9.575,\"y10\":-11.425,\"x11\":-9.575,\"y11\":11.075},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:Íâ²¿ - ´ø×©Óë½ðÊôÁ¢½îÁú¹Ç¸´ºÏÇ½:207714\",\"ifcId\":339,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":5.026,\"y00\":-11.075,\"x01\":5.026,\"y01\":2.463,\"x10\":5.150,\"y10\":-11.075,\"x11\":5.150,\"y11\":2.463},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:ÄÚ²¿ - Æö¿éÇ½ 100:232395\",\"ifcId\":1408,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-9.575,\"y00\":-5.137,\"x01\":-9.575,\"y01\":-5.013,\"x10\":3.062,\"y10\":-5.137,\"x11\":3.062,\"y11\":-5.013},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:ÄÚ²¿ - Æö¿éÇ½ 100:245425\",\"ifcId\":7505,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-2.162,\"y00\":-11.075,\"x01\":-2.162,\"y01\":-5.137,\"x10\":-2.038,\"y10\":-11.075,\"x11\":-2.038,\"y11\":-5.137},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:ÄÚ²¿ - Æö¿éÇ½ 100:208637\",\"ifcId\":700,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":5.026,\"y00\":6.013,\"x01\":5.026,\"y01\":11.075,\"x10\":5.150,\"y10\":6.013,\"x11\":5.150,\"y11\":11.075},\"type\":\"IFCWALLSTANDARDCASE\",\"name\":\"Basic Wall:ÄÚ²¿ - Æö¿éÇ½ 100:207801\",\"ifcId\":453,\"storey\":\"±ê¸ß 1\"}],\"doors\":[{\"bbox\":{\"x00\":9.550,\"y00\":3.309,\"x01\":9.550,\"y01\":5.291,\"x10\":9.950,\"y10\":3.309,\"x11\":9.950,\"y11\":5.291},\"type\":\"IFCDOOR\",\"name\":\"M_Double-Panel 1:1830 x 1981mm:1830 x 1981mm:257623\",\"ifcId\":30229,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-2.187,\"y00\":3.469,\"x01\":-2.187,\"y01\":5.451,\"x10\":-2.013,\"y10\":3.469,\"x11\":-2.013,\"y11\":5.451},\"type\":\"IFCDOOR\",\"name\":\"M_Double-Panel 1:1830 x 1981mm:1830 x 1981mm:258595\",\"ifcId\":30773,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-5.945,\"y00\":6.538,\"x01\":-5.945,\"y01\":6.712,\"x10\":-3.963,\"y10\":6.538,\"x11\":-3.963,\"y11\":6.712},\"type\":\"IFCDOOR\",\"name\":\"M_Double-Panel 1:1830 x 1981mm:1830 x 1981mm:258649\",\"ifcId\":30818,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-4.937,\"y00\":-0.116,\"x01\":-4.937,\"y01\":1.866,\"x10\":-4.763,\"y10\":-0.116,\"x11\":-4.763,\"y11\":1.866},\"type\":\"IFCDOOR\",\"name\":\"M_Double-Panel 1:1830 x 1981mm:1830 x 1981mm:258700\",\"ifcId\":30863,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-9.950,\"y00\":-4.049,\"x01\":-9.950,\"y01\":-2.068,\"x10\":-9.550,\"y10\":-4.049,\"x11\":-9.550,\"y11\":-2.068},\"type\":\"IFCDOOR\",\"name\":\"M_Double-Panel 1:1830 x 1981mm:1830 x 1981mm:258743\",\"ifcId\":30908,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":5.001,\"y00\":-4.531,\"x01\":5.001,\"y01\":-2.549,\"x10\":5.175,\"y10\":-4.531,\"x11\":5.175,\"y11\":-2.549},\"type\":\"IFCDOOR\",\"name\":\"M_Double-Panel 1:1830 x 1981mm:1830 x 1981mm:258806\",\"ifcId\":30953,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-0.541,\"y00\":-5.162,\"x01\":-0.541,\"y01\":-4.988,\"x10\":1.441,\"y10\":-5.162,\"x11\":1.441,\"y11\":-4.988},\"type\":\"IFCDOOR\",\"name\":\"M_Double-Panel 1:1830 x 1981mm:1830 x 1981mm:258850\",\"ifcId\":31476,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-6.356,\"y00\":-5.162,\"x01\":-6.356,\"y01\":-4.988,\"x10\":-4.374,\"y10\":-5.162,\"x11\":-4.374,\"y11\":-4.988},\"type\":\"IFCDOOR\",\"name\":\"M_Double-Panel 1:1830 x 1981mm:1830 x 1981mm:258889\",\"ifcId\":31522,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-2.187,\"y00\":-10.264,\"x01\":-2.187,\"y01\":-9.197,\"x10\":-2.013,\"y10\":-10.264,\"x11\":-2.013,\"y11\":-9.197},\"type\":\"IFCDOOR\",\"name\":\"M_Single-Flush:0915 x 2134mm:0915 x 2134mm:258950\",\"ifcId\":31633,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":5.001,\"y00\":6.549,\"x01\":5.001,\"y01\":8.531,\"x10\":5.175,\"y10\":6.549,\"x11\":5.175,\"y11\":8.531},\"type\":\"IFCDOOR\",\"name\":\"M_Double-Panel 1:1830 x 1981mm:1830 x 1981mm:262781\",\"ifcId\":35199,\"storey\":\"±ê¸ß 1\"}],\"furnitures\":[{\"bbox\":{\"x00\":-0.865,\"y00\":9.558,\"x01\":-0.865,\"y01\":10.218,\"x10\":0.965,\"y10\":9.558,\"x11\":0.965,\"y11\":10.218},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"É³·¢28:1830 mm:1830 mm:239436\",\"ifcId\":1730,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-8.615,\"y00\":-6.755,\"x01\":-8.615,\"y01\":-6.095,\"x10\":-6.785,\"y10\":-6.755,\"x11\":-6.785,\"y11\":-6.095},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"É³·¢28:1830 mm:1830 mm:239709\",\"ifcId\":1759,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":6.373,\"y00\":1.145,\"x01\":6.373,\"y01\":1.805,\"x10\":8.203,\"y10\":1.145,\"x11\":8.203,\"y11\":1.805},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"É³·¢28:1830 mm:1830 mm:239848\",\"ifcId\":1777,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":6.488,\"y00\":-9.955,\"x01\":6.488,\"y01\":-9.295,\"x10\":8.318,\"y10\":-9.955,\"x11\":8.318,\"y11\":-9.295},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"É³·¢28:1830 mm:1830 mm:242108\",\"ifcId\":1795,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-8.765,\"y00\":9.858,\"x01\":-8.765,\"y01\":10.518,\"x10\":-6.935,\"y10\":9.858,\"x11\":-6.935,\"y11\":10.518},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"É³·¢28:1830 mm:1830 mm:242189\",\"ifcId\":1813,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-1.289,\"y00\":-9.722,\"x01\":-1.289,\"y01\":-9.014,\"x10\":-0.326,\"y10\":-9.722,\"x11\":-0.326,\"y11\":-9.014},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"ÒÎ×Ó-Corbu:ÒÎ×Ó-Corbu:ÒÎ×Ó-Corbu:245132\",\"ifcId\":7449,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":8.177,\"y00\":9.064,\"x01\":8.177,\"y01\":10.026,\"x10\":8.884,\"y10\":9.064,\"x11\":8.884,\"y11\":10.026},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"ÒÎ×Ó-Corbu:ÒÎ×Ó-Corbu:ÒÎ×Ó-Corbu:245229\",\"ifcId\":7482,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":5.679,\"y00\":8.523,\"x01\":5.679,\"y01\":10.588,\"x10\":7.297,\"y10\":8.523,\"x11\":7.297,\"y11\":10.588},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"Ë«ÈË´²£¨dwg£©:Ë«ÈË´²£¨dwg£©:Ë«ÈË´²£¨dwg£©:247995\",\"ifcId\":29418,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":0.340,\"y00\":-10.045,\"x01\":0.340,\"y01\":-7.949,\"x10\":1.986,\"y10\":-10.045,\"x11\":1.986,\"y11\":-7.949},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"Ë«ÈË´²£¨dwg£©:Ë«ÈË´²£¨dwg£©:Ë«ÈË´²£¨dwg£©:248321\",\"ifcId\":29442,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-8.967,\"y00\":8.607,\"x01\":-8.967,\"y01\":9.369,\"x10\":-6.833,\"y10\":8.607,\"x11\":-6.833,\"y11\":9.369},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"²Í×À:0762 x 2134 mm:0762 x 2134 mm:249125\",\"ifcId\":29641,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":6.221,\"y00\":-0.487,\"x01\":6.221,\"y01\":0.275,\"x10\":8.355,\"y10\":-0.487,\"x11\":8.355,\"y11\":0.275},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"²Í×À:0762 x 2134 mm:0762 x 2134 mm:249200\",\"ifcId\":29668,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":6.386,\"y00\":-8.567,\"x01\":6.386,\"y01\":-7.805,\"x10\":8.520,\"y10\":-8.567,\"x11\":8.520,\"y11\":-7.805},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"²Í×À:0762 x 2134 mm:0762 x 2134 mm:249476\",\"ifcId\":29683,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-8.613,\"y00\":-8.374,\"x01\":-8.613,\"y01\":-7.612,\"x10\":-6.479,\"y10\":-8.374,\"x11\":-6.479,\"y11\":-7.612},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"²Í×À:0762 x 2134 mm:0762 x 2134 mm:249524\",\"ifcId\":29698,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-0.898,\"y00\":7.901,\"x01\":-0.898,\"y01\":8.663,\"x10\":1.236,\"y10\":7.901,\"x11\":1.236,\"y11\":8.663},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"²Í×À:0762 x 2134 mm:0762 x 2134 mm:249572\",\"ifcId\":29713,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-8.700,\"y00\":-0.375,\"x01\":-8.700,\"y01\":2.125,\"x10\":-7.5,\"y10\":-0.375,\"x11\":-7.5,\"y11\":2.125},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"Table - Conference w Chairs:1200 x 2500mm:1200 x 2500mm:262548\",\"ifcId\":31849,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-8.995,\"y00\":1.223,\"x01\":-8.995,\"y01\":1.896,\"x10\":-8.354,\"y10\":1.223,\"x11\":-8.354,\"y11\":1.896},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"Chair-Task:Chair-Task:Chair-Task:262552\",\"ifcId\":32275,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-7.846,\"y00\":1.223,\"x01\":-7.846,\"y01\":1.896,\"x10\":-7.205,\"y10\":1.223,\"x11\":-7.205,\"y11\":1.896},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"Chair-Task:Chair-Task:Chair-Task:262553\",\"ifcId\":32305,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-8.995,\"y00\":-0.147,\"x01\":-8.995,\"y01\":0.527,\"x10\":-8.354,\"y10\":-0.147,\"x11\":-8.354,\"y11\":0.527},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"Chair-Task:Chair-Task:Chair-Task:262554\",\"ifcId\":32326,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-7.846,\"y00\":-0.147,\"x01\":-7.846,\"y01\":0.527,\"x10\":-7.205,\"y10\":-0.147,\"x11\":-7.205,\"y11\":0.527},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"Chair-Task:Chair-Task:Chair-Task:262555\",\"ifcId\":32347,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-8.437,\"y00\":-0.670,\"x01\":-8.437,\"y01\":-0.029,\"x10\":-7.763,\"y10\":-0.670,\"x11\":-7.763,\"y11\":-0.029},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"Chair-Task Arms:Chair-Task Arms:Chair-Task Arms:262556\",\"ifcId\":35134,\"storey\":\"±ê¸ß 1\"},{\"bbox\":{\"x00\":-8.437,\"y00\":1.779,\"x01\":-8.437,\"y01\":2.420,\"x10\":-7.763,\"y10\":1.779,\"x11\":-7.763,\"y11\":2.420},\"type\":\"IFCFURNISHINGELEMENT\",\"name\":\"Chair-Task Arms:Chair-Task Arms:Chair-Task Arms:262557\",\"ifcId\":35164,\"storey\":\"±ê¸ß 1\"}]}";
            //  Console.WriteLine(jsonText);
            RootObject bounding = JsonConvert.DeserializeObject<RootObject>(jsonText);

            // Console.WriteLine(bounding.walls[0].bbox.x00);

            //foreach (Doors dr in bounding.doors)
            //{
            //    Console.WriteLine(dr.ifcId);
            //}
            //foreach (Furnitures fr in bounding.furnitures)
            //{
            //    Console.WriteLine(fr.bbox.x00);
            //}
            //foreach (Furnitures fr in bounding.furnitures)
            //{
            //    Console.WriteLine(fr.bbox.x01);
            //}
            //foreach (Furnitures fr in bounding.furnitures)
            //{
            //    Console.WriteLine(fr.bbox.x11);
            //}
            //foreach (Furnitures fr in bounding.furnitures)
            //{
            //    Console.WriteLine(fr.bbox.x10);
            //}
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
            Console.WriteLine(xMax.Max());
            Console.WriteLine(xMin.Min());
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
            Console.WriteLine(yMax.Max());
            Console.WriteLine(yMin.Min());
            GridMapGeneration p = new GridMapGeneration();
            double xMin_final = p.GetAliquot(xMin.Min(), 0.4);
            double xMax_final = p.GetAliquot(xMax.Max(), 0.4);
            xMin_final = Math.Round(xMin_final, 1);
            xMax_final = Math.Round(xMax_final, 1);
            Console.WriteLine(xMin_final);
            Console.WriteLine(xMax_final);
            double yMin_final = p.GetAliquot(yMin.Min(), 0.4);
            double yMax_final = p.GetAliquot(yMax.Max(), 0.4);
            yMin_final = Math.Round(yMin_final, 1);
            yMax_final = Math.Round(yMax_final, 1);
            Console.WriteLine(yMin_final);
            Console.WriteLine(yMax_final);
            int grid_x = (int)(Math.Round((xMax_final - xMin_final) / 0.4));
            int grid_y = (int)(Math.Round((yMax_final - yMin_final) / 0.4));
            Console.WriteLine(grid_y);
            Console.WriteLine(grid_x);
            int[,] grid = new int[grid_x+1, grid_y+1];
            foreach (Walls wa in bounding.walls)
            {
                int wax0 = (int)(Math.Round((wa.bbox.x00-xMin_final) / 0.4));
                int wax1 = (int)(Math.Round((wa.bbox.x11 - xMin_final) / 0.4));
                int way0 = (int)(Math.Round((wa.bbox.y00 - yMin_final) / 0.4));
                int way1 = (int)(Math.Round((wa.bbox.y11 - yMin_final) / 0.4));
            //    Console.WriteLine(wax0);
                for (int i = wax0; i <= wax1; i++)
                {
                    for(int j = way0; j <= way1; j++)
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
            for (int i = 0; i <= grid_x; i++)
            {
                for(int j = 0; j <= grid_y; j++)
                {
                    if (grid[i, j] == -1)
                        Console.Write("■");
                    if (grid[i, j] == 0)
                        Console.Write("□");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
