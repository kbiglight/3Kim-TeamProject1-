using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3kim_defense
{
    public class enemyAI//적의 AI입니다.
    {
        public int AImovingTest(int G)
        {
            int k=0;
            if (G%15==1) { k = 1; }
            if (G ==50) { k = 2; }
            return k;
        }
    }
}
