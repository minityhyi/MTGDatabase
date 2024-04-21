using MTG.Common.Repository.Interfaces;
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
    public partial class ImportForm : Form
    {
        private readonly IDeckRepository deckRepository;

        public ImportForm(IDeckRepository deckRepository)
        {
            InitializeComponent();
            this.deckRepository = deckRepository;
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {

        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            var path = ImportPathTextbox.Text;
            deckRepository.ImportDeck(path);
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = -1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                ImportPathTextbox.Text = openFileDialog1.FileName;
            }
        }
    }
}
