namespace MovieRecommendationSystem
{
    partial class SetPriority
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
            this.listBoxOriginal = new System.Windows.Forms.ListBox();
            this.listBoxSelected = new System.Windows.Forms.ListBox();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.buttonMove = new System.Windows.Forms.Button();
            this.buttonMoveAll = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.buttonMoveBack = new System.Windows.Forms.Button();
            this.buttonMoveBackAll = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelSelected = new System.Windows.Forms.Label();
            this.labelOriginal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxOriginal
            // 
            this.listBoxOriginal.FormattingEnabled = true;
            this.listBoxOriginal.Location = new System.Drawing.Point(18, 95);
            this.listBoxOriginal.Name = "listBoxOriginal";
            this.listBoxOriginal.Size = new System.Drawing.Size(236, 264);
            this.listBoxOriginal.TabIndex = 0;
            // 
            // listBoxSelected
            // 
            this.listBoxSelected.FormattingEnabled = true;
            this.listBoxSelected.Location = new System.Drawing.Point(366, 95);
            this.listBoxSelected.Name = "listBoxSelected";
            this.listBoxSelected.Size = new System.Drawing.Size(236, 264);
            this.listBoxSelected.TabIndex = 0;
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Location = new System.Drawing.Point(15, 30);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(399, 26);
            this.labelQuestion.TabIndex = 1;
            this.labelQuestion.Text = "Select the features of the movies, that are important for you from the box on the" +
    " left,\r\n and put them in order by priority in the box on the right!";
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(269, 181);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(75, 23);
            this.buttonMove.TabIndex = 2;
            this.buttonMove.Text = ">";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonMoveAll
            // 
            this.buttonMoveAll.Location = new System.Drawing.Point(269, 210);
            this.buttonMoveAll.Name = "buttonMoveAll";
            this.buttonMoveAll.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveAll.TabIndex = 3;
            this.buttonMoveAll.Text = ">>";
            this.buttonMoveAll.UseVisualStyleBackColor = true;
            this.buttonMoveAll.Click += new System.EventHandler(this.buttonMoveAll_Click);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Location = new System.Drawing.Point(269, 152);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveUp.TabIndex = 4;
            this.buttonMoveUp.Text = "Move Up";
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Location = new System.Drawing.Point(269, 299);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveDown.TabIndex = 5;
            this.buttonMoveDown.Text = "Move Down";
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // buttonMoveBack
            // 
            this.buttonMoveBack.Location = new System.Drawing.Point(269, 239);
            this.buttonMoveBack.Name = "buttonMoveBack";
            this.buttonMoveBack.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveBack.TabIndex = 6;
            this.buttonMoveBack.Text = "<";
            this.buttonMoveBack.UseVisualStyleBackColor = true;
            this.buttonMoveBack.Click += new System.EventHandler(this.buttonMoveBack_Click);
            // 
            // buttonMoveBackAll
            // 
            this.buttonMoveBackAll.Location = new System.Drawing.Point(269, 268);
            this.buttonMoveBackAll.Name = "buttonMoveBackAll";
            this.buttonMoveBackAll.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveBackAll.TabIndex = 7;
            this.buttonMoveBackAll.Text = "<<";
            this.buttonMoveBackAll.UseVisualStyleBackColor = true;
            this.buttonMoveBackAll.Click += new System.EventHandler(this.buttonMoveBackAll_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(527, 383);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 8;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // labelSelected
            // 
            this.labelSelected.AutoSize = true;
            this.labelSelected.Location = new System.Drawing.Point(363, 79);
            this.labelSelected.Name = "labelSelected";
            this.labelSelected.Size = new System.Drawing.Size(148, 13);
            this.labelSelected.TabIndex = 9;
            this.labelSelected.Text = "Choosed properties by priority:\r\n";
            // 
            // labelOriginal
            // 
            this.labelOriginal.AutoSize = true;
            this.labelOriginal.Location = new System.Drawing.Point(15, 79);
            this.labelOriginal.Name = "labelOriginal";
            this.labelOriginal.Size = new System.Drawing.Size(109, 13);
            this.labelOriginal.TabIndex = 10;
            this.labelOriginal.Text = "Choosable properties:\r\n";
            // 
            // SetPriority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelOriginal);
            this.Controls.Add(this.labelSelected);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonMoveBackAll);
            this.Controls.Add(this.buttonMoveBack);
            this.Controls.Add(this.buttonMoveDown);
            this.Controls.Add(this.buttonMoveUp);
            this.Controls.Add(this.buttonMoveAll);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.listBoxSelected);
            this.Controls.Add(this.listBoxOriginal);
            this.Name = "SetPriority";
            this.Size = new System.Drawing.Size(634, 430);
            this.Load += new System.EventHandler(this.SetPriority_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.ListBox listBoxOriginal;
        private System.Windows.Forms.ListBox listBoxSelected;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Button buttonMoveAll;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.Button buttonMoveBack;
        private System.Windows.Forms.Button buttonMoveBackAll;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelSelected;
        private System.Windows.Forms.Label labelOriginal;
    }
}