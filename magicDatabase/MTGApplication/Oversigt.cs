using Microsoft.Extensions.DependencyInjection;
using MTG.Common.DomainModels;
using MTG.Common.Repository.Interfaces;

namespace MTGApplication
{
    public partial class Oversigt : Form
    {
        private readonly IDeckRepository deckRepository;
        private readonly IServiceProvider serviceProvider;
        public Oversigt(IDeckRepository deckRepository, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.deckRepository = deckRepository;
            this.serviceProvider = serviceProvider;
            ReloadDecks();
        }

        private void showDeckBtn_Click(object sender, EventArgs e)
        {
            ReloadDecks();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            var newDeckName = DeckNameText.Text;

            deckRepository.CreateDeck(newDeckName);

            ReloadDecks();
        }

        private void ReloadDecks()
        {
            DeckPanel.Controls.Clear();

            allDecksLabel.Text = "Getting the decks...";
            var allDecks = deckRepository.GetAllDecks();
            allDecksLabel.Text = "Here you go.";

            for (var i = 0; i < allDecks.Count; i++)
            {
                var deckButton = CreateDeckButton(allDecks, i);
                var deleteButton = CreateDeleteButton(allDecks, i, deckButton);
                var menuStrip = CreateMenuButton(allDecks, i, deleteButton);

                DeckPanel.Controls.Add(menuStrip);
                DeckPanel.Controls.Add(deleteButton);
                DeckPanel.Controls.Add(deckButton);
                DeckPanel.AutoScroll = true;
            }

            allDecksLabel.Text = "Decks are loaded now.";
        }

        private Control CreateMenuButton(List<string> allDecks, int i, Button deleteButton)
        {
            var menuStrip = new MenuStrip();
            menuStrip.Location = new Point(
                deleteButton.Location.X + deleteButton.Size.Width + 10,
                deleteButton.Location.Y);
            menuStrip.Text = "...";
            menuStrip.Dock = DockStyle.None;
            menuStrip.AllowDrop = true;

            var menuOptions = new ToolStripMenuItem("...");
            menuOptions.DropDownItems.Add("Copy", null, (o, e) =>
            {
                deckRepository.Copy(allDecks[i]);
                ReloadDecks();
            });
            menuOptions.DropDownItems.Add("Export", null, (o,e) =>
            {
                deckRepository.ExportDeck(allDecks[i]);
            });
            menuOptions.DropDownItems.Add("Import", null, (o, e) =>
            {
                var importForm = serviceProvider.GetRequiredService<ImportForm>();
                importForm.Show();
            });
            menuOptions.DropDownItems.Add("Delete", null, (o, e) =>
            {
                DeleteDeck(allDecks[i]);
            });


            menuStrip.Items.Add(menuOptions);

            return menuStrip;
        }

        private Button CreateDeckButton(List<string> allDecks, int i)
        {
            var deckButton = new Button();

            deckButton.Size = new Size(150, 50);
            deckButton.Location = new Point(10,
                (i * 10) + (i * deckButton.Size.Height));
            deckButton.Text = allDecks[i];
            deckButton.Click += DeckClick;
            deckButton.Name = "deckButton";
            deckButton.Show();
            return deckButton;
        }

        private Button CreateDeleteButton(List<string> allDecks, int i, Button deckButton)
        {
            var deleteButton = new Button();
            deleteButton.Text = "X";
            deleteButton.Size = new Size(30, 30);
            deleteButton.Location = new Point(deckButton.Location.X + deckButton.Size.Width + 10,
                deckButton.Location.Y + (deckButton.Size.Height / 2) - (deleteButton.Size.Height / 2));
            deleteButton.Click += DeleteButton_Click;
            deleteButton.Name = allDecks[i];
            deleteButton.Show();
            return deleteButton;
        }

        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            if (sender == null)
            {
                allDecksLabel.Text = "Why?";
                return;
            }
            var deleteBtn = (Button)sender;
            var deckName = deleteBtn.Name;
            DeleteDeck(deckName);
        }

        private void DeleteDeck(string deckName)
        {
            var confirmDialog = new ConfirmDialog(() =>
            {
                deckRepository.DeleteDeck(deckName);
                ReloadDecks();
            });
            confirmDialog.SetDeckName(deckName);
            confirmDialog.ShowDialog();
        }

        private void DeckClick(object? sender, EventArgs e)
        {
            if (sender == null)
            {
                allDecksLabel.Text = "There is no sender :( ";
                return;
            }

            var btnSender = (Button)sender;
            allDecksLabel.Text = $"You clicked the deck {btnSender.Text}";

            var deckForm = serviceProvider.GetRequiredService<DeckForm>();
            deckForm.SetDeckName(btnSender.Text);
            deckForm.Show();
            deckForm.Disposed += DeckIsClosed;
        }

        private void DeckIsClosed(object? sender, EventArgs e)
        {
            ReloadDecks();
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
