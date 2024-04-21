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
    public partial class DeckForm : Form
    {
        private readonly IDeckRepository deckRepository;
        private string originalDeckName { get; set; }

        public DeckForm(IDeckRepository deckRepository)
        {
            InitializeComponent();
            this.deckRepository = deckRepository;
        }

        public void SetDeckName(string deckName)
        {
            originalDeckName = deckName;
            deckNameTextbox.Text = deckName;
        }

        private void renameBtn_Click(object sender, EventArgs e)
        {
            var newDeckName = deckNameTextbox.Text;
            deckRepository.RenameDeck(originalDeckName, newDeckName);
            renameLabel.Text = "Deck is renamed";
        }
    }
}
