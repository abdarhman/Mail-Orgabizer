using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Net;
using System.Net.Mail;

namespace Mail_Organizer
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox3_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox4_Click(object sender, EventArgs e)
        {

        }

        private void Send_Click(object sender, EventArgs e)
        {
            MailMessage message = new MailMessage();
            foreach(string ad in metroTextBox1.Text.Split(',')){ message.To.Add(ad); }
            message.From = new MailAddress(metroTextBox5.Text);
            message.Subject = metroTextBox3.Text;
            //message.CC.Add(metroTextBox2.Text);
            message.Body = metroTextBox4.Text;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(metroTextBox5.Text, metroTextBox6.Text);
            if(metroComboBox1.Text == "Gmail Account")
            {
                client.Host = "smtp.gmail.com";
                client.Port = 587;
            }
            else if (metroComboBox1.Text == "Microsoft Account")
            {
                client.Host = "smtp.live.com";
                client.Port = 587;
            }
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(message);
            MessageBox.Show("Your E-mail has been sent !");
            metroTextBox1.Text = "";
            metroTextBox2.Text = "";
            metroTextBox3.Text = "";
            metroTextBox4.Text = "";
        }

        private void Back_Click(object sender, EventArgs e)
        {
            metroTextBox1.Text = "";
            metroTextBox2.Text = "";
            metroTextBox3.Text = "";
            metroTextBox4.Text = "";
            metroPanel1.Visible = true;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            metroPanel1.Visible = false;
        }
    }
}
