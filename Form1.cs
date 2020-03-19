using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1_eyes.Properties;

namespace WindowsFormsApp1_eyes
{
    public partial class Form1 : Form
    {
        private int total_seconds;
        private int rmn_seconds;
        private SoundPlayer _soundPlayer;
        public Form1()
        {
            InitializeComponent();
            
            //음악 추가하기
            _soundPlayer = new SoundPlayer("파일명");
        }

        //창 맨 위로, 소리, 사진 추가하기
        private void alarm()
        {
            this.TopMost = true;

            ///show image randomly
            System.DateTime moment = DateTime.Now;
            int sec = moment.Second;
            while(sec >= 10)
            {
                sec = sec / 10 + sec % 10;

            }
            if (sec == 0) sec = 1;
            else if (sec == 9) sec = 8;
            Console.WriteLine(sec);
            string pic_name = "_" + sec;
            object obj = Resources.ResourceManager.GetObject(pic_name);
            pictureBox1.Image = (Image)obj;

            //play ringtone
 
        }



        /// start button
        private void button1_Click_1(object sender, EventArgs e)
        {
            int minutes = int.Parse(this.comboBox1.SelectedItem.ToString());
            total_seconds = minutes * 60;
            rmn_seconds = total_seconds;
            this.timer1.Enabled = true;

            textBox1.Text = comboBox1.SelectedItem.ToString() + "분 후에 알람이 울립니다.";
            //interval = Convert.ToInt32(comboBox1.SelectedItem);
            //interval = total_seconds;
        }
        // Test Ringtone
        private void button2_Click_1(object sender, EventArgs e)
        {

        }
        /// Pause
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "일시정지";
                this.timer1.Enabled = true;
            }
            else
            {
                checkBox1.Text = "재시작";
                this.timer1.Enabled = false;
            }
        }



        // Silent mode
        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }


        /// TopMost
        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;

            }

        }

        // Set Ringtone
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
               
        }
        // Stop Playing
        private void button3_Click_1(object sender, EventArgs e)
        {

        }




        /// timer
        private void timer1_Tick_1(object sender, EventArgs e)
        {

            if (rmn_seconds > 0)
            {
                rmn_seconds--;
                ///progressbar
                double pgbar = 0;
                pgbar = (double)(total_seconds - rmn_seconds) / total_seconds * 100;
                circularProgressBar1.Value = (int)pgbar;

                ///write remaining time on Label
                int minutes = rmn_seconds / 60;
                int seconds = rmn_seconds - minutes * 60;
                Console.WriteLine(minutes + " " + seconds);
                if (minutes < 10 && seconds >= 10) this.label1.Text = "0" + minutes.ToString() + ":" + seconds.ToString();
                else if (minutes >= 10 && seconds < 10) this.label1.Text = minutes.ToString() + ":0" + seconds.ToString();
                else if(minutes < 10 && seconds < 10) this.label1.Text = "0" + minutes.ToString() + ":0" + seconds.ToString();
                else this.label1.Text = minutes.ToString() + ":" + seconds.ToString();

            }
            else
            {
                ///timer 시간
                this.timer1.Stop();
                alarm();
            }
        }







        private void Form1_Load(object sender, EventArgs e)
        {
            string[] combo_Lists = { "0", "30", "45", "50", "60", "90" };
            comboBox1.Items.AddRange(combo_Lists);
            comboBox1.SelectedIndex = 0; //set default


            string[] ringtone_Lists = { "Analog Watch Alarm Sound", "Baby Music Box Sound", "Cartoon Birds 2 Sound", "Hello Baby Girl Sound", "Santa Clause Jolly Laugh Sound", "Service Bell Help Sound", "Sunny Day Sound", "Ticking Clock Sound" };
            comboBox2.Items.AddRange(ringtone_Lists);
            comboBox2.SelectedIndex = 0;

            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
        }




        ///current time timer
        private void timer2_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString();
        }
    }
}
