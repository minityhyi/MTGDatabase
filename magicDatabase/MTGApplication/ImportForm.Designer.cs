namespace MTGApplication
{
    partial class ImportForm
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
            ImportPathTextbox = new TextBox();
            label1 = new Label();
            ImportBtn = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // ImportPathTextbox
            // 
            ImportPathTextbox.Location = new Point(12, 27);
            ImportPathTextbox.Name = "ImportPathTextbox";
            ImportPathTextbox.Size = new Size(187, 23);
            ImportPathTextbox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 1;
            label1.Text = "Import Path:";
            // 
            // ImportBtn
            // 
            ImportBtn.Location = new Point(12, 56);
            ImportBtn.Name = "ImportBtn";
            ImportBtn.Size = new Size(269, 23);
            ImportBtn.TabIndex = 2;
            ImportBtn.Text = "Import";
            ImportBtn.UseVisualStyleBackColor = true;
            ImportBtn.Click += ImportBtn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(205, 27);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ImportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(293, 93);
            Controls.Add(button1);
            Controls.Add(ImportBtn);
            Controls.Add(label1);
            Controls.Add(ImportPathTextbox);
            Name = "ImportForm";
            Text = "Import";
            Load += ImportForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ImportPathTextbox;
        private Label label1;
        private Button ImportBtn;
        private Button button1;
    }
}