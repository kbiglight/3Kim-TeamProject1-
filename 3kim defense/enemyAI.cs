using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3kim_defense
{
    public class enemyAI//적의 AI입니다.
    {
        Queue<int> testqueue = new Queue<int>();
        public Queue<int> stage1() {
            testqueue.Enqueue(1);
            testqueue.Enqueue(1);
            testqueue.Enqueue(1);
            testqueue.Enqueue(1);
            testqueue.Enqueue(1);
            testqueue.Enqueue(1);
            testqueue.Enqueue(2);
            return testqueue;
        }
        public int AImovingTest(int G)
        {
            int k=0;
            if (G%15==1) { k = 1; }
            if (G ==50) { k = 2; }
            return k;
        }
    }
}
