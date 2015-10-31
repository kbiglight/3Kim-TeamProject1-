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
        unit Test;////////테스트용 유닛
     
        private void background_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox9.Image = _3kim_defense.Properties.Resources.화면;
            frame = 0;
            
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
            }
        }

        public void pictures(PictureBox K) { this.Controls.Add(K); }
        PictureBox Kk = new PictureBox();
        private void button4_Click(object sender, EventArgs e)
        {
          
            Kk.SetBounds(1, 1, 120, 120);
            Kk.Image = _3kim_defense.Properties.Resources.게임화면;
            
            Controls.Add(Kk);
            Test.testunit();
        }

        private void gametimer_Tick(object sender, EventArgs e)//게임타이머가 하는일은 유닛의 이동 설정,공격 설정,데미지 판정 설정입니다.
        {
            /*for (int i = 0; i > 100; i++) {//유닛들 이동
                Player[i].umove();
            
                if (Player[i + 1].liven == 0) { break; }
            }*/
            Test.umove();
        }
    }




}
