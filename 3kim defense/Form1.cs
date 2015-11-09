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

        Graphics g;
        int frame; // 화면을 제어하는 변수입니다. 0 = 타이틀, 1 = 설정 등 frame에 따라 장면이 나누어지게 할 예정입니다.
                   // 이곳에 frame을 추가할 때마다 frame의 역할을 적습니다.
                   // 0, 1 = 타이틀,  2 = 로딩, 3 = 월드맵 
                   // 101 = 1스테이지 화면(스테이지는 100부터) 
        unit[] Player = new unit[100];//유닛 개수를 지정
        enemy[] Enemy = new enemy[100];//적 개수를 지정
        Tower T1 = new Tower();
        Tower T2 = new Tower();
        enemyAI AII = new enemyAI();
        int PlayerCount; // 플레이어 개체의 개수를 지정
        int EnemyCount; // 적 개체수를 지정
        int TargetA; // 아군의 공격목표
        int TargetB; // 적군의 공격목표
        int TargetAX; // 아군 목표의 x값
        int TargetBX;
        int Timer; // 시간 안내
        // int GT; // 그래픽 타이머
        int Mana;

        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer  | ControlStyles.AllPaintingInWmPaint
                                    | ControlStyles.UserPaint  | ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
        }

        private void background_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox9.CreateGraphics();
            pictureBox9.Image = _3kim_defense.Properties.Resources.화면;
            g = pictureBox9.CreateGraphics();
            frame = 0;
            PlayerCount = 0;
            EnemyCount = 0;
            for (int G = 0; G < 100; G++) // 유닛들을 전부 지정 
            {
                Player[G] = new unit(); 
            }
            for (int G = 0; G < 100; G++) // 적들을 전부 지정
            {
                Enemy[G] = new enemy();
            }
            Timer = 0;
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

        private void timer1_Tick(object sender, EventArgs e) // 기본 시간 타이머
        {
            pictureBox9.SendToBack();

            if (frame == 0)
            {
                cirsur.Top = 203;
                cirsur.Left = 337;
            }

            if (frame == 1)
            {
                cirsur.Top = 239;
                cirsur.Left = 338;
            }

            if (frame == 3) // 커서를 스테이지 1에 세트
            {
                cirsur.Top = 148;
                cirsur.Left = 215;
                gametimer.Enabled = false; // 게임타이머를 멈춘다.
            }

            if (frame == 4)  // pictureBox9.Image = _3kim_defense.Properties.Resources.게임화면
            {
                gametimer.Enabled = true; // 게임타이머를 돌린다.
                GraphicTimer.Enabled = true;
                if (Timer <=2) { startUp.Enabled = true; }
            }

            if (frame == 5)
            {
                pictureBox9.Image = _3kim_defense.Properties.Resources.lose;
                gametimer.Enabled = false;
                GraphicTimer.Enabled = false;
            }

            if (frame == 6)
            {
                pictureBox9.Image = _3kim_defense.Properties.Resources.win;
                gametimer.Enabled = false;
                GraphicTimer.Enabled = false;
            }
           
            
            //여기는 프레임과 변수들을 표현해서 출력하는 장소입니다.
            int P;
            int H;
            label2.Text = frame.ToString();
            label3.Text = PlayerCount.ToString();
            P = Player[0].XIN();
            label6.Text = P.ToString();
            label7.Text = Timer.ToString();
            P = Player[0].motionReturn();
            label8.Text = P.ToString();
            label10.Text = TargetA.ToString();
            P = T2.towethp();
            label12.Text = P.ToString();
            P = Enemy[0].XIN();
            label13.Text = P.ToString();
            P = Enemy[0].motionReturn();
            label14.Text = P.ToString();
            label16.Text = TargetAX.ToString();
            H = Enemy[0].motionReturn();
            label18.Text = H.ToString();
            H = Enemy[0].frameset();
            label18.Text = H.ToString();
            H = Player[0].hpReturn();
            label19.Text = H.ToString();
            H = Enemy[0].hpReturn();
            label20.Text = H.ToString();
            P = T1.towethp();
            label21.Text = P.ToString();
            label22.Text = TargetB.ToString();
            label23.Text = Mana.ToString();

        }

        public void pictures(PictureBox K) { this.Controls.Add(K); }

        PictureBox Kk = new PictureBox();

        private void button4_Click(object sender, EventArgs e)
        {
            if (Mana > 10)
            {
                Mana = Mana - 10;
                Player[PlayerCount].testunit_sumon1();
                PlayerCount++;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Mana > 50)
            {
                Mana = Mana - 50;
                Player[PlayerCount].testunit_sumon2();
                PlayerCount++;
            }
        }

        private void startUp_Tick(object sender, EventArgs e) // 게임시작전에 해야할일
        {
            for (int GGG=0; GGG < 100; GGG++) { Player[GGG].uninit(); } // 유닛 초기화
            for (int GGG = 0; GGG < 100; GGG++) { Enemy[GGG].uninit(); } //  적 초기화
            T1.towerset(0); // 아군 타워에 HP와 X값 부여
            T2.towerset(1); // 적군 타워에 HP와 X값 부여
            TargetAX = 483;
            TargetBX = 26; // B는 오른쪽에서 시작하기 때문
            TargetA = 0;
            TargetB = 0;
            startUp.Enabled = false;
            PlayerCount = 0;
            EnemyCount = 0;
            Mana = 0;
        }
    
        
        private void gametimer_Tick(object sender, EventArgs e) // 게임타이머가 하는일은 유닛의 이동 설정,공격 설정,데미지 판정 설정입니다.
                                                                                                              // 타겟은 시시때때로 변경되어야 합니다.  
        {
            Timer++;
            if (Mana < 100) {Mana++; }

            if (T1.towethp() <= 0 && Timer > 2)
            {
                frame = 5;
            }
            if (T2.towethp() <= 0 && Timer > 2)
            {
                frame = 6;
            }

           
            // 여기는 아군측의 행동입니다.
            for (int i = 0; i < PlayerCount; i++) // 유닛들 이동, 이동 페이즈
            {
                if (Player[i].livecheck() == 1) // 살아있을 때만 움직인다. for문마다 넣어줌
                {
                    Player[i].motionBack();
                    int GL = Player[i].motionReturn(); // 유닛의 모션 변수를 불러올거임

                    if (GL == 0) { Player[i].umove(TargetAX); } // 모션이 0일 경우에만 이동
                    if (Player[i].XIN() > TargetBX) { TargetBX = Player[i].XIN(); TargetB = i; } // 타겟의 X값이 가장 큰값을 찾는다.
                }
            }

            if (TargetBX < 40) { TargetB = 101; } // 만약 특정 범위 내라면 타겟은 타워로 변경
            for (int i = 0; i < PlayerCount; i++) // 감지 후 모션변경 페이즈
            {
                if (Player[i].livecheck() == 1)
                {
                    Player[i].rangechecking(TargetA, TargetAX);

                    Player[i].framego(); // 프레임++
                    Player[i].motionChange(); // 모션이 1인데 프레임이 넘은 사람은 2로
                }
            }
            for (int i = 0; i < PlayerCount; i++) //실제 공격 페이즈
            {
                if  (Player[i].livecheck() == 1) // 살아있을 때만 움직인다.
                {
                    int GL = Player[i].motionReturn();//유닛의 모션 변수를 불러올거임
                    if (GL == 2)
                    {
                        int PPOWER; // 빠워 변수
                        Player[i].motionset(3); // 모션을 3으로 변경,중복 공격 방지를 위함
                        PPOWER = Player[i].hited(); // 플레이어의 공격력을 리턴
                        if (TargetA == 101)
                        {
                            T2.towerdamage(PPOWER);//타겟이 이럴경우 타워에게
                        }
                        else if(Enemy[TargetA].hpReturn()>0)
                        {
                            Enemy[TargetA].hitcheck(PPOWER);//타겟이 아닐경우 적에게
                        }                         
                        /*
                            여기는 가상의 적 클래스가 만들어졌다고 가정하고 씁니다.
                            에너미[TargetA].hit(pow);를 실행//받은 데미지를 방어력에 빼서 처리하는 함수+0이하가 되면 죽게 처리하는 함수
                         */
                    } // 공격을 했다는 표시가 나오면 
                }
            }


            // 여기서부턴 적군측 움직임
            // 여기는 적의 AI를 감지합니다.

  
            int AAA=0;
            Queue<int> AIQUEUE = new Queue<int>();
            if (AIQUEUE.Count == 0) { AIQUEUE = AII.stage1(); }
            
            if (Timer % 18 == 1) { AAA = AIQUEUE.Dequeue();}
            if (AAA == 1) { Enemy[EnemyCount].testunit_sumon1();EnemyCount++; }
            else if ( AAA==2 ) { Enemy[EnemyCount].testunit_sumon2(); EnemyCount++; }
            

            TargetAX = 483;
            TargetA = 101; // 목표 초기화

            for (int i = 0; i < EnemyCount; i++) // 유닛들 이동(이동 페이즈)
            {
                if (Enemy[i].livecheck() == 1) // 살아있을 때만 움직인다. for문마다 넣어줌
                {
                    Enemy[i].motionBack();
                    int GL = Enemy[i].motionReturn(); // 유닛의 모션 변수를 불러올거임
                    
                    if (GL == 0) { Enemy[i].umove(TargetBX); } // 모션이 0일 경우에만 이동
                    if (Enemy[i].XIN() < TargetAX) { TargetAX = Enemy[i].XIN(); TargetA = i; } // 타겟의 X값이 가장 큰값을 찾는다.
                }
            }

            if (TargetAX < 57) { TargetB = 101; }

            for (int i = 0; i < EnemyCount; i++) // 감지 후 모션변경 페이즈
            {
                if (Enemy[i].livecheck() == 1)
                {
                    Enemy[i].rangechecking(TargetB, TargetBX);

                    Enemy[i].framego(); // 프레임++
                    Enemy[i].motionChange();//모션이 1인데 프레임이 넘은 사람은 2로
                }
            }

            for (int i = 0; i < EnemyCount; i++) // 실제 공격 페이즈
            {
                if (Enemy[i].livecheck() == 1) // 살아있을 때만 움직인다.
                {
                    int GL = Enemy[i].motionReturn(); // 유닛의 모션 변수를 불러올거임
                    if (GL == 2)
                    {
                        int PPOWER; // 빠워 변수
                        Enemy[i].motionset(3); // 모션을 3으로 변경,중복 공격 방지를 위함
                        PPOWER = Enemy[i].hited(); // 플레이어의 공격력을 리턴
                        if (TargetB == 101)
                        {
                            T1.towerdamage(PPOWER); // 타겟이 이럴 경우 타워에게
                        }
                        else if(Player[TargetB].livecheck()==1)
                        {
                            Player[TargetB].hitcheck(PPOWER);//타겟이 아닐경우 적에게
                        }
                        /*
                            여기는 가상의아군 클래스가 만들어졌다고 가정하고 씁니다.
                            에너미[TargetA].hit(pow);를 실행//받은 데미지를 방어력에 빼서 처리하는 함수+0이하가 되면 죽게 처리하는 함수
                        */
                    } // 공격을 했다는 표시가 나오면 
                }
            }
            TargetBX = 26; // B는 오른쪽에서 시작하기 때문
            TargetB = 101; // 목표를 초기화
        }
         
        // 클릭하면 유닛 소환
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Mana > 10)
            {
                Mana = Mana - 10;
                Player[PlayerCount].testunit_sumon1();
                PlayerCount++;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Mana > 50)
            {
                Mana = Mana - 50;
                Player[PlayerCount].testunit_sumon2();
                PlayerCount++;
            }
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // 그림을 그립시다!
        private void GraphicTimer_Tick(object sender, EventArgs e)
        {
            g.DrawImage(_3kim_defense.Properties.Resources.게임화면, 0, 0, pictureBox9.Width, pictureBox9.Height); 
            for (int i = 0; i < PlayerCount; i++) // 유닛을 그림
            {
                if (Player[i].livecheck() == 1) // 살아있을 때만 움직인다. for문마다 넣어줌
                {
                    int SSSSS = Player[i].typing();
                    if (SSSSS == 0)
                    {
                        g.DrawImage(_3kim_defense.Properties.Resources.아직안_클리어, Player[i].XIN(), 219);
                    }
                    else if(SSSSS == 1)
                    {
                        g.DrawImage(_3kim_defense.Properties.Resources.앨리트, Player[i].XIN()-30, 150);
                    }
                    
                }
            }
            for (int i = 0; i < EnemyCount; i++) // 유닛을 그림
            {
                if (Enemy[i].livecheck() == 1) // 살아있을 때만 움직인다. for문마다 넣어줌
                {
                    g.DrawImage(_3kim_defense.Properties.Resources.클리어, Enemy[i].XIN(), 219);
                }
            }
        }
    }
}