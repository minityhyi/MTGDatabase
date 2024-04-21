using Microsoft.Extensions.DependencyInjection;
using MTG.Common.DomainModels;
using MTG.Common.Repository.Interfaces;

namespace MTGApplication
{
    public partial class Oversigt : Form
    {
        private readonly IDeckRepository deckRepository;
        private readonly IServiceProvider serviceProvider;
        public List<Control> controlsAdded { get; set; }
        public Oversigt(IDeckRepository deckRepository, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.deckRepository = deckRepository;
            this.serviceProvider = serviceProvider;
            controlsAdded = new List<Control>();
        }

        private void showDeckBtn_Click(object sender, EventArgs e)
        {
            ReloadDecks();
        }

        private void ReloadDecks()
        {
            foreach (var control in Controls.OfType<Button>().Where(b => b.Name == "deckButton"))
            {
                Controls.Remove(control);
                control.Hide();
                control.Dispose();
            }

            allDecksLabel.Text = "Getting the decks...";
            var allDecks = deckRepository.GetAllDecks();
            allDecksLabel.Text = "Here you go.";

            for (var i = 0; i < allDecks.Count; i++)
            {
                var tmpButton = new Button();

                tmpButton.Size = new Size(150, 50);
                tmpButton.Location = new Point(showDeckBtn.Location.X,
                    showDeckBtn.Location.Y + (i * 10) + showDeckBtn.Size.Height + (i * tmpButton.Size.Height));
                tmpButton.Text = allDecks[i];
                tmpButton.Click += DeckClick;
                tmpButton.Name = "deckButton";
                tmpButton.Show();
                Controls.Add(tmpButton);
            }

            allDecksLabel.Text = "Decks are loaded now.";
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
}
