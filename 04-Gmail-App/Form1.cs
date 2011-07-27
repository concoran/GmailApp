using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace _04_Gmail_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(textBoxUsr.Text + "@gmail.com", textBoxDispName.Text);
            mail.To.Add(textBoxTo.Text);
            mail.Subject = textBoxSubject.Text;
            mail.Body = textBoxBody.Text;

            SmtpClient mailclnt = new SmtpClient("smtp.gmail.com");
            mailclnt.Port = 587;
            mailclnt.Credentials = new System.Net.NetworkCredential(textBoxUsr.Text, textBoxPwd.Text);
            mailclnt.EnableSsl = true;

            Clipboard.SetText(textBoxBody.Text);

            try
            {
                this.Cursor = Cursors.WaitCursor;
                mailclnt.Send(mail);
            }
            catch (SmtpException mailE)
            {
                MessageBox.Show(mailE.Message);
            }

            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}

