namespace MTGApplication
{
    partial class DeckForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DeckNameLabel = new Label();
            deckNameTextbox = new TextBox();
            renameBtn = new Button();
            renameLabel = new Label();
            SuspendLayout();
            // 
            // DeckNameLabel
            // 
            DeckNameLabel.AutoSize = true;
            DeckNameLabel.Location = new Point(29, 9);
            DeckNameLabel.Name = "DeckNameLabel";
            DeckNameLabel.Size = new Size(68, 15);
            DeckNameLabel.TabIndex = 0;
            DeckNameLabel.Text = "Deck Name";
            // 
            // deckNameTextbox
            // 
            deckNameTextbox.Location = new Point(29, 27);
            deckNameTextbox.Name = "deckNameTextbox";
            deckNameTextbox.Size = new Size(151, 23);
            deckNameTextbox.TabIndex = 1;
            // 
            // renameBtn
            // 
            renameBtn.Location = new Point(186, 27);
            renameBtn.Name = "renameBtn";
            renameBtn.RightToLeft = RightToLeft.Yes;
            renameBtn.Size = new Size(75, 23);
            renameBtn.TabIndex = 2;
            renameBtn.Text = "Rename";
            renameBtn.UseVisualStyleBackColor = true;
            renameBtn.Click += renameBtn_Click;
            // 
            // renameLabel
            // 
            renameLabel.AutoSize = true;
            renameLabel.Location = new Point(263, 32);
            renameLabel.Name = "renameLabel";
            renameLabel.Size = new Size(0, 15);
            renameLabel.TabIndex = 3;
            // 
            // DeckForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(renameLabel);
            Controls.Add(renameBtn);
            Controls.Add(deckNameTextbox);
            Controls.Add(DeckNameLabel);
            Name = "DeckForm";
            Text = "DeckForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label DeckNameLabel;
        private TextBox deckNameTextbox;
        private Button renameBtn;
        private Label renameLabel;
    }
}