using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp1_My_Precious_Eyes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ////// ////////////////음악 추가하기//////////// ////////////////
            _soundPlayer = new SoundPlayer("파일명");
        }
        int interval;

        
        private void alarm(int interval)
        {
            timer1.Start();
            //timer1.Interval = interval * 60 * 1000;
            timer1.Interval = 10000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedItem.ToString() + "분 마다 알람이 울립니다.";
            interval = Convert.ToInt32(comboBox1.SelectedItem);
            alarm(interval);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] combo_Lists = { "30", "45", "50", "60", "90", "else" };
            comboBox1.Items.AddRange(combo_Lists);
            comboBox1.SelectedIndex = 3; //set default

        }
        private SoundPlayer _soundPlayer;
        private void timer1_Tick(object sender, EventArgs e)
        {
            circularProgressBar1.Increment(100/interval);
            circularProgressBar1.PerformStep();


            Random rnd = new Random();
            int val = rnd.Next(1, 9);
            this.TopMost = true;
            _soundPlayer.Play();
            /// ///////////////재생 시간 delay//////// ////////////////
      
            _soundPlayer.Stop();


            string Path = @"c:\Users\the_Almighty_Denver\Desktop\img_folder\";
            string FileName = val.ToString() + ".jpg";
            pictureBox1.Image = System.Drawing.Image.FromFile(Path + FileName);
            


        }






        /// /////////////////// 무음 모드/////////////////// ////////////////
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)//체크가 된 상태
            {
                this.TopMost = true;
            }
            if (checkBox1.Checked == false)//체크를 해제한 상태
            {
                this.TopMost = false;
            }
        }

        /// /////////progressbar 정지, 재시작 기능 넣기 /////////////////// ////////////
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox3.Text = "재시작";
                

            }
            else
            {
                checkBox3.Text = "일시 정지";

            }
        }

        //사진 클릭하면 다른 사진으로 바뀜
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int val = rnd.Next(1, 9);
            string Path = @"c:\Users\the_Almighty_Denver\Desktop\img_folder\";
            string FileName = val.ToString() + ".jpg";
            pictureBox1.Image = System.Drawing.Image.FromFile(Path + FileName);
        }












        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

    }
}
