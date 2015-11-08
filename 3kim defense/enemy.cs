using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//적입니다.
//적은 이동방향과 표적,유닌소환만 다를 뿐 기본적으로 유닛과 같습니다.
//소환방법은 일반적으로는 특정 패턴을, 난이도가 높아질수록 우리가 유닛을 뽑는 것을 참조하여 뽑습니다.
namespace _3kim_defense
{
    class enemy
    {
        public string name;//유닛의 이름
        public int type;//유닛의 타입(0=근접형,1=원거리형,2=지원형 등)
        public int maxhp;//최대 hp
        public int maxmp;//최대 mp
        public int hp;//hp
        public int mp;//mp(특수기 사용)(0부터 시작해서 max가 되면 특수가 사용가능)
        public int x;//유닛의 x좌표
        public int y;//유닛의 y좌표
        public int pow;//유닛의 공격력
        public int def;//유닛의 방어력(공격력-방어력=최종 데미지)
        public int spd;//유닛의 이동속도
        public int line;//유닛의 생성라인
        public int AI;//(0=근접 우선,1=원거리 우선 등 아이디어가 있으면 추가해 주세요.)
        public int number;//유닛의 번호(번호를 바탕으로 이미지를 불러올 예정)
        public int frame1;//공격모션(대기)시에 걸리는 시간
        public int frame2;//공격모션(공격후)시에 걸리는 시간
        public int frame3;//원래대로 돌아오는 시간
        public int range;//몬스터의 인식범위
        public int knockback;//넉백공격의 수치(넉백저항-넉백공격 수치만큼 넉백이벤트)
        public int Dknockback;//넉백저항의 수치
        public int live;//살았는지를 확인하는 변수 0=주금 1=삼
        public int liven;//소환된 물체인지 따로 판정
        public int motion;//유닛의 현재 상황을 표시하는 변수 0=이동,1=공격
        public int aim;//공격시 표적을 체크
        public void uninit()
        {//유닛 초기화
            name = "";
            type = 0;
            maxhp = 0;
            hp = 0;
            maxmp = 0;
            x = 41;
            y = 129;//기지의 위치로 좌표 설정 예정
            pow = 0;
            def = 0;
            spd = 0;
            line = 0;
            AI = 0;
            number = 0;
            range = 0;
            knockback = 0;
            Dknockback = 0;
            live = 0;
            liven = 0;
            frame1 = 0;
            frame2 = 0;
            frame3 = 0;
            motion = 0;

        }
        public void sumon(string aname, int atype, int amaxhp, int amaxmp, int amp, int ax, int ay, int apow, int adef, int aspd, int aline, int aAI, int anumber, int arange, int width, int height, int aknockback, int aDknockback)
        {//
            //몬스터의 데이더베이스에서 몬스터 정보를 불러오는 함수
            name = aname;
            type = atype;
            maxhp = amaxhp;
            hp = maxhp;
            maxmp = amaxmp;
            x = 41;
            y = 129;//기지의 위치로 좌표 설정 예정
            pow = apow;
            def = adef;
            spd = aspd;
            line = aline;
            AI = aAI;
            number = anumber;
            range = arange;
            knockback = aknockback;
            Dknockback = aDknockback;
            live = 1;
            liven = 1;

        }
        public void umove(int KNG)
        {
            if (motion==0 && x > 30&&x>KNG)
            {
                x = x - spd;//x좌표가 spd 수치만큼 변경
                //enemy의 움직임은 -로갑니다.
                if (frame1 > frame3) { frame1 = 0; }

            }
            //이동 모션으로 이미지 변경
        }//이동
        void rangecheck(int enemyx)
        {//적 유닛의 x좌표
            if (enemyx > x + range)
            {/*공격 이벤트
                attack();//이동 모션에서 공격 모션으로 변경
                //공격 모션이 끝난 후 판정
                //만약 적이 무적시간이 아니라면 데미지 판정 공격력-방어력(만약 0이하라면 1)
                */
            }//적 유닛의 x좌표가 아군 유닛의 x좌표+사정거리 내에 들어왔을 때 공격 이벤트 실행
        }



        /// //공격 루트
        /// 
        /////
        public int XIN() { return x; }//x축을 리턴
        public void rangechecking(int NUMB, int K)//K=적 캐릭터의 X축을 받아옴,동시에 적 캐릭터의 번호도 받아옴(배열 번호)
        {
            if (motion == 0)//이동 상황에만 체크한다.
            {
                if (x >= K && x - range <= K)//적의 인식범위는 아군의 인식범위와는 반대방향입니다.
                {//만약 적 캐릭터의 X축이 아군 캐릭터의 범위 안에 들었을 경우
                    motion = 1;//공격 모션으로 전환
                    aim = NUMB;

                }
                else if (x < K) { x++; aim = 0; }
                else { aim = 0; }
            }
        }
        public void testunit_sumon1()
        {
            name = "test1";
            type = 0;
            maxhp = 20;
            hp = maxhp;
            maxmp = 20;
            x = 483;
            y = 129;//기지의 위치로 좌표 설정 예정
            pow = 2;
            def = 1;
            spd = 2;
            line = 0;
            AI = 0;
            number = 1;
            range = 20;
            knockback = 0;
            Dknockback = 0;
            live = 1;
            liven = 1;
            frame1 = 0;
            frame2 = 3;
            
            motion = 0;
        }
        public void testunit_sumon2()
        {
            name = "test1";
            type = 1;
            maxhp = 20;
            hp = maxhp;
            maxmp = 20;
            x = 483;
            y = 129;//기지의 위치로 좌표 설정 예정
            pow = 2;
            def = 1;
            spd = 2;
            line = 0;
            AI = 0;
            number = 1;
            range = 20;
            knockback = 0;
            Dknockback = 0;
            live = 1;
            liven = 1;
            frame1 = 0;
            frame2 = 3;
            frame3 = 100;
            motion = 0;
        }


        /// //데미지 판정
        /// 
        /////
        public int livecheck() { return live; }
        public int hit() { return def; }//방어력을 리턴
        public int hited() { return pow; }//공격력을 리턴
        public int hpReturn() { return hp; }
        public int attackcheck(int K)//상대방의 방어력을 불러와 공격력에서 뺀 후 리턴
        {
            int dam;
            dam = pow - K;//
            if (dam <= 0) { dam = 1; }//만약 1이하이면 데미지 1만 받음
            return dam;//최종 데미지를 리턴
        }


        public void hitcheck(int K)//위에서 리턴받은 최종 데미지를 체크,동시에 사망판정
        {
            int GGg = K-def;
            if (GGg <= 0) { GGg = 1; }
            hp = hp - GGg;//
            if (hp <= 0) { live = 0; }
        }
        public void motionset(int K) { motion = K; }//모션을 밖에서 변경하는법
        public int motionReturn() { return motion; }
        public int frameset() { return frame1; }
        public void motionChange() { if (motion == 1 || frame1 >= frame2) { motion = 2; } else if (frame1 < frame2) { motion = 0; } }//모션변경
        public void framego() { frame1++; }//1공격대기

        public void motionBack() { if (motion == 3 || frame1 > frame3) { motion = 0; frame1 = 0; } }//원래대로 돌아옴
        /// </summary>
        public void testunit()
        {
            name = "test";
            type = 9999;
            maxhp = 9999;
            hp = 9999;
            maxmp = 9999;
            x = 41;
            y = 129;//기지의 위치로 좌표 설정 예정
            pow = 10;
            def = 10;
            spd = 2;
            line = 0;
            AI = 0;
            number = 9999;
            range = 10;

        }
    }
}
