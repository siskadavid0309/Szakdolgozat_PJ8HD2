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
            this.buttonDecisionTree = new System.Windows.Forms.Button();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowTable
            // 
            this.ShowTable.Location = new System.Drawing.Point(26, 71);
            this.ShowTable.Margin = new System.Windows.Forms.Padding(4);
            this.ShowTable.Name = "ShowTable";
            this.ShowTable.Size = new System.Drawing.Size(100, 28);
            this.ShowTable.TabIndex = 1;
            this.ShowTable.Text = "Table";
            this.ShowTable.UseVisualStyleBackColor = true;
            this.ShowTable.Click += new System.EventHandler(this.ShowTable_Click);
            // 
            // ChangeDB
            // 
            this.ChangeDB.Location = new System.Drawing.Point(26, 126);
            this.ChangeDB.Margin = new System.Windows.Forms.Padding(4);
            this.ChangeDB.Name = "ChangeDB";
            this.ChangeDB.Size = new System.Drawing.Size(149, 28);
            this.ChangeDB.TabIndex = 2;
            this.ChangeDB.Text = "Change database";
            this.ChangeDB.UseVisualStyleBackColor = true;
            this.ChangeDB.Click += new System.EventHandler(this.ChangeDB_Click);
            // 
            // ManageMoviesButton
            // 
            this.ManageMoviesButton.Location = new System.Drawing.Point(26, 181);
            this.ManageMoviesButton.Margin = new System.Windows.Forms.Padding(4);
            this.ManageMoviesButton.Name = "ManageMoviesButton";
            this.ManageMoviesButton.Size = new System.Drawing.Size(149, 28);
            this.ManageMoviesButton.TabIndex = 3;
            this.ManageMoviesButton.Text = "Manage Movies";
            this.ManageMoviesButton.UseVisualStyleBackColor = true;
            this.ManageMoviesButton.Click += new System.EventHandler(this.ManageMoviesButton_Click);
            // 
            // buttonRecommendationSystem
            // 
            this.buttonRecommendationSystem.Location = new System.Drawing.Point(26, 229);
            this.buttonRecommendationSystem.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRecommendationSystem.Name = "buttonRecommendationSystem";
            this.buttonRecommendationSystem.Size = new System.Drawing.Size(133, 46);
            this.buttonRecommendationSystem.TabIndex = 4;
            this.buttonRecommendationSystem.Text = "Recommendation System";
            this.buttonRecommendationSystem.UseVisualStyleBackColor = true;
            this.buttonRecommendationSystem.Click += new System.EventHandler(this.buttonRecommendationSystem_Click);
            // 
            // buttonDecisionTree
            // 
            this.buttonDecisionTree.Location = new System.Drawing.Point(26, 291);
            this.buttonDecisionTree.Name = "buttonDecisionTree";
            this.buttonDecisionTree.Size = new System.Drawing.Size(133, 42);
            this.buttonDecisionTree.TabIndex = 5;
            this.buttonDecisionTree.Text = "Show me a decision tree";
            this.buttonDecisionTree.UseVisualStyleBackColor = true;
            this.buttonDecisionTree.Click += new System.EventHandler(this.buttonDecisionTree_Click);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Location = new System.Drawing.Point(195, 12);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(521, 399);
            this.pictureBoxMain.TabIndex = 6;
            this.pictureBoxMain.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 423);
            this.Controls.Add(this.pictureBoxMain);
            this.Controls.Add(this.buttonDecisionTree);
            this.Controls.Add(this.buttonRecommendationSystem);
            this.Controls.Add(this.ManageMoviesButton);
            this.Controls.Add(this.ChangeDB);
            this.Controls.Add(this.ShowTable);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Movie Recommendation System";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ShowTable;
        private System.Windows.Forms.Button ChangeDB;
        private System.Windows.Forms.Button ManageMoviesButton;
        private System.Windows.Forms.Button buttonRecommendationSystem;
        private System.Windows.Forms.Button buttonDecisionTree;
        private System.Windows.Forms.PictureBox pictureBoxMain;
    }
}

