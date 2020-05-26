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
    public partial class TabSettings : Form
    {
        public string nameTab = "";
        public bool type = false;

        public TabSettings(string nameButton, string oldNameTab, bool type)
        {
            InitializeComponent();

            CreateTab.Text = nameButton;
            NameTab.Text = oldNameTab;

            if (type)
                TypeAverage.Checked = true;
            else
                TypeAverageMass.Checked = true;
        }

        private void CreateTab_Click(object sender, EventArgs e)
        {
            if (NameTab.Text == "")
                MessageBox.Show("Имя вкладки не может быть пустой!");
            else
            {
                nameTab = NameTab.Text;
                
                if (!TypeAverage.Checked)
                    type = false;
                else
                    type = true;

                this.Close();
            }
        }
    }
}
