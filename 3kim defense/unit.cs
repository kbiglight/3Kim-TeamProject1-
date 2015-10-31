using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace _3kim_defense
{
    class unit : Form1
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
        public int range;//몬스터의 인식범위
        public int knockback;//넉백공격의 수치(넉백저항-넉백공격 수치만큼 넉백이벤트)
        public int Dknockback;//넉백저항의 수치
        public PictureBox picture = new PictureBox();
        void sumon(string aname,int atype, int amaxhp,int amaxmp,int amp,int ax,int ay,int apow,int adef,int aspd,int aline,int aAI,int anumber,int arange,int width,int height,int aknockback,int aDknockback) {//
            //몬스터의 데이더베이스에서 몬스터 정보를 불러오는 함수
            name = aname;
            type = atype;
            maxhp = amaxhp;
            hp = maxhp;
            maxmp = amaxmp;
            x = ax;
            y = ay;//기지의 위치로 좌표 설정 예정
            pow = apow;
            def = adef;
            spd = aspd;
            line = aline;
            AI = aAI;
            number = anumber;
            range = arange;
            picture.Location = new Point(0,0);//나중에 유닛이 소환되는 장소로 변경
            picture.Size = new Size(width, height);//유닛의 크기 지정
            picture.Image = _3kim_defense.Properties.Resources.커서2;//나중에 유닛의 애니메이션 지정(현재는 임시로 함)
            pictures(picture);
        }
        void umove() {
            x = x + spd;//x좌표가 spd 수치만큼 변경
            //이동 모션으로 이미지 변경
        }//이동
        void rangecheck(int enemyx) {//적 유닛의 x좌표
            if (enemyx > x + range) {/*공격 이벤트
                attack();//이동 모션에서 공격 모션으로 변경
                //공격 모션이 끝난 후 판정
                //만약 적이 무적시간이 아니라면 데미지 판정 공격력-방어력(만약 0이하라면 1)
                */ }//적 유닛의 x좌표가 아군 유닛의 x좌표+사정거리 내에 들어왔을 때 공격 이벤트 실행
        }
    }
}
