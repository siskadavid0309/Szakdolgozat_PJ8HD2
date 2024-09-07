namespace MovieRecommendationSystem
{
    partial class ManageMovie
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
            this.labelQuestion = new System.Windows.Forms.Label();
            this.cboxTitle = new System.Windows.Forms.ComboBox();
            this.textBoxGenre = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxKeywords = new System.Windows.Forms.TextBox();
            this.textBoxMainActor = new System.Windows.Forms.TextBox();
            this.textBoxGenderOfTheProtagonist = new System.Windows.Forms.TextBox();
            this.textBoxRuntime = new System.Windows.Forms.TextBox();
            this.textBoxReleased = new System.Windows.Forms.TextBox();
            this.textBoxCountries = new System.Windows.Forms.TextBox();
            this.textBoxLanguage = new System.Windows.Forms.TextBox();
            this.textBoxDirector = new System.Windows.Forms.TextBox();
            this.textBoxBudget = new System.Windows.Forms.TextBox();
            this.textBoxPopularity = new System.Windows.Forms.TextBox();
            this.textBoxNumberOfRatings = new System.Windows.Forms.TextBox();
            this.textBoxTmdbScore = new System.Windows.Forms.TextBox();
            this.textBoxRevenue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.buttonModify = new System.Windows.Forms.Button();
            this.labelGenreHint = new System.Windows.Forms.Label();
            this.labelGenderOfProtagonistHint = new System.Windows.Forms.Label();
            this.labelKeywordHint = new System.Windows.Forms.Label();
            this.labelDirectorHint = new System.Windows.Forms.Label();
            this.labelLanguageHint = new System.Windows.Forms.Label();
            this.labelCountriesHint = new System.Windows.Forms.Label();
            this.labelTmdbHint = new System.Windows.Forms.Label();
            this.labelPopularityHint = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAddNew = new System.Windows.Forms.Button();
            this.labelAddNew = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Location = new System.Drawing.Point(12, 12);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(187, 13);
            this.labelQuestion.TabIndex = 1;
            this.labelQuestion.Text = "Which movie do you want to change?";
            // 
            // cboxTitle
            // 
            this.cboxTitle.FormattingEnabled = true;
            this.cboxTitle.Location = new System.Drawing.Point(217, 12);
            this.cboxTitle.Name = "cboxTitle";
            this.cboxTitle.Size = new System.Drawing.Size(121, 21);
            this.cboxTitle.TabIndex = 2;
            this.cboxTitle.SelectedIndexChanged += new System.EventHandler(this.cboxTitle_SelectedIndexChanged);
            // 
            // textBoxGenre
            // 
            this.textBoxGenre.Location = new System.Drawing.Point(174, 69);
            this.textBoxGenre.Name = "textBoxGenre";
            this.textBoxGenre.Size = new System.Drawing.Size(530, 20);
            this.textBoxGenre.TabIndex = 3;
            this.textBoxGenre.MouseEnter += new System.EventHandler(this.textBoxGenre_MouseEnter);
            this.textBoxGenre.MouseLeave += new System.EventHandler(this.textBoxGenre_MouseLeave);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(174, 43);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(530, 20);
            this.textBoxTitle.TabIndex = 4;
            // 
            // textBoxKeywords
            // 
            this.textBoxKeywords.Location = new System.Drawing.Point(174, 199);
            this.textBoxKeywords.Name = "textBoxKeywords";
            this.textBoxKeywords.Size = new System.Drawing.Size(530, 20);
            this.textBoxKeywords.TabIndex = 5;
            this.textBoxKeywords.MouseEnter += new System.EventHandler(this.textBoxKeywords_MouseEnter);
            this.textBoxKeywords.MouseLeave += new System.EventHandler(this.textBoxKeywords_MouseLeave);
            // 
            // textBoxMainActor
            // 
            this.textBoxMainActor.Location = new System.Drawing.Point(174, 173);
            this.textBoxMainActor.Name = "textBoxMainActor";
            this.textBoxMainActor.Size = new System.Drawing.Size(530, 20);
            this.textBoxMainActor.TabIndex = 6;
            // 
            // textBoxGenderOfTheProtagonist
            // 
            this.textBoxGenderOfTheProtagonist.Location = new System.Drawing.Point(174, 147);
            this.textBoxGenderOfTheProtagonist.Name = "textBoxGenderOfTheProtagonist";
            this.textBoxGenderOfTheProtagonist.Size = new System.Drawing.Size(530, 20);
            this.textBoxGenderOfTheProtagonist.TabIndex = 7;
            this.textBoxGenderOfTheProtagonist.MouseEnter += new System.EventHandler(this.textBoxGenderOfTheProtagonist_MouseEnter);
            this.textBoxGenderOfTheProtagonist.MouseLeave += new System.EventHandler(this.textBoxGenderOfTheProtagonist_MouseLeave);
            // 
            // textBoxRuntime
            // 
            this.textBoxRuntime.Location = new System.Drawing.Point(174, 121);
            this.textBoxRuntime.Name = "textBoxRuntime";
            this.textBoxRuntime.Size = new System.Drawing.Size(530, 20);
            this.textBoxRuntime.TabIndex = 8;
            // 
            // textBoxReleased
            // 
            this.textBoxReleased.Location = new System.Drawing.Point(174, 95);
            this.textBoxReleased.Name = "textBoxReleased";
            this.textBoxReleased.Size = new System.Drawing.Size(530, 20);
            this.textBoxReleased.TabIndex = 9;
            // 
            // textBoxCountries
            // 
            this.textBoxCountries.Location = new System.Drawing.Point(174, 277);
            this.textBoxCountries.Name = "textBoxCountries";
            this.textBoxCountries.Size = new System.Drawing.Size(530, 20);
            this.textBoxCountries.TabIndex = 10;
            this.textBoxCountries.MouseEnter += new System.EventHandler(this.textBoxCountries_MouseEnter);
            this.textBoxCountries.MouseLeave += new System.EventHandler(this.textBoxCountries_MouseLeave);
            // 
            // textBoxLanguage
            // 
            this.textBoxLanguage.Location = new System.Drawing.Point(174, 251);
            this.textBoxLanguage.Name = "textBoxLanguage";
            this.textBoxLanguage.Size = new System.Drawing.Size(530, 20);
            this.textBoxLanguage.TabIndex = 11;
            this.textBoxLanguage.MouseEnter += new System.EventHandler(this.textBoxLanguage_MouseEnter);
            this.textBoxLanguage.MouseLeave += new System.EventHandler(this.textBoxLanguage_MouseLeave);
            // 
            // textBoxDirector
            // 
            this.textBoxDirector.Location = new System.Drawing.Point(174, 225);
            this.textBoxDirector.Name = "textBoxDirector";
            this.textBoxDirector.Size = new System.Drawing.Size(530, 20);
            this.textBoxDirector.TabIndex = 12;
            this.textBoxDirector.MouseEnter += new System.EventHandler(this.textBoxDirector_MouseEnter);
            this.textBoxDirector.MouseLeave += new System.EventHandler(this.textBoxDirector_MouseLeave);
            // 
            // textBoxBudget
            // 
            this.textBoxBudget.Location = new System.Drawing.Point(174, 381);
            this.textBoxBudget.Name = "textBoxBudget";
            this.textBoxBudget.Size = new System.Drawing.Size(530, 20);
            this.textBoxBudget.TabIndex = 13;
            // 
            // textBoxPopularity
            // 
            this.textBoxPopularity.Location = new System.Drawing.Point(174, 355);
            this.textBoxPopularity.Name = "textBoxPopularity";
            this.textBoxPopularity.Size = new System.Drawing.Size(530, 20);
            this.textBoxPopularity.TabIndex = 14;
            this.textBoxPopularity.MouseEnter += new System.EventHandler(this.textBoxPopularity_MouseEnter);
            this.textBoxPopularity.MouseLeave += new System.EventHandler(this.textBoxPopularity_MouseLeave);
            // 
            // textBoxNumberOfRatings
            // 
            this.textBoxNumberOfRatings.Location = new System.Drawing.Point(174, 329);
            this.textBoxNumberOfRatings.Name = "textBoxNumberOfRatings";
            this.textBoxNumberOfRatings.Size = new System.Drawing.Size(530, 20);
            this.textBoxNumberOfRatings.TabIndex = 15;
            // 
            // textBoxTmdbScore
            // 
            this.textBoxTmdbScore.Location = new System.Drawing.Point(174, 303);
            this.textBoxTmdbScore.Name = "textBoxTmdbScore";
            this.textBoxTmdbScore.Size = new System.Drawing.Size(530, 20);
            this.textBoxTmdbScore.TabIndex = 16;
            this.textBoxTmdbScore.MouseEnter += new System.EventHandler(this.textBoxTmdb_MouseEnter);
            this.textBoxTmdbScore.MouseLeave += new System.EventHandler(this.textBoxTmdb_MouseLeave);
            // 
            // textBoxRevenue
            // 
            this.textBoxRevenue.Location = new System.Drawing.Point(174, 407);
            this.textBoxRevenue.Name = "textBoxRevenue";
            this.textBoxRevenue.Size = new System.Drawing.Size(530, 20);
            this.textBoxRevenue.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Title:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Director:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Keywords:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Main Actor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Gender of the protagonist:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Runtime:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(113, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Released:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(129, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Genre:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(113, 410);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Revenue:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(122, 384);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Budget:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(110, 358);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Popularity:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(73, 332);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "Number of ratings:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(100, 306);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "Tmdb score:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(61, 280);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 13);
            this.label18.TabIndex = 34;
            this.label18.Text = "Production countries:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(105, 254);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 35;
            this.label19.Text = "Language:";
            // 
            // buttonModify
            // 
            this.buttonModify.Location = new System.Drawing.Point(664, 447);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(75, 23);
            this.buttonModify.TabIndex = 36;
            this.buttonModify.Text = "Modify";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // labelGenreHint
            // 
            this.labelGenreHint.AutoSize = true;
            this.labelGenreHint.BackColor = System.Drawing.SystemColors.Info;
            this.labelGenreHint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelGenreHint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelGenreHint.Location = new System.Drawing.Point(252, 51);
            this.labelGenreHint.Name = "labelGenreHint";
            this.labelGenreHint.Size = new System.Drawing.Size(221, 15);
            this.labelGenreHint.TabIndex = 37;
            this.labelGenreHint.Text = "Use commas and spaces between the words";
            this.labelGenreHint.Visible = false;
            // 
            // labelGenderOfProtagonistHint
            // 
            this.labelGenderOfProtagonistHint.AutoSize = true;
            this.labelGenderOfProtagonistHint.BackColor = System.Drawing.SystemColors.Info;
            this.labelGenderOfProtagonistHint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelGenderOfProtagonistHint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelGenderOfProtagonistHint.Location = new System.Drawing.Point(252, 129);
            this.labelGenderOfProtagonistHint.Name = "labelGenderOfProtagonistHint";
            this.labelGenderOfProtagonistHint.Size = new System.Drawing.Size(107, 15);
            this.labelGenderOfProtagonistHint.TabIndex = 38;
            this.labelGenderOfProtagonistHint.Text = "1 (male) or 2 (female)";
            this.labelGenderOfProtagonistHint.Visible = false;
            // 
            // labelKeywordHint
            // 
            this.labelKeywordHint.AutoSize = true;
            this.labelKeywordHint.BackColor = System.Drawing.SystemColors.Info;
            this.labelKeywordHint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelKeywordHint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelKeywordHint.Location = new System.Drawing.Point(252, 181);
            this.labelKeywordHint.Name = "labelKeywordHint";
            this.labelKeywordHint.Size = new System.Drawing.Size(221, 15);
            this.labelKeywordHint.TabIndex = 39;
            this.labelKeywordHint.Text = "Use commas and spaces between the words";
            this.labelKeywordHint.Visible = false;
            // 
            // labelDirectorHint
            // 
            this.labelDirectorHint.AutoSize = true;
            this.labelDirectorHint.BackColor = System.Drawing.SystemColors.Info;
            this.labelDirectorHint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDirectorHint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelDirectorHint.Location = new System.Drawing.Point(252, 207);
            this.labelDirectorHint.Name = "labelDirectorHint";
            this.labelDirectorHint.Size = new System.Drawing.Size(221, 15);
            this.labelDirectorHint.TabIndex = 40;
            this.labelDirectorHint.Text = "Use commas and spaces between the words";
            this.labelDirectorHint.Visible = false;
            // 
            // labelLanguageHint
            // 
            this.labelLanguageHint.AutoSize = true;
            this.labelLanguageHint.BackColor = System.Drawing.SystemColors.Info;
            this.labelLanguageHint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLanguageHint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelLanguageHint.Location = new System.Drawing.Point(252, 233);
            this.labelLanguageHint.Name = "labelLanguageHint";
            this.labelLanguageHint.Size = new System.Drawing.Size(221, 15);
            this.labelLanguageHint.TabIndex = 41;
            this.labelLanguageHint.Text = "Use commas and spaces between the words";
            this.labelLanguageHint.Visible = false;
            // 
            // labelCountriesHint
            // 
            this.labelCountriesHint.AutoSize = true;
            this.labelCountriesHint.BackColor = System.Drawing.SystemColors.Info;
            this.labelCountriesHint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCountriesHint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelCountriesHint.Location = new System.Drawing.Point(252, 259);
            this.labelCountriesHint.Name = "labelCountriesHint";
            this.labelCountriesHint.Size = new System.Drawing.Size(221, 15);
            this.labelCountriesHint.TabIndex = 42;
            this.labelCountriesHint.Text = "Use commas and spaces between the words";
            this.labelCountriesHint.Visible = false;
            // 
            // labelTmdbHint
            // 
            this.labelTmdbHint.AutoSize = true;
            this.labelTmdbHint.BackColor = System.Drawing.SystemColors.Info;
            this.labelTmdbHint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTmdbHint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelTmdbHint.Location = new System.Drawing.Point(252, 285);
            this.labelTmdbHint.Name = "labelTmdbHint";
            this.labelTmdbHint.Size = new System.Drawing.Size(92, 15);
            this.labelTmdbHint.TabIndex = 43;
            this.labelTmdbHint.Text = "Use only commas";
            this.labelTmdbHint.Visible = false;
            // 
            // labelPopularityHint
            // 
            this.labelPopularityHint.AutoSize = true;
            this.labelPopularityHint.BackColor = System.Drawing.SystemColors.Info;
            this.labelPopularityHint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPopularityHint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelPopularityHint.Location = new System.Drawing.Point(252, 337);
            this.labelPopularityHint.Name = "labelPopularityHint";
            this.labelPopularityHint.Size = new System.Drawing.Size(92, 15);
            this.labelPopularityHint.TabIndex = 44;
            this.labelPopularityHint.Text = "Use only commas";
            this.labelPopularityHint.Visible = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(664, 447);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 45;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Visible = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(64, 447);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 46;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAddNew
            // 
            this.buttonAddNew.Location = new System.Drawing.Point(357, 10);
            this.buttonAddNew.Name = "buttonAddNew";
            this.buttonAddNew.Size = new System.Drawing.Size(75, 23);
            this.buttonAddNew.TabIndex = 47;
            this.buttonAddNew.Text = "Add new";
            this.buttonAddNew.UseVisualStyleBackColor = true;
            this.buttonAddNew.Click += new System.EventHandler(this.buttonAddNew_Click);
            // 
            // labelAddNew
            // 
            this.labelAddNew.AutoSize = true;
            this.labelAddNew.Location = new System.Drawing.Point(12, 12);
            this.labelAddNew.Name = "labelAddNew";
            this.labelAddNew.Size = new System.Drawing.Size(92, 13);
            this.labelAddNew.TabIndex = 48;
            this.labelAddNew.Text = "Add a new movie:";
            this.labelAddNew.Visible = false;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(64, 447);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 49;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Visible = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // ManageMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 482);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.labelAddNew);
            this.Controls.Add(this.buttonAddNew);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelPopularityHint);
            this.Controls.Add(this.labelTmdbHint);
            this.Controls.Add(this.labelCountriesHint);
            this.Controls.Add(this.labelLanguageHint);
            this.Controls.Add(this.labelDirectorHint);
            this.Controls.Add(this.labelKeywordHint);
            this.Controls.Add(this.labelGenderOfProtagonistHint);
            this.Controls.Add(this.labelGenreHint);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRevenue);
            this.Controls.Add(this.textBoxTmdbScore);
            this.Controls.Add(this.textBoxNumberOfRatings);
            this.Controls.Add(this.textBoxPopularity);
            this.Controls.Add(this.textBoxBudget);
            this.Controls.Add(this.textBoxDirector);
            this.Controls.Add(this.textBoxLanguage);
            this.Controls.Add(this.textBoxCountries);
            this.Controls.Add(this.textBoxReleased);
            this.Controls.Add(this.textBoxRuntime);
            this.Controls.Add(this.textBoxGenderOfTheProtagonist);
            this.Controls.Add(this.textBoxMainActor);
            this.Controls.Add(this.textBoxKeywords);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.textBoxGenre);
            this.Controls.Add(this.cboxTitle);
            this.Controls.Add(this.labelQuestion);
            this.Name = "ManageMovie";
            this.Text = "ManageMovie";
            this.Load += new System.EventHandler(this.ManageMovie_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.ComboBox cboxTitle;
        private System.Windows.Forms.TextBox textBoxGenre;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxKeywords;
        private System.Windows.Forms.TextBox textBoxMainActor;
        private System.Windows.Forms.TextBox textBoxGenderOfTheProtagonist;
        private System.Windows.Forms.TextBox textBoxRuntime;
        private System.Windows.Forms.TextBox textBoxReleased;
        private System.Windows.Forms.TextBox textBoxCountries;
        private System.Windows.Forms.TextBox textBoxLanguage;
        private System.Windows.Forms.TextBox textBoxDirector;
        private System.Windows.Forms.TextBox textBoxBudget;
        private System.Windows.Forms.TextBox textBoxPopularity;
        private System.Windows.Forms.TextBox textBoxNumberOfRatings;
        private System.Windows.Forms.TextBox textBoxTmdbScore;
        private System.Windows.Forms.TextBox textBoxRevenue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Label labelGenreHint;
        private System.Windows.Forms.Label labelGenderOfProtagonistHint;
        private System.Windows.Forms.Label labelKeywordHint;
        private System.Windows.Forms.Label labelDirectorHint;
        private System.Windows.Forms.Label labelLanguageHint;
        private System.Windows.Forms.Label labelCountriesHint;
        private System.Windows.Forms.Label labelTmdbHint;
        private System.Windows.Forms.Label labelPopularityHint;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAddNew;
        private System.Windows.Forms.Label labelAddNew;
        private System.Windows.Forms.Button buttonBack;
    }
}