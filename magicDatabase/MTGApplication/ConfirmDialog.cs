using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTGApplication
{
    public partial class ConfirmDialog : Form
    {
        public ConfirmDialog(Action confirmAction)
        {
            InitializeComponent();
            ConfirmAction = confirmAction;
        }

        public Action ConfirmAction { get; set; }

        public void SetDeckName(string deckName)
        {
            deckNameLabel.Text = deckName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfirmAction();
            Close();
        }
    }
}
