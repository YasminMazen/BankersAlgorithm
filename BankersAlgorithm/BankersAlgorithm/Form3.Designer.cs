namespace BankersAlgorithm
{
    partial class Form3
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
            this.CheckSafeStateButton_Click = new System.Windows.Forms.Button();
            this.RequestResourcesButton_Click = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CheckSafeStateButton_Click
            // 
            this.CheckSafeStateButton_Click.BackColor = System.Drawing.Color.IndianRed;
            this.CheckSafeStateButton_Click.Location = new System.Drawing.Point(849, 57);
            this.CheckSafeStateButton_Click.Margin = new System.Windows.Forms.Padding(4);
            this.CheckSafeStateButton_Click.Name = "CheckSafeStateButton_Click";
            this.CheckSafeStateButton_Click.Size = new System.Drawing.Size(201, 75);
            this.CheckSafeStateButton_Click.TabIndex = 2;
            this.CheckSafeStateButton_Click.Text = "Safe state check";
            this.CheckSafeStateButton_Click.UseVisualStyleBackColor = false;
            this.CheckSafeStateButton_Click.Click += new System.EventHandler(this.CheckSafeStateButton_Click_Click);
            // 
            // RequestResourcesButton_Click
            // 
            this.RequestResourcesButton_Click.BackColor = System.Drawing.Color.IndianRed;
            this.RequestResourcesButton_Click.Location = new System.Drawing.Point(849, 164);
            this.RequestResourcesButton_Click.Margin = new System.Windows.Forms.Padding(4);
            this.RequestResourcesButton_Click.Name = "RequestResourcesButton_Click";
            this.RequestResourcesButton_Click.Size = new System.Drawing.Size(201, 75);
            this.RequestResourcesButton_Click.TabIndex = 4;
            this.RequestResourcesButton_Click.Text = "Request Resources";
            this.RequestResourcesButton_Click.UseVisualStyleBackColor = false;
            this.RequestResourcesButton_Click.Click += new System.EventHandler(this.RequestResourcesButton_Click_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 26);
            this.label2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 26);
            this.label3.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.IndianRed;
            this.button2.Location = new System.Drawing.Point(849, 275);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 75);
            this.button2.TabIndex = 8;
            this.button2.Text = "Show steps";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 675);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RequestResourcesButton_Click);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CheckSafeStateButton_Click);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Button CheckSafeStateButton_Click;
        private Label label2;
        private Button RequestResourcesButton_Click;
        private Label label3;
        private Button button2;
    }
}