using System;
using System.Collections.Generic;
using System.Collections;
namespace Peoples
{
    class People
    {
        public int start_x = 0, start_y = 0;
        public int Exit_time=0;
        public bool isExited=false;
        public int Goal_x, Goal_y;
        public int move_x, move_y;
        public ArrayList path_x,path_y;
        public void FindGoal(ArrayList a,ArrayList b)
        {
            int temp = 999999999;
            for (int i = 0; i < a.Count; i++)
            {
                int x0 = (int)a[i];
                int y0 = (int)b[i];
                int t = (start_x - x0)*(start_x - x0)+(start_y - y0)*(start_y - y0);
                if (t <= temp)
                {
                    Goal_x = x0;
                    Goal_y = y0;
                    temp = t;
                }
            }
        }

    }
}
