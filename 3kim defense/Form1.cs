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
        }

        private void timer1_Tick(object sender, EventArgs e)//기본 시간 타이머
        {
            if (frame == 0) { cirsur.Top = 203; cirsur.Left = 337; }
            if (frame == 1) {cirsur.Top = 239; cirsur.Left = 338;  }
            if (frame == 3) { cirsur.Top = 148; cirsur.Left = 215; }//커서를 1스테이지에 세트

        }
        void pictures(PictureBox K) { this.Controls.Add(K); }
        

    }




}
