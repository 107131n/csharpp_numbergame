using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace 숫자_맞히기
{
    public partial class Form1 : Form
    {
        int computerNumber = 0;
        int count = 0;

        private int CountS = 0; //초 
        //int a = 1;
        private bool Toggle = false; //시작, 정지를 위한 toggle, false이면 멈춤,  true면 시간 덧셈


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl.Text = "[시작] 버튼을 클릭하세요.";
            txt.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread.Sleep(1000);

            lbl.Text = "1부터 100까지의 숫자를 입력하세요.";

            // 게임 시작
            Random rd = new Random();
            computerNumber = rd.Next(1, 101); // 1 ~ 100까지의 난수 생성
            count = 0;
            txt.Enabled = true; // 입력을 못 하게 함. [시작]을 누르면 입력 가능

            if (Toggle == false)
            {
                timer1.Start();
                timer2.Start();
                Toggle = true;
            }
            else 
            {
                timer1.Stop();
                timer2.Stop();
                Toggle = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if (txt.Text.Trim() == "")
            {
                txt.Focus();
                return;
            }
            int n = int.Parse(txt.Text);
            if (n == computerNumber)
            {
                int c = Convert.ToInt32(lblCount.Text) + 1;
                int t = Convert.ToInt32(lblTimer.Text); 
                lbl.Text = "정답입니다. " + c + "번의 도전 후 " + t + "초만에 성공했습니다.";
                timer1.Stop();
                timer2.Stop();
                Toggle = false;
            }
            else if (n < computerNumber)
            {
                lbl.Text = "더 큰 수를 입력하세요.";
            }
            else
            {
                lbl.Text = "더 작은 수를 입력하세요.";
            }
            count++;
            if (count > 9)
            {
                lbl.Text = "맞히지 못 했습니다.";
                txt.Enabled = false; // 입력을 못 하게 설정
                timer1.Stop();
                timer2.Stop();
                Toggle = false;
            }
            lblCount.Text = count.ToString();
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void timer1_Tick(object sender, EventArgs e) // 단순 덧셈 연산
        {
            ++CountS;
        }

        private void timer2_Tick(object sender, EventArgs e) // 조건문을 통한 lbl의 텍스트를 바꿔줌
        {
            lblTimer.Text = CountS.ToString();
        }
    }
}
