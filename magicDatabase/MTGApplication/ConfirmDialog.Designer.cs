namespace MTGApplication
{
    partial class ConfirmDialog
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
            label1 = new Label();
            deckNameLabel = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(229, 15);
            label1.TabIndex = 0;
            label1.Text = "Are you sure you want to delete this deck?";
            // 
            // deckNameLabel
            // 
            deckNameLabel.AutoSize = true;
            deckNameLabel.Location = new Point(11, 36);
            deckNameLabel.Name = "deckNameLabel";
            deckNameLabel.Size = new Size(65, 15);
            deckNameLabel.TabIndex = 1;
            deckNameLabel.Text = "DeckName";
            // 
            // button1
            // 
            button1.Location = new Point(12, 74);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "No";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(198, 74);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Yes";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ConfirmDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(285, 119);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(deckNameLabel);
            Controls.Add(label1);
            Name = "ConfirmDialog";
            Text = "ConfirmDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label deckNameLabel;
        private Button button1;
        private Button button2;
    }
}