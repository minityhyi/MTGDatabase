using MTG.Common.DomainModels;
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
        private string OriginalDeckName { get; set; }

        public DeckForm(IDeckRepository deckRepository)
        {
            InitializeComponent();
            this.deckRepository = deckRepository;
        }

        public void SetDeckName(string deckName)
        {
            OriginalDeckName = deckName;
            deckNameTextbox.Text = deckName;
            ReloadCards();
        }

        private void renameBtn_Click(object sender, EventArgs e)
        {
            var newDeckName = deckNameTextbox.Text;
            deckRepository.RenameDeck(OriginalDeckName, newDeckName);
            renameLabel.Text = "Deck is renamed";
            OriginalDeckName = newDeckName;
        }

        public void ReloadCards()
        {
            CardsPanel.Controls.Clear();
            CardsPanel.AutoScroll = true;
            var cards = deckRepository.GetDeck(OriginalDeckName);

            for (var i = 0; i < cards.Count; i++)
            {
                var card = cards[i];
                var cardButton = new Button();

                cardButton.Size = new Size(150, 50);
                cardButton.Location = new Point(10,
                    (i * 10) + (i * cardButton.Size.Height));
                cardButton.Text = card.Name;
                cardButton.Name = "deckButton";
                cardButton.Show();

                var deleteButton = CreateDeleteButton(cards, i, cardButton);

                CardsPanel.Controls.Add(cardButton);
                CardsPanel.Controls.Add(deleteButton);
            }

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            var search = SearchTextbox.Text;
            
            var cards = Card.Search(search);

            SearchCardPanel.Controls.Clear();
            SearchCardPanel.AutoScroll = true;

            for (var i = 0; i < cards.Count; i++)
            {
                var card = cards[i];
                var cardButton = CreateCardButton(i, card);
                var addButton = CreateAddButton(card, cardButton);

                SearchCardPanel.Controls.Add(cardButton);
                SearchCardPanel.Controls.Add(addButton);
            }
        }

        private Control CreateAddButton(Card card, Button CardButton)
        {
            var addButton = new Button();
            addButton.Text = "Add";
            addButton.Size = new Size(80, 30);
            addButton.Location = new Point(CardButton.Location.X + CardButton.Size.Width + 10,
                CardButton.Location.Y + (CardButton.Size.Height / 2) - (addButton.Size.Height / 2));
            addButton.Click += CardButton_DoubleClick;
            addButton.Name = card.Name;
            addButton.Show();
            return addButton;
        }

        private Button CreateCardButton(int i, Card card)
        {
            var cardButton = new Button();

            cardButton.Size = new Size(150, 50);
            cardButton.Location = new Point(10,
                (i * 10) + (i * cardButton.Size.Height));
            cardButton.DoubleClick += CardButton_DoubleClick;
            cardButton.Text = card.Name;
            cardButton.Name = card.Name;
            cardButton.Show();
            return cardButton;
        }

        private void CardButton_DoubleClick(object? sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            var clickedButton = (Button)sender;
            var cardName = clickedButton.Name;
            AddCard(cardName);
            ReloadCards();
        }

        private void AddCard(string cardName)
        {
            var card = Card.FindCard(cardName);

            deckRepository.AddCardToDeck(OriginalDeckName, card, true);
        }

        private Button CreateDeleteButton(List<Card> cards, int i, Button CreateCardButton)
        {
            var deleteButton = new Button();
            deleteButton.Text = "X";
            deleteButton.Size = new Size(30, 30);
            deleteButton.Location = new Point(CreateCardButton.Location.X + CreateCardButton.Size.Width + 10,
                CreateCardButton.Location.Y + (CreateCardButton.Size.Height / 2) - (deleteButton.Size.Height / 2));
            deleteButton.Click += DeleteButton_Click;
            deleteButton.Name = cards[i].Name;
            deleteButton.Show();
            return deleteButton;
        }

        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            var deleteBtn = (Button)sender;
            var cardName = deleteBtn.Name;
            DeleteCard(cardName);
        }

        private void DeleteCard(string cardName)
        {
            var confirmDialog = new ConfirmDialog(() =>
            {
                deckRepository.RemoveCard(OriginalDeckName, cardName);
            });
            confirmDialog.SetDeckName(cardName);
            confirmDialog.ShowDialog();
        }

    }
}
