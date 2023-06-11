using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NpgsqlTypes;

namespace NovoTest {
    public partial class LoginForm : Form {


        public LoginForm() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {


        }


        private void button_click(object sender, EventArgs e) {
            foreach (var button in this.Controls.OfType<Button>()) {
                if (button.Focused) {
                    txtID.AppendText(button.Text.ToString());

                }

            }


        }

        private void btn_back_Click(object sender, EventArgs e) {
            try {
                string backspace = txtID.Text;
                backspace = backspace.Remove(backspace.Length - 1);
                txtID.Text = backspace;

            } catch (Exception ex) {
                //lbl_massage.Text = (ex.ToString());
            }

        }

        private void btn_enter_Click(object sender, EventArgs e) {
            bool blnfound = false;
            NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5433; User Id=postgres;Password=miha; Database=DbTest;");
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from korisnici where pass= '" + txtID.Text + "'", con);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) {

                blnfound = true;

                Form2 form2 = new Form2();
                form2.Show();
                Hide();
        

            }

            if (blnfound == false) ;
            {

               // lbl_massage.Text = "Unesena kriva lozinka";
               
            }
            dr.Close();
            con.Close();
        }
    }
}

        
    

