using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MyLibrary
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private bool UserIsValid()
        {
            XElement korisnici = XElement.Load("korisnici.xml");
            var users = from user in korisnici.Elements()
                        select new { username = (string)user.Element("korisnickoIme"), password = (string)user.Element("lozinka") };

            foreach (var user in users)
            {
                if (String.Compare(user.username, this.textBoxUsername.Text, true) == 0 && user.password == this.textBoxPassword.Text)
                {
                    return true;
                }
            }

            return false;
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (UserIsValid())
            {
                Close();
                return;
            }
            MessageBox.Show(this, "Invalid Username or Password!", "User Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
