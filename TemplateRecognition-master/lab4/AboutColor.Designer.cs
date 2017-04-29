namespace lab4
{
    partial class AboutColor
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
            this.rchbAboutColor = new System.Windows.Forms.RichTextBox();
            this.btOk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rchbAboutColor
            // 
            this.rchbAboutColor.Location = new System.Drawing.Point(25, 21);
            this.rchbAboutColor.Name = "rchbAboutColor";
            this.rchbAboutColor.Size = new System.Drawing.Size(738, 302);
            this.rchbAboutColor.TabIndex = 0;
            this.rchbAboutColor.Text = "";
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(306, 329);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(166, 58);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "Ок";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Подробнее";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AboutColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 399);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.rchbAboutColor);
            this.Name = "AboutColor";
            this.Text = "AboutColor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchbAboutColor;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button button1;
    }
}