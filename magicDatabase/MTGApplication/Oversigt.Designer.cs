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
            showDeckBtn = new Button();
            allDecksLabel = new Label();
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
            allDecksLabel.Location = new Point(459, 46);
            allDecksLabel.Name = "allDecksLabel";
            allDecksLabel.Size = new Size(16, 15);
            allDecksLabel.TabIndex = 1;
            allDecksLabel.Text = "...";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(allDecksLabel);
            Controls.Add(showDeckBtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button showDeckBtn;
        private Label allDecksLabel;
    }
}
