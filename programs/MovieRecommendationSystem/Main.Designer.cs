namespace MovieRecommendationSystem
{
    partial class Main
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
            this.ShowTable = new System.Windows.Forms.Button();
            this.ChangeDB = new System.Windows.Forms.Button();
            this.ManageMoviesButton = new System.Windows.Forms.Button();
            this.buttonRecommendationSystem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ShowTable
            // 
            this.ShowTable.Location = new System.Drawing.Point(37, 42);
            this.ShowTable.Name = "ShowTable";
            this.ShowTable.Size = new System.Drawing.Size(75, 23);
            this.ShowTable.TabIndex = 1;
            this.ShowTable.Text = "Table";
            this.ShowTable.UseVisualStyleBackColor = true;
            this.ShowTable.Click += new System.EventHandler(this.ShowTable_Click);
            // 
            // ChangeDB
            // 
            this.ChangeDB.Location = new System.Drawing.Point(37, 87);
            this.ChangeDB.Name = "ChangeDB";
            this.ChangeDB.Size = new System.Drawing.Size(112, 23);
            this.ChangeDB.TabIndex = 2;
            this.ChangeDB.Text = "Change database";
            this.ChangeDB.UseVisualStyleBackColor = true;
            this.ChangeDB.Click += new System.EventHandler(this.ChangeDB_Click);
            // 
            // ManageMoviesButton
            // 
            this.ManageMoviesButton.Location = new System.Drawing.Point(37, 132);
            this.ManageMoviesButton.Name = "ManageMoviesButton";
            this.ManageMoviesButton.Size = new System.Drawing.Size(112, 23);
            this.ManageMoviesButton.TabIndex = 3;
            this.ManageMoviesButton.Text = "Manage Movies";
            this.ManageMoviesButton.UseVisualStyleBackColor = true;
            this.ManageMoviesButton.Click += new System.EventHandler(this.ManageMoviesButton_Click);
            // 
            // buttonRecommendationSystem
            // 
            this.buttonRecommendationSystem.Location = new System.Drawing.Point(37, 171);
            this.buttonRecommendationSystem.Name = "buttonRecommendationSystem";
            this.buttonRecommendationSystem.Size = new System.Drawing.Size(100, 37);
            this.buttonRecommendationSystem.TabIndex = 4;
            this.buttonRecommendationSystem.Text = "Recommendation System";
            this.buttonRecommendationSystem.UseVisualStyleBackColor = true;
            this.buttonRecommendationSystem.Click += new System.EventHandler(this.buttonRecommendationSystem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 344);
            this.Controls.Add(this.buttonRecommendationSystem);
            this.Controls.Add(this.ManageMoviesButton);
            this.Controls.Add(this.ChangeDB);
            this.Controls.Add(this.ShowTable);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ShowTable;
        private System.Windows.Forms.Button ChangeDB;
        private System.Windows.Forms.Button ManageMoviesButton;
        private System.Windows.Forms.Button buttonRecommendationSystem;
    }
}

