using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableInsertsLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace MovieRecommendationSystem
{
    public partial class QuestionsControl : UserControl
    {
        private List<Question> questionsList = new List<Question>();
        private List<PriorityListItem> receivedPriorityList;
        private List<Movie> movies;
        private List<LearningMovie> learningMovies = new List<LearningMovie>();
        PropertiesForDecTree properties;
        FeaturesForCheckbox featuresForCheckbox = new FeaturesForCheckbox();
        private int currentIndex = 0;
        private List<string> selectedFromCheckbox = new List<string>();
        private bool range = true;
        private bool scale = false;
        private bool checkValueError = true;
        public event EventHandler FinishButtonClicked;
        private bool trueOrFalse = false;
        public QuestionsControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A kérdések összeállítása
        /// </summary>
        public void CreateQuestions()
        {

            Question temp = new Question
            {
                Title = "What is the lowest Tmdb score below which you will not watch a movie?\n\nPlease set the value with the slider, or write it into the box!",
                Type = (int)Features.TmdbScore
            };

            questionsList.Add(temp);

            temp = new Question
            {
                Title = "Which languages do you prefer in a movie?\n\nPlease select the languages with the checkboxes!",
                Type = (int)Features.Language
            };
            questionsList.Add(temp);

            temp = new Question
            {
                Title = "Does it important for you to be the movie a blockbuster?\n\nGive your answer by selecting the appropriate checkbox!",
                Type = (int)Features.Blockbuster
            };

            questionsList.Add(temp);

            temp = new Question
            {
                Title = "Do you prefer the female protagonists over the male protagonists?\n\nGive your answer by selecting the appropriate checkbox!",
                Type = (int)Features.GenderOfProtagonist
            };

            questionsList.Add(temp);

            temp = new Question
            {
                Title = "Do you have a favourite director from the list?\n\nIf you have, please select them with the checkboxes!",
                Type = (int)Features.Director
            };

            questionsList.Add(temp);

            temp = new Question
            {
                Title = "Do you have any things/objects that you like in a movie?\n\nIf you have, please select them with the checkboxes!",
                Type = (int)Features.Keyword
            };

            questionsList.Add(temp);

            temp = new Question
            {
                Title = "Do you have a favourite actress/actor from the list?\n\nIf you have, please select them with the checkboxes!",
                Type = (int)Features.MainActor
            };

            questionsList.Add(temp);

            temp = new Question
            {
                Title = "Which genres are your favourite?\n\nPlease select the genres with the checkboxes!",
                Type = (int)Features.Genre
            };

            questionsList.Add(temp);

            temp = new Question
            {
                Title = "Is that important for you to be the movie popular?\n\nGive your answer by selecting the appropriate checkbox!",
                Type = (int)Features.Popularity
            };

            questionsList.Add(temp);

            temp = new Question
            {
                Title = "What is the range of years you want to watch movies?\n\nPlease set the minimum and maximum values with the sliders, or write them into the boxes!",
                Type = (int)Features.Released
            };


            questionsList.Add(temp);

            temp = new Question
            {
                Title = "What's the range of playtime you want to watch a movie?\n\nPlease set the minimum and maximum values with the sliders, or write them into the boxes!",
                Type = (int)Features.Runtime
            };

            questionsList.Add(temp);


            temp = new Question
            {
                Title = "Which countries' movies do you like?\n\nPlease select the countries with the checkboxes!",
                Type = (int)Features.Country
            };

            questionsList.Add(temp);
        }

        /// <summary>
        /// A kérdések megjelenítése a beállított prioritási lista segítségével
        /// </summary>
        public void LoadQuestion()
        {

            for (int i = 0; i < questionsList.Count; i++)
            {
                if (receivedPriorityList[currentIndex].Id == questionsList[i].Type)
                {
                    labelQuestion.Text = questionsList[i].Title;
                }
            }
        }

        /// <summary>
        /// A véletlenszerű tanítóhalmaz kialakítása
        /// </summary>
        public void CreateLearningData()
        {
            Random rndm = new Random();
            int startIndex = rndm.Next(0, movies.Count - 30);
            int endIndex = startIndex + 30;
            for (int i = startIndex; i < endIndex; i++)
            {
                LearningMovie newMovie = new LearningMovie();

                newMovie.Genre = properties.GenreContains[i];
                newMovie.GenreString = movies[i].GenreString;
                FillupFeaturesForCheckbox(featuresForCheckbox.Genre, movies[i].GenreString);

                newMovie.Keyword = properties.KeywordContains[i];
                newMovie.KeywordString = movies[i].KeywordString;
                FillupFeaturesForCheckbox(featuresForCheckbox.Keyword, movies[i].KeywordString);

                newMovie.Released = movies[i].Released;

                newMovie.Runtime = movies[i].Runtime;

                newMovie.GenderOfProtagonist = movies[i].GenderOfProtagonist;

                newMovie.MainActor = movies[i].MainActor;
                FillupFeaturesForCheckbox(featuresForCheckbox.MainActor, movies[i].MainActor);

                newMovie.Director = properties.DirectorContains[i];
                newMovie.DirectorString = movies[i].DirectorString;
                FillupFeaturesForCheckbox(featuresForCheckbox.Director, movies[i].DirectorString);

                newMovie.Language = properties.LanguageContains[i];
                newMovie.LanguageString = movies[i].LanguageString;
                FillupFeaturesForCheckbox(featuresForCheckbox.Language, movies[i].LanguageString);

                newMovie.ProductionCountry = properties.CountryContains[i];
                newMovie.CountryString = movies[i].CountryString;
                FillupFeaturesForCheckbox(featuresForCheckbox.Country, movies[i].CountryString);

                newMovie.TmdbScore = movies[i].TmdbScore;

                newMovie.IsPopular = movies[i].IsPopular;

                newMovie.Blockbuster = movies[i].IsBlockbuster;

                learningMovies.Add(newMovie);
            }

            Console.WriteLine("StartIndex: " + startIndex);
            Console.WriteLine("EndIndex: " + endIndex);
        }

        public void FillupFeaturesForCheckbox(List<string> features, string movie)
        {
            if (!features.Contains(movie))
            {
                features.Add(movie);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="featureSelector"></param>
        /// <param name="score"></param>
        public void ModifyScoreForTrackbar(Func<LearningMovie, double> featureSelector, double score)
        {
            for (int i = 0; i < learningMovies.Count; i++)
            {

                if (featureSelector(learningMovies[i]) >= float.Parse(textBoxTrackbarMin.Text) && range == false)
                {
                    learningMovies[i].Score += score;
                }
                else if (featureSelector(learningMovies[i]) >= float.Parse(textBoxTrackbarMin.Text) && featureSelector(learningMovies[i]) <= float.Parse(textBoxTrackbarMax.Text) && range == true)
                {
                    learningMovies[i].Score += score;
                }
            }
        }
        /// <summary>
        /// A pontszámok frissítését végző metódus
        /// </summary>
        public void UpdateScore()
        {
            if (receivedPriorityList[currentIndex].Id == (int)Features.GenderOfProtagonist)
            {
                string temp = "";
                if (checkedListBox.CheckedItems[0].ToString().Contains("True"))
                {
                    temp = "1";
                }
                else
                {
                    temp = "2";
                }
                selectedFromCheckbox.Add(temp);
            }
            else
            {

                for (int i = 0; i < checkedListBox.CheckedItems.Count; i++)
                {
                    selectedFromCheckbox.Add(checkedListBox.CheckedItems[i].ToString());
                }
            }
            double score = (receivedPriorityList.Count - receivedPriorityList[currentIndex].Priority) * 0.1;

            switch (receivedPriorityList[currentIndex].Id)
            {

                case (int)Features.Genre:
                    ModifyScore(learningMovies => learningMovies.GenreString, score);
                    break;

                case (int)Features.Language:
                    ModifyScore(learningMovies => learningMovies.LanguageString, score);
                    break;

                case (int)Features.Blockbuster:
                    ModifyScoreForTrueOrFalse(learningMovies => learningMovies.Blockbuster, score);
                    break;
                case (int)Features.TmdbScore:
                    ModifyScoreForTrackbar(learningMovies => learningMovies.TmdbScore, score);
                    break;
                case (int)Features.Runtime:
                    ModifyScoreForTrackbar(learningMovies => learningMovies.Runtime, score);
                    break;
                case (int)Features.GenderOfProtagonist:
                    ModifyScoreForSingle(learningMovies => learningMovies.GenderOfProtagonist.ToString(), score);
                    break;
                case (int)Features.Released:
                    ModifyScoreForTrackbar(learningMovies => learningMovies.Released, score);
                    break;

                case (int)Features.Popularity:
                    ModifyScoreForTrueOrFalse(learningMovies => learningMovies.IsPopular, score);
                    break;
                case (int)Features.Keyword:
                    ModifyScore(learningMovies => learningMovies.KeywordString, score);
                    break;
                case (int)Features.Country:
                    ModifyScore(learningMovies => learningMovies.CountryString, score);
                    break;
                case (int)Features.Director:
                    ModifyScore(learningMovies => learningMovies.DirectorString, score);
                    break;
                case (int)Features.MainActor:
                    ModifyScoreForSingle(learningMovies => learningMovies.MainActor, score);
                    break;


            }
            selectedFromCheckbox.Clear();

            //kiíratás
            for (int i = 0; i < learningMovies.Count; i++)
            {

                for (int j = 0; j < learningMovies[i].GenreString.Count; j++)
                {
                    Console.Write(learningMovies[i].GenreString[j] + ", ");
                    Console.WriteLine(learningMovies[i].TmdbScore);
                }
                Console.WriteLine(learningMovies[i].Score);
            }

        }

        /// <summary>
        /// Az adott válaszokkal összehasonlítjuk a filmek adott tulajdonságát, a pontszámukat pedig egyezés esetén megnöveljük
        /// </summary>
        /// <param name="featureSelector">a learningMovies lista kiválasztott adattagja, amelyben aktuálisan keresni fogunk</param>
        /// <param name="score">az UpdateScore metódusban kiszámolt pontszám, amellyel az egyező filmek értékeit növeljük</param>
        public void ModifyScore(Func<LearningMovie, List<string>> featureSelector, double score)
        {
            for (int i = 0; i < selectedFromCheckbox.Count; i++)
            {
                for (int j = 0; j < learningMovies.Count; j++)
                {
                    if (featureSelector(learningMovies[j]).Contains(selectedFromCheckbox[i]))
                    {
                        learningMovies[j].Score += score;
                    }
                }
            }
        }

        public void ModifyScoreForTrueOrFalse(Func<LearningMovie, bool> featureSelector, double score)
        {
            for (int i = 0; i < selectedFromCheckbox.Count; i++)
            {
                bool selectedValue = bool.Parse(selectedFromCheckbox[i]);

                for (int j = 0; j < learningMovies.Count; j++)
                {
                    if (featureSelector(learningMovies[j]) == selectedValue)
                    {
                        learningMovies[j].Score += score;
                    }
                }
            }
        }

        public void ModifyScoreForSingle(Func<LearningMovie, string> featureSelector, double score)
        {
            for (int i = 0; i < selectedFromCheckbox.Count; i++)
            {

                for (int j = 0; j < learningMovies.Count; j++)
                {
                    if (featureSelector(learningMovies[j]).Contains(selectedFromCheckbox[i]))
                    {
                        learningMovies[j].Score += score;
                    }
                }
            }
        }

        public void SetScore()
        {
            for (int i = 0; i < movies.Count; i++)
            {
                movies[i].Score = 0;
            }

            for (int i = 0; i < learningMovies.Count; i++)
            {
                learningMovies[i].Score = 0;
            }
        }
        public void SetLists(List<PriorityListItem> priorityList, List<Movie> moviesFromRecSys, PropertiesForDecTree propertiesFromRexSys)
        {
            receivedPriorityList = priorityList;
            movies = moviesFromRecSys;
            properties = propertiesFromRexSys;
        }

        public void FillupFeaturesForCheckbox(List<string> features, List<string> movie)
        {
            for (int i = 0; i < movie.Count; i++)
            {
                if (!features.Contains(movie[i]))
                {
                    features.Add(movie[i]);
                }
            }
        }

        public void InitFeaturesForCheckbox()
        {
            featuresForCheckbox.Genre = new List<string>();
            featuresForCheckbox.MainActor = new List<string>();
            featuresForCheckbox.Keyword = new List<string>();
            featuresForCheckbox.Language = new List<string>();
            featuresForCheckbox.Director = new List<string>();
            featuresForCheckbox.Country = new List<string>();
        }
        private void QuestionsControl_Load(object sender, EventArgs e)
        {
            SetScore();
            InitFeaturesForCheckbox();
            CreateLearningData();
            CreateQuestions();
            LoadQuestion();
            LoadAnswers(receivedPriorityList[currentIndex].Id);

            if (receivedPriorityList.Count == 1)
            {
                buttonNext.Visible = false;
                buttonFinish.Visible = true;
            }
        }

        public void MainActorQuestion()
        {
            checkedListBox.Items.Clear();
            for (int i = 0; i < featuresForCheckbox.MainActor.Count; i++)
            {
                checkedListBox.Items.Add(featuresForCheckbox.MainActor[i]);
            }
        }
        /// <summary>
        /// A felhasználó kedvenc dolgainak kiválasztása kérdéstípus esetében a műfajokhoz kapcsolódó válaszlehetőségek betöltése
        /// </summary>
        public void GenreQuestion()
        {
            checkedListBox.Items.Clear();
            for (int i = 0; i < featuresForCheckbox.Genre.Count; i++)
            {
                checkedListBox.Items.Add(featuresForCheckbox.Genre[i]);
            }
        }

        public void TmdbQuestion()
        {
            SetTrackbarProperties(trackBarMin, textBoxTrackbarMin, 100, 900, 500, true, false,
                new int[] { 115, 174 }, new int[] { 278, 225 }, new int[] { 112, 220 }, new int[] { 479, 220 }, labelSliderMinMin, labelSliderMinMax);
        }
        /// <summary>
        /// A csúszkás válaszlehetőséggel rendelkező kérdések közül a megjelenés évének esetében meghívandó metódus a válaszokhoz
        /// </summary>
        public void ReleasedQuestion()
        {
            SetTrackbarProperties(trackBarMax, textBoxTrackbarMax, 1950, 2024, 2001, false, true,
                new int[] { 96, 210 }, new int[] { 317, 286 }, new int[] { 93, 258 }, new int[] { 451, 258 }, labelSliderMaxMin, labelSliderMaxMax);
            SetTrackbarProperties(trackBarMin, textBoxTrackbarMin, 1950, 2024, 2000, false, true,
                new int[] { 96, 131 }, new int[] { 197, 286 }, new int[] { 93, 179 }, new int[] { 451, 179 }, labelSliderMinMin, labelSliderMinMax);
        }

        public void RuntimeQuestion()
        {
            SetTrackbarProperties(trackBarMax, textBoxTrackbarMax, 50, 400, 100, false, true,
                new int[] { 96, 210 }, new int[] { 317, 286 }, new int[] { 93, 258 }, new int[] { 451, 258 }, labelSliderMaxMin, labelSliderMaxMax);
            SetTrackbarProperties(trackBarMin, textBoxTrackbarMin, 50, 400, 101, false, true,
                new int[] { 96, 131 }, new int[] { 197, 286 }, new int[] { 93, 179 }, new int[] { 451, 179 }, labelSliderMinMin, labelSliderMinMax);
        }

        /// <summary>
        /// Az igaz/hamis kérdések esetében meghívandó algoritmus a válaszokhoz
        /// </summary>
        public void QuestionTrueOrFalse()
        {
            trueOrFalse = true;
            checkedListBox.Items.Clear();
            checkedListBox.Items.Add(true);
            checkedListBox.Items.Add(false);

        }

        public void KeywordQuestion()
        {
            labelSearch.Visible = true;
            textBoxSearch.Visible = true;
            buttonClear.Visible = true;
            checkedListBox.Items.Clear();
            for (int i = 0; i < featuresForCheckbox.Keyword.Count; i++)
            {
                checkedListBox.Items.Add(featuresForCheckbox.Keyword[i]);
            }

        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchText = textBoxSearch.Text.ToLower();
                FilterCheckedListBox(searchText);
            }
        }
        /// <summary>
        /// Kereső a Keywords jellemzőhöz kapcsolódó kérdéshez
        /// </summary>
        /// <param name="searchText">A keresett kifejezés</param>
        private void FilterCheckedListBox(string searchText)
        {

            string itemText;
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                itemText = checkedListBox.Items[i].ToString();
                if (checkedListBox.GetItemChecked(i) == true)
                {
                    if (!selectedFromCheckbox.Contains(itemText))
                    {
                        selectedFromCheckbox.Add(itemText);
                    }
                }
                else
                {
                    selectedFromCheckbox.Remove(itemText);
                }
            }

            checkedListBox.Items.Clear();

            for (int i = 0; i < featuresForCheckbox.Keyword.Count; i++)
            {
                if (featuresForCheckbox.Keyword[i].ToLower().Contains(searchText))
                {
                    checkedListBox.Items.Add(featuresForCheckbox.Keyword[i]);
                }
            }

            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                itemText = checkedListBox.Items[i].ToString();
                if (selectedFromCheckbox.Contains(itemText))
                {
                    checkedListBox.SetItemChecked(i, true);
                }
            }
        }

        public void LanguageQuestion()
        {
            checkedListBox.Items.Clear();
            for (int i = 0; i < featuresForCheckbox.Language.Count; i++)
            {
                checkedListBox.Items.Add(featuresForCheckbox.Language[i]);
            }
        }

        public void CountryQuestion()
        {
            checkedListBox.Items.Clear();
            for (int i = 0; i < featuresForCheckbox.Country.Count; i++)
            {
                checkedListBox.Items.Add(featuresForCheckbox.Country[i]);
            }
        }

        public void DirectorQuestion()
        {
            checkedListBox.Items.Clear();
            for (int i = 0; i < featuresForCheckbox.Director.Count; i++)
            {
                checkedListBox.Items.Add(featuresForCheckbox.Director[i]);
            }
        }

        public void LoadAnswers(int id)
        {
            //switch case szerkezettel kiválasztjuk melyik algoritmust fogjuk meghívni a válaszokkal. receivedlist aktuális elemét paraméterként átadjuk, switch case szerkezettel választunk
            switch (id)
            {
                case (int)Features.Genre:
                    GenreQuestion();
                    break;
                case (int)Features.MainActor:
                    MainActorQuestion();
                    break;
                case (int)Features.Blockbuster:
                    QuestionTrueOrFalse();
                    break;
                case (int)Features.TmdbScore:
                    TmdbQuestion();
                    break;
                case (int)Features.Runtime:
                    RuntimeQuestion();
                    break;
                case (int)Features.GenderOfProtagonist:
                    QuestionTrueOrFalse();
                    break;
                case (int)Features.Released:
                    ReleasedQuestion();
                    break;
                case (int)Features.Popularity:
                    QuestionTrueOrFalse();
                    break;
                case (int)Features.Keyword:
                    KeywordQuestion();
                    break;
                case (int)Features.Language:
                    LanguageQuestion();
                    break;
                case (int)Features.Country:
                    CountryQuestion();
                    break;
                case (int)Features.Director:
                    DirectorQuestion();
                    break;
            }
        }

        /// <summary>
        /// A Next gomb megnyomásakor lefutó metódus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < receivedPriorityList.Count - 1)
            {

                UpdateScore();
                currentIndex++;
                if (trackBarMin.Visible == true || trackBarMax.Visible == true)
                {
                    trackBarMin.Visible = false;
                    trackBarMax.Visible = false;
                    textBoxTrackbarMin.Visible = false;
                    textBoxTrackbarMax.Visible = false;
                    checkedListBox.Visible = true;
                    labelSliderMinMin.Visible = false;
                    labelSliderMinMax.Visible = false;
                    labelSliderMaxMin.Visible = false;
                    labelSliderMaxMax.Visible = false;

                }
                if (textBoxSearch.Visible == true)
                {
                    textBoxSearch.Visible = false;
                    labelSearch.Visible = false;
                    buttonClear.Visible = false;
                }
                if (trueOrFalse)
                {
                    trueOrFalse = false;
                }
                LoadQuestion();
                LoadAnswers(receivedPriorityList[currentIndex].Id);

                if (currentIndex == receivedPriorityList.Count - 1)
                {
                    buttonNext.Visible = false;
                    buttonFinish.Visible = true;
                }

            }

        }

        /// <summary>
        /// A trackbarok tulajdonságainak beállítását végző metódus
        /// </summary>
        /// <param name="trackbar">A csúszka, amelynek a jellemzőit módosítjuk</param>
        /// <param name="textbox">A csúszkához tartozó textbox</param>
        /// <param name="min">A beállítható minimum érték</param>
        /// <param name="max">A beállítható maximum érték</param>
        /// <param name="startValue">A beállítandó kezdőérték</param>
        /// <param name="scaleInput">Annak beállítása, hogy kell-e arányosítani a beállított értékeket</param>
        /// <param name="rangeInput">Annak beállítása, hogy tartományt adunk-e meg, vagy csak alsó/felső határértéket</param>
        /// <param name="trackbarLocation">A csúszka helyzetének beállítása</param>
        /// <param name="textboxLocation">A csúszkához tartozó textbox helyzetének beállítása</param>
        /// <param name="labelMinLocation">A beállítható minimum értéket megjelenítő címke helyzete</param>
        /// <param name="labelMaxLocation">A beállítható maximum értéket megjelenítő címke helyzete</param>
        /// <param name="labelMin">A beállítható minimum értéket megjelenítő címke értéke</param>
        /// <param name="labelMax">A beállítható maximum értéket megjelenítő címke értéke</param>
        public void SetTrackbarProperties(System.Windows.Forms.TrackBar trackbar, System.Windows.Forms.TextBox textbox,
            int min, int max, int startValue, bool scaleInput, bool rangeInput, int[] trackbarLocation, int[] textboxLocation,
            int[] labelMinLocation, int[] labelMaxLocation, Label labelMin, Label labelMax)
        {
            checkValueError = false;
            scale = scaleInput;
            range = rangeInput;
            checkedListBox.Visible = false;
            trackbar.Visible = true;
            textbox.Visible = true;
            labelMin.Visible = true;
            labelMax.Visible = true;
            trackbar.Minimum = min;
            trackbar.Maximum = max;
            trackbar.Value = startValue;
            checkValueError = true;
            trackbar.Location = new Point(trackbarLocation[0], trackbarLocation[1]);
            textbox.Location = new Point(textboxLocation[0], textboxLocation[1]);
            labelMin.Location = new Point(labelMinLocation[0], labelMinLocation[1]);
            labelMax.Location = new Point(labelMaxLocation[0], labelMaxLocation[1]);
            if (scale)
            {
                labelMin.Text = (min / 100).ToString();
                labelMax.Text = (max / 100).ToString();
            }
            else
            {
                labelMin.Text = min.ToString();
                labelMax.Text = max.ToString();
            }
        }
        private void trackBarMin_ValueChanged(object sender, EventArgs e)
        {
            if (scale == true)
            {
                textBoxTrackbarMin.Text = "" + (float)(trackBarMin.Value) / 100;

            }
            else
            {
                textBoxTrackbarMin.Text = "" + trackBarMin.Value;
                trackBarMin.Value = int.Parse(textBoxTrackbarMin.Text);
                if (trackBarMin.Value > trackBarMax.Value && checkValueError == true)
                {
                    MessageBox.Show("Check the input data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    trackBarMin.Value = trackBarMax.Value;
                }
            }

        }
        /// <summary>
        /// A maximum értéket beállító trackbar értékének megváltozásakor lefutó metódus, elvégzi a textbox tartalmának
        /// frissítését és a két csúszka értékének egymáshoz képest való ellenőrzését
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarMax_ValueChanged(object sender, EventArgs e)
        {
            if (scale == true)
            {
                textBoxTrackbarMax.Text = "" + (float)(trackBarMax.Value) / 100;
            }
            else
            {
                textBoxTrackbarMax.Text = "" + trackBarMax.Value;
                trackBarMax.Value = int.Parse(textBoxTrackbarMax.Text);
                if (trackBarMin.Value > trackBarMax.Value && checkValueError == true)
                {

                    MessageBox.Show("Error", "Check the input data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    trackBarMax.Value = trackBarMin.Value;
                }
            }
        }

        private void textBoxTrackbarMin_Leave(object sender, EventArgs e)
        {
            CheckInputError(trackBarMin, textBoxTrackbarMax, textBoxTrackbarMin);
        }

        private void textBoxTrackbarMin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckInputError(trackBarMin, textBoxTrackbarMax, textBoxTrackbarMin);
                e.SuppressKeyPress = true;
            }
        }

        private void textBoxTrackbarMax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckInputError(trackBarMax, textBoxTrackbarMin, textBoxTrackbarMax);
                e.SuppressKeyPress = true; // Ez megakadályozza, hogy az Enter billentyű új sort hozzon létre
            }
        }

        private void textBoxTrackbarMax_Leave(object sender, EventArgs e)
        {
            CheckInputError(trackBarMax, textBoxTrackbarMin, textBoxTrackbarMax);
        }
        /// <summary>
        /// A csúszkák esetében a textboxba beírt értékek ellenőrzése, és helyes érték esetén a trackbar értékének frissítése
        /// </summary>
        /// <param name="trackbarToChange">A trackbar, aminek az értékét módosítani szeretnénk</param>
        /// <param name="textboxFrom">A trackbarhoz tartozó textbox, amibe az érték belekerült</param>
        /// <param name="textbox">A másik trackbar, aminek az értékét felhasználjuk hibás érték megadásakor</param>
        public void CheckInputError(System.Windows.Forms.TrackBar trackbarToChange,
            System.Windows.Forms.TextBox textboxFrom, System.Windows.Forms.TextBox textbox)
        {
            try
            {
                if (!scale)
                {
                    trackbarToChange.Value = int.Parse(textbox.Text);
                }
                else
                {
                    trackbarToChange.Value = (int)(float.Parse(textbox.Text, CultureInfo.InvariantCulture) * 100);
                }
            }
            catch
            {
                MessageBox.Show("Error", "Check the input data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!scale)
                {
                    trackbarToChange.Value = int.Parse(textboxFrom.Text);
                    textbox.Text = textboxFrom.Text;
                }
                else
                {
                    trackbarToChange.Value = 500;
                    textbox.Text = (trackbarToChange.Value / 100).ToString();
                }
            }
        }
        /// <summary>
        /// A finish gomb megnyomásakor lefutó metódus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFinish_Click(object sender, EventArgs e)
        {
            UpdateScore();
            MainDecTree mainDecTree = new MainDecTree();
            mainDecTree.BuildTree(learningMovies, movies, properties);

            if (FinishButtonClicked != null)
            {
                FinishButtonClicked(this, EventArgs.Empty);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";
            string searchText = textBoxSearch.Text.ToLower();
            FilterCheckedListBox(searchText);
        }
        /// <summary>
        /// Annak kezelése, hogy csak egy checkbox lehessen bepipálva igaz/hamis kérdések esetében
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (trueOrFalse)
            {
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        checkedListBox.SetItemChecked(i, false);
                    }
                }
            }
        }
    }
}
