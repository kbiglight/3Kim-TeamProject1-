using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3kim_defense
{
    class Tower//적 타워, 아군 타워의 좌표 등
    {//아군(26,222),적(483,222)
        public int hp;
        public int X;
        public void towerset(int G) {
            if (G == 0) { X = 26; } else { X = 483; }
            hp = 100;//일단은 100으로 두고 나중에 강화나 그런거 생기면 변경하는걸로
        }
        public int towethp() { return hp; }
        public void towerdamage(int G) { hp = hp - G; }
        public int towercheck() { if (hp <= 0) { return 1; } else { return 0; } }//1이면 사망판정,0이면 승리판정
    }
}
