using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiDiaryLibrary;

namespace Dnevnik
{
    public partial class LoginDnevnik : Form
    {
        public string keyAccess = "";
        public bool closedSuccess = false;

        public LoginDnevnik()
        {
            InitializeComponent();

            
        }

        private void MemberCred_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Введённые вами данные не будут сохранятся, будет сохраняться только AccessToken, для последующего доступа к дневнику.", "Иннформация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {   

                ApiDiary api = new ApiDiary(UserName.Text, Password.Text);

                if (memberCred.Checked)
                {
                    Properties.Settings.Default.keyAccess = api.GetAccessToken();
                    Properties.Settings.Default.Save();
                }
                else keyAccess = api.GetAccessToken();

                MessageBox.Show("Успешный вход!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                closedSuccess = true;

                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
