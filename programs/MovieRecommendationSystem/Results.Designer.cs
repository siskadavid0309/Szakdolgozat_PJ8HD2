namespace MovieRecommendationSystem
{
    partial class Results
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxMovie1 = new System.Windows.Forms.TextBox();
            this.textBoxMovie3 = new System.Windows.Forms.TextBox();
            this.textBoxMovie2 = new System.Windows.Forms.TextBox();
            this.textBoxMovie4 = new System.Windows.Forms.TextBox();
            this.textBoxMovie5 = new System.Windows.Forms.TextBox();
            this.labelRecommendedMovies = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxMovie1
            // 
            this.textBoxMovie1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxMovie1.Location = new System.Drawing.Point(143, 121);
            this.textBoxMovie1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMovie1.Name = "textBoxMovie1";
            this.textBoxMovie1.ReadOnly = true;
            this.textBoxMovie1.Size = new System.Drawing.Size(276, 20);
            this.textBoxMovie1.TabIndex = 0;
            // 
            // textBoxMovie3
            // 
            this.textBoxMovie3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxMovie3.Location = new System.Drawing.Point(143, 194);
            this.textBoxMovie3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMovie3.Name = "textBoxMovie3";
            this.textBoxMovie3.ReadOnly = true;
            this.textBoxMovie3.Size = new System.Drawing.Size(276, 20);
            this.textBoxMovie3.TabIndex = 1;
            // 
            // textBoxMovie2
            // 
            this.textBoxMovie2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxMovie2.Location = new System.Drawing.Point(143, 155);
            this.textBoxMovie2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMovie2.Name = "textBoxMovie2";
            this.textBoxMovie2.ReadOnly = true;
            this.textBoxMovie2.Size = new System.Drawing.Size(276, 20);
            this.textBoxMovie2.TabIndex = 2;
            // 
            // textBoxMovie4
            // 
            this.textBoxMovie4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxMovie4.Location = new System.Drawing.Point(143, 233);
            this.textBoxMovie4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMovie4.Name = "textBoxMovie4";
            this.textBoxMovie4.ReadOnly = true;
            this.textBoxMovie4.Size = new System.Drawing.Size(276, 20);
            this.textBoxMovie4.TabIndex = 3;
            // 
            // textBoxMovie5
            // 
            this.textBoxMovie5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxMovie5.Location = new System.Drawing.Point(143, 273);
            this.textBoxMovie5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMovie5.Name = "textBoxMovie5";
            this.textBoxMovie5.ReadOnly = true;
            this.textBoxMovie5.Size = new System.Drawing.Size(276, 20);
            this.textBoxMovie5.TabIndex = 4;
            // 
            // labelRecommendedMovies
            // 
            this.labelRecommendedMovies.AutoSize = true;
            this.labelRecommendedMovies.Location = new System.Drawing.Point(44, 80);
            this.labelRecommendedMovies.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRecommendedMovies.Name = "labelRecommendedMovies";
            this.labelRecommendedMovies.Size = new System.Drawing.Size(118, 13);
            this.labelRecommendedMovies.TabIndex = 5;
            this.labelRecommendedMovies.Text = "Recommended movies:";
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelRecommendedMovies);
            this.Controls.Add(this.textBoxMovie5);
            this.Controls.Add(this.textBoxMovie4);
            this.Controls.Add(this.textBoxMovie2);
            this.Controls.Add(this.textBoxMovie3);
            this.Controls.Add(this.textBoxMovie1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Results";
            this.Size = new System.Drawing.Size(590, 383);
            this.Load += new System.EventHandler(this.Results_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMovie1;
        private System.Windows.Forms.TextBox textBoxMovie3;
        private System.Windows.Forms.TextBox textBoxMovie2;
        private System.Windows.Forms.TextBox textBoxMovie4;
        private System.Windows.Forms.TextBox textBoxMovie5;
        private System.Windows.Forms.Label labelRecommendedMovies;
    }
}
