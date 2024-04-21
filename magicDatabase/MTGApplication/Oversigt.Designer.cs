namespace MTGApplication
{
    partial class Oversigt
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            showDeckBtn = new Button();
            allDecksLabel = new Label();
            AddBtn = new Button();
            DeckNameText = new TextBox();
            DeckPanel = new Panel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            SuspendLayout();
            // 
            // showDeckBtn
            // 
            showDeckBtn.Location = new Point(30, 24);
            showDeckBtn.Name = "showDeckBtn";
            showDeckBtn.Size = new Size(146, 37);
            showDeckBtn.TabIndex = 0;
            showDeckBtn.Text = "Show Decs";
            showDeckBtn.UseVisualStyleBackColor = true;
            showDeckBtn.Click += showDeckBtn_Click;
            // 
            // allDecksLabel
            // 
            allDecksLabel.AutoSize = true;
            allDecksLabel.Location = new Point(502, 394);
            allDecksLabel.Name = "allDecksLabel";
            allDecksLabel.Size = new Size(16, 15);
            allDecksLabel.TabIndex = 1;
            allDecksLabel.Text = "...";
            // 
            // AddBtn
            // 
            AddBtn.Location = new Point(182, 24);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(85, 37);
            AddBtn.TabIndex = 2;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = true;
            AddBtn.Click += AddBtn_Click;
            // 
            // DeckNameText
            // 
            DeckNameText.Location = new Point(273, 32);
            DeckNameText.Name = "DeckNameText";
            DeckNameText.Size = new Size(126, 23);
            DeckNameText.TabIndex = 3;
            DeckNameText.Text = "Write deck name";
            // 
            // DeckPanel
            // 
            DeckPanel.Location = new Point(30, 67);
            DeckPanel.Name = "DeckPanel";
            DeckPanel.Size = new Size(369, 342);
            DeckPanel.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Oversigt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DeckPanel);
            Controls.Add(DeckNameText);
            Controls.Add(AddBtn);
            Controls.Add(allDecksLabel);
            Controls.Add(showDeckBtn);
            Name = "Oversigt";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button showDeckBtn;
        private Label allDecksLabel;
        private Button AddBtn;
        private TextBox DeckNameText;
        private Panel DeckPanel;
        private ContextMenuStrip contextMenuStrip1;
    }
}
