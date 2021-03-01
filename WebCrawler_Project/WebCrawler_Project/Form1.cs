using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using hap = HtmlAgilityPack;

namespace WebCrawler_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> title = new List<string>();
            List<string> num = new List<string>();

            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string html = wc.DownloadString("http://ncov.mohw.go.kr/");

            hap.HtmlDocument mydoc = new hap.HtmlDocument();
            mydoc.LoadHtml(html);

            var htmlNode = mydoc.DocumentNode.SelectSingleNode("//ul[@class='liveNum']");

            var numNode = htmlNode.SelectNodes("li");
            foreach (var item in numNode)
            {
                var titleDam = item.SelectSingleNode("strong[@class='tit']").InnerText;
                var numDam = item.SelectSingleNode("span[@class='num']").InnerText;
                Console.WriteLine($"타이틀 : {titleDam}");
                Console.WriteLine($"인원 : {numDam}");

                numDam = Regex.Replace(numDam, @"\D", "");

                title.Add(titleDam);
                num.Add(numDam);
            }

            label1.Text = title[0]+" : "+num[0] + " 명";
            label2.Text = title[1]+" : " + num[1] + " 명";
            label5.Text = title[2]+" : " + num[2] + " 명";
            label6.Text = title[3]+" : " + num[3] + " 명";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel5.Width += 3; //길어지는 panel
            if (panel5.Width >= 300)
            {
                timer1.Stop();
                this.Size = new System.Drawing.Size(390, 620);
                panel3.Visible = false;
                panel5.Visible = false;
            }

        }
    }
}