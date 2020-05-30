using Dnevnik.DnevnikClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik
{
    public partial class SettingsForm : Form
    {
        bool settingsSave = true;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void ResetSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            UpdateData();
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            UpdateData();

            settingsSave = true;
        }

        private string GetTextProperties(int num)
        {
            return Properties.Settings.Default["nameLess" + num].ToString();
        }

        private void SetData()
        {
            Properties.Settings.Default.nameLess1 = textBox1.Text;
            Properties.Settings.Default.nameLess2 = textBox2.Text;
            Properties.Settings.Default.nameLess3 = textBox3.Text;
            Properties.Settings.Default.nameLess4 = textBox4.Text;
            Properties.Settings.Default.nameLess5 = textBox5.Text;
            Properties.Settings.Default.nameLess6 = textBox6.Text;
            Properties.Settings.Default.nameLess7 = textBox7.Text;
            Properties.Settings.Default.nameLess8 = textBox8.Text;
            Properties.Settings.Default.nameLess9 = textBox9.Text;
            Properties.Settings.Default.nameLess10 = textBox10.Text;

            Properties.Settings.Default.averBall1 = Convert.ToSingle(Mark2.Value);
            Properties.Settings.Default.averBall2 = Convert.ToSingle(Mark3.Value);
            Properties.Settings.Default.averBall3 = Convert.ToSingle(Mark4.Value);
            Properties.Settings.Default.marksClassmates = ClassmatesInsert.Checked;
        }

        private void UpdateData()
        {
            textBox1.Text = GetTextProperties(1);
            textBox2.Text = GetTextProperties(2);
            textBox3.Text = GetTextProperties(3);
            textBox4.Text = GetTextProperties(4);
            textBox5.Text = GetTextProperties(5);
            textBox6.Text = GetTextProperties(6);
            textBox7.Text = GetTextProperties(7);
            textBox8.Text = GetTextProperties(8);
            textBox9.Text = GetTextProperties(9);
            textBox10.Text = GetTextProperties(10);

            Mark2.Value = Convert.ToDecimal(Properties.Settings.Default.averBall1);
            Mark3.Value = Convert.ToDecimal(Properties.Settings.Default.averBall2);
            Mark4.Value = Convert.ToDecimal(Properties.Settings.Default.averBall3);
            ClassmatesInsert.Checked = Properties.Settings.Default.marksClassmates;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!settingsSave)
            {
                DialogResult quest = MessageBox.Show("Настройки не были сохранены, сохранить?", "Сохранить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (quest == DialogResult.Yes)
                    SaveSettings.PerformClick();
            }
        }

        private void SaveSettings_Click(object sender, EventArgs e)
        {
            SetData();
            Properties.Settings.Default.Save();
            settingsSave = true;
            MessageBox.Show("Настройки сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ChangeValue(object sender, EventArgs e)
        {
            settingsSave = false;
        }

        private new void TextChanged(object sender, EventArgs e)
        {
            settingsSave = false;
        }
    }
}
