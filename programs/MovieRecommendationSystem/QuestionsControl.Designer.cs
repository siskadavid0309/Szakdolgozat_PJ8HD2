namespace MovieRecommendationSystem
{
    partial class QuestionsControl
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
            this.labelQuestion = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.trackBarMin = new System.Windows.Forms.TrackBar();
            this.textBoxTrackbarMin = new System.Windows.Forms.TextBox();
            this.trackBarMax = new System.Windows.Forms.TrackBar();
            this.textBoxTrackbarMax = new System.Windows.Forms.TextBox();
            this.buttonFinish = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelSliderMaxMin = new System.Windows.Forms.Label();
            this.labelSliderMaxMax = new System.Windows.Forms.Label();
            this.labelSliderMinMax = new System.Windows.Forms.Label();
            this.labelSliderMinMin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMax)).BeginInit();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Location = new System.Drawing.Point(59, 18);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(30, 13);
            this.labelQuestion.TabIndex = 0;
            this.labelQuestion.Text = "temp";
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(498, 385);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // checkedListBox
            // 
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(62, 89);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(391, 274);
            this.checkedListBox.TabIndex = 2;
            this.checkedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_ItemCheck);
            // 
            // trackBarMin
            // 
            this.trackBarMin.Location = new System.Drawing.Point(96, 131);
            this.trackBarMin.Name = "trackBarMin";
            this.trackBarMin.Size = new System.Drawing.Size(390, 45);
            this.trackBarMin.TabIndex = 3;
            this.trackBarMin.Visible = false;
            this.trackBarMin.ValueChanged += new System.EventHandler(this.trackBarMin_ValueChanged);
            // 
            // textBoxTrackbarMin
            // 
            this.textBoxTrackbarMin.Location = new System.Drawing.Point(197, 286);
            this.textBoxTrackbarMin.Name = "textBoxTrackbarMin";
            this.textBoxTrackbarMin.Size = new System.Drawing.Size(64, 20);
            this.textBoxTrackbarMin.TabIndex = 4;
            this.textBoxTrackbarMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTrackbarMin.Visible = false;
            this.textBoxTrackbarMin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTrackbarMin_KeyDown);
            this.textBoxTrackbarMin.Leave += new System.EventHandler(this.textBoxTrackbarMin_Leave);
            // 
            // trackBarMax
            // 
            this.trackBarMax.Location = new System.Drawing.Point(96, 210);
            this.trackBarMax.Name = "trackBarMax";
            this.trackBarMax.Size = new System.Drawing.Size(390, 45);
            this.trackBarMax.TabIndex = 5;
            this.trackBarMax.Value = 1;
            this.trackBarMax.Visible = false;
            this.trackBarMax.ValueChanged += new System.EventHandler(this.trackBarMax_ValueChanged);
            // 
            // textBoxTrackbarMax
            // 
            this.textBoxTrackbarMax.Location = new System.Drawing.Point(317, 286);
            this.textBoxTrackbarMax.Name = "textBoxTrackbarMax";
            this.textBoxTrackbarMax.Size = new System.Drawing.Size(64, 20);
            this.textBoxTrackbarMax.TabIndex = 6;
            this.textBoxTrackbarMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTrackbarMax.Visible = false;
            this.textBoxTrackbarMax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTrackbarMax_KeyDown);
            this.textBoxTrackbarMax.Leave += new System.EventHandler(this.textBoxTrackbarMax_Leave);
            // 
            // buttonFinish
            // 
            this.buttonFinish.Location = new System.Drawing.Point(498, 385);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(75, 23);
            this.buttonFinish.TabIndex = 7;
            this.buttonFinish.Text = "Finish";
            this.buttonFinish.UseVisualStyleBackColor = true;
            this.buttonFinish.Visible = false;
            this.buttonFinish.Click += new System.EventHandler(this.buttonFinish_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(96, 65);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(285, 20);
            this.textBoxSearch.TabIndex = 8;
            this.textBoxSearch.Visible = false;
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(48, 68);
            this.labelSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(44, 13);
            this.labelSearch.TabIndex = 9;
            this.labelSearch.Text = "Search:";
            this.labelSearch.Visible = false;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(396, 65);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(56, 19);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Visible = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelSliderMaxMin
            // 
            this.labelSliderMaxMin.AutoSize = true;
            this.labelSliderMaxMin.Location = new System.Drawing.Point(93, 258);
            this.labelSliderMaxMin.Name = "labelSliderMaxMin";
            this.labelSliderMaxMin.Size = new System.Drawing.Size(23, 13);
            this.labelSliderMaxMin.TabIndex = 11;
            this.labelSliderMaxMin.Text = "min";
            this.labelSliderMaxMin.Visible = false;
            // 
            // labelSliderMaxMax
            // 
            this.labelSliderMaxMax.AutoSize = true;
            this.labelSliderMaxMax.Location = new System.Drawing.Point(451, 258);
            this.labelSliderMaxMax.Name = "labelSliderMaxMax";
            this.labelSliderMaxMax.Size = new System.Drawing.Size(26, 13);
            this.labelSliderMaxMax.TabIndex = 12;
            this.labelSliderMaxMax.Text = "max";
            this.labelSliderMaxMax.Visible = false;
            // 
            // labelSliderMinMax
            // 
            this.labelSliderMinMax.AutoSize = true;
            this.labelSliderMinMax.Location = new System.Drawing.Point(451, 179);
            this.labelSliderMinMax.Name = "labelSliderMinMax";
            this.labelSliderMinMax.Size = new System.Drawing.Size(26, 13);
            this.labelSliderMinMax.TabIndex = 13;
            this.labelSliderMinMax.Text = "max";
            this.labelSliderMinMax.Visible = false;
            // 
            // labelSliderMinMin
            // 
            this.labelSliderMinMin.AutoSize = true;
            this.labelSliderMinMin.Location = new System.Drawing.Point(93, 179);
            this.labelSliderMinMin.Name = "labelSliderMinMin";
            this.labelSliderMinMin.Size = new System.Drawing.Size(23, 13);
            this.labelSliderMinMin.TabIndex = 14;
            this.labelSliderMinMin.Text = "min";
            this.labelSliderMinMin.Visible = false;
            // 
            // QuestionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSliderMinMin);
            this.Controls.Add(this.labelSliderMinMax);
            this.Controls.Add(this.labelSliderMaxMax);
            this.Controls.Add(this.labelSliderMaxMin);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonFinish);
            this.Controls.Add(this.textBoxTrackbarMax);
            this.Controls.Add(this.trackBarMax);
            this.Controls.Add(this.textBoxTrackbarMin);
            this.Controls.Add(this.trackBarMin);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.labelQuestion);
            this.Name = "QuestionsControl";
            this.Size = new System.Drawing.Size(634, 430);
            this.Load += new System.EventHandler(this.QuestionsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.TrackBar trackBarMin;
        private System.Windows.Forms.TextBox textBoxTrackbarMin;
        private System.Windows.Forms.TrackBar trackBarMax;
        private System.Windows.Forms.TextBox textBoxTrackbarMax;
        private System.Windows.Forms.Button buttonFinish;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelSliderMaxMin;
        private System.Windows.Forms.Label labelSliderMaxMax;
        private System.Windows.Forms.Label labelSliderMinMax;
        private System.Windows.Forms.Label labelSliderMinMin;
    }
}
