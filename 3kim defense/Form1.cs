using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3kim_defense
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        
        int frame;//화면을 제어하는 변수입니다. 0=타이틀,1=설정 등 frame에 따라 장면이 나누어지게 할 예정입니다.
        //이곳에 frame을 추가할 때마다 frame의 역할을 적습니다.
        //0,1=타이틀, 2=로딩 3=월드맵 
        //101=1스테이지 화면(스테이지는 100부터) 
        unit[] Player = new unit[100];//유닛 개수를 지정
        int PlayerCount;//플레이어 개체의 개수를 지정
        int TargetA;//아군의 공격목표
        int TargetB;//적군의 공격목표
        int TargetAX;//아군 목표의 x값
        int TargetBX;
        private void background_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox9.Image = _3kim_defense.Properties.Resources.화면;
            frame = 0;
            PlayerCount = 0;
            
            for (int G = 0; G < 100; G++) {
                Player[G] = new unit();
            }//유닛들을 다 지정

            
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (frame == 0)
            {
                pictureBox9.Image = _3kim_defense.Properties.Resources.화면2;
                frame = 1;
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (frame == 1)
            {
                pictureBox9.Image = _3kim_defense.Properties.Resources.화면;
                frame = 0;
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (frame ==0)
            {
                pictureBox9.Image = _3kim_defense.Properties.Resources.월드맵;
                frame = 3;
               
            }
            if (frame == 3)
            {
                pictureBox9.Image = _3kim_defense.Properties.Resources.월드맵;
                frame = 4;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)//기본 시간 타이머
        {
            pictureBox9.SendToBack();
            if (frame == 0) { cirsur.Top = 203; cirsur.Left = 337;

            }
            if (frame == 1) {cirsur.Top = 239; cirsur.Left = 338;

            }
            if (frame == 3) { cirsur.Top = 148; cirsur.Left = 215;
                gametimer.Enabled = false;//게임타이머를 멈춘다.
            }//커서를 1스테이지에 세트
            if (frame == 4) { pictureBox9.Image = _3kim_defense.Properties.Resources.게임화면;
                gametimer.Enabled = true;//게임타이머를 돌린다.
                startUp.Enabled = true;
            }
            //여기는 프레임과 변수들을 표현해서 출력하는 장소입니다.
            label2.Text = frame.ToString();
        }

        public void pictures(PictureBox K) { this.Controls.Add(K); }
        PictureBox Kk = new PictureBox();
        private void button4_Click(object sender, EventArgs e)
        {
          
            Kk.SetBounds(1, 1, 120, 120);
            Kk.Image = _3kim_defense.Properties.Resources.게임화면;
            
            Controls.Add(Kk);

        }
         private void startUp_Tick(object sender, EventArgs e)//게임시작전에 해야할일
        {
            for (int GGG=0; GGG < 100; GGG++) { Player[GGG].uninit(); }
            //이쪽에 몬스터도 게시한다.
            TargetAX = 0;
            TargetBX = 999;//B는 오른쪽에서 시작하기 때문
            TargetA = 0;
            TargetB = 0;
            startUp.Enabled = false;
        }
    

        private void gametimer_Tick(object sender, EventArgs e)//게임타이머가 하는일은 유닛의 이동 설정,공격 설정,데미지 판정 설정입니다.
        {//타겟은 시시때때로 변경되어야 합니다.
            TargetAX = 0;
            TargetBX = 999;//B는 오른쪽에서 시작하기 때문
            TargetA = 0;
            TargetB = 0;
            int Live = 0;//유닛의 생사 결정
            for (int i = 0; i < PlayerCount; i++)
            {//유닛들 이동
                Live = Player[i].livecheck();//live를 리턴
                if (Live == 1)//살아있을 때만 움직인다. for문마다 넣어줌
                {
                    int GL = Player[i].motionReturn();//유닛의 모션 변수를 불러올거임

                    if (GL == 0) { Player[i].umove(); }//모션이 0일 경우에만 이동
                    if (Player[i].XIN() > TargetBX) { TargetBX = Player[i].XIN(); TargetB = i; }//타겟의 X값이 가장 큰값을 찾는다.
                }
            }//이동 페이즈
            for (int i = 0; i < PlayerCount; i++)//감지 후 모션변경 페이즈
            {
                Live = Player[i].livecheck();//live를 리턴
                if (Live == 1)
                {
                    Player[i].rangechecking(TargetA, TargetAX);

                    Player[i].framego();//프레임++
                    Player[i].motionChange();//모션이 1인데 프레임이 넘은 사람은 2로
                }
            }
            for (int i = 0; i < PlayerCount; i++)
            {//실제 공격 페이즈
                Live = Player[i].livecheck();//live를 리턴
                if (Live == 1)//살아있을 때만 움직인다.
                {
                    int GL = Player[i].motionReturn();//유닛의 모션 변수를 불러올거임
                    if (GL == 2)
                    {
                        int PPOWER;//빠워 변수
                        Player[i].motionset(3);//모션을 3으로 변경,중복 공격 방지를 위함
                        PPOWER = Player[i].hited();//플레이어의 공격력을 리턴
                                                   /*
                                                   여기는 가상의 적 클래스가 만들어졌다고 가정하고 씁니다.
                                                   에너미[TargetA].hit(pow);를 실행//받은 데미지를 방어력에 빼서 처리하는 함수+0이하가 되면 죽게 처리하는 함수

                                               */
                    }//공격을 했다는 표시가 나오면 
                }
            }
        }
         
        //클릭하면 유닛 소환
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }




}
