using MovieRecommendation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableInsertsLibrary;

namespace MovieRecommendationSystem
{
    public partial class ManageMovie : Form
    {
        private List<Movie> moviesForModify;
        private Movie selectedMovie;
        private bool inputError;

        public ManageMovie()
        {
            InitializeComponent();
        }

        // Új konstruktor, amely elfogad egy Movies példányt
        public ManageMovie(List<Movie> movies)
        {
            InitializeComponent();
            moviesForModify = movies;
        }

        private void ManageMovie_Load(object sender, EventArgs e)
        {
            SetCboxDetails();
        }

        /// <summary>
        /// Combobox tulajdonságainak beállítása
        /// </summary>
        private void SetCboxDetails()
        {

            cboxTitle.DataSource = moviesForModify; // A combobox adatforrása a moviesForModify lista
            cboxTitle.DisplayMember = "Title"; // A comboboxot lenyitva a filmek címei jelennek meg
            cboxTitle.ValueMember = "Id"; // A filmeket a comboboxban is az Id-juk segítségével azonosítjuk
        }

        private void cboxTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillupTextboxes();
        }

        /// <summary>
        /// A textboxok feltöltése a kiválasztott film adataival
        /// </summary>
        private void FillupTextboxes()
        {
            selectedMovie = (Movie)cboxTitle.SelectedItem; // A selectedMovie változóban eltároljuk a kiválasztott film adatait
            if (selectedMovie != null)
            {
                textBoxTitle.Text = selectedMovie.Title;
                textBoxGenre.Text = selectedMovie.GenreStringWithCommas;
                textBoxReleased.Text = selectedMovie.Released.ToString();
                textBoxRuntime.Text = selectedMovie.Runtime.ToString();
                textBoxGenderOfTheProtagonist.Text = selectedMovie.GenderOfProtagonist.ToString();
                textBoxMainActor.Text = selectedMovie.MainActor;
                textBoxKeywords.Text = selectedMovie.KeywordStringWithCommas.ToString();
                textBoxDirector.Text = selectedMovie.DirectorStringWithCommas.ToString();
                textBoxLanguage.Text = selectedMovie.LanguageStringWithCommas.ToString();
                textBoxCountries.Text = selectedMovie.CountryStringWithCommas.ToString();
                textBoxTmdbScore.Text = selectedMovie.TmdbScore.ToString();
                textBoxNumberOfRatings.Text = selectedMovie.NumberOfRatings.ToString();
                textBoxPopularity.Text = selectedMovie.Popularity.ToString();
                textBoxBudget.Text = selectedMovie.Budget.ToString();
                textBoxRevenue.Text = selectedMovie.Revenue.ToString();
            }
        }

        /// <summary>
        /// A Modify gomb hatására végrehajtandó algoritmus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonModify_Click(object sender, EventArgs e)
        {

            if (IsEmpty() == false) // Mezők ürességének ellenőrzése
            {

                GetFromTextboxes(ref selectedMovie); // A mezőkből az adatok kiolvasása

                if (inputError == false)
                {
                    SqlConnector conn = new SqlConnector(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "movies.db"));
                    string command;
                    command = string.Format("UPDATE Movies SET Title= \"{0}\", Genre= \"{1}\", Released= \"{2}\", Runtime= {3}, Gender_of_the_protagonist={4}," +
                        " Main_actor=\"{5}\", Keywords=\"{6}\", Director=\"{7}\", Language=\"{8}\", Production_countries=\"{9}\", Tmdb_score={10}, Number_of_ratings={11}," +
                        " Popularity={12}, Budget={13}, Revenue={14} WHERE ID={15}",
                        selectedMovie.Title, selectedMovie.GenreStringWithCommas, selectedMovie.Released, selectedMovie.Runtime, selectedMovie.GenderOfProtagonist,
                        selectedMovie.MainActor, selectedMovie.KeywordStringWithCommas, selectedMovie.DirectorStringWithCommas, selectedMovie.LanguageStringWithCommas,
                        selectedMovie.CountryStringWithCommas, selectedMovie.TmdbScore.ToString(System.Globalization.CultureInfo.InvariantCulture), selectedMovie.NumberOfRatings,
                        selectedMovie.Popularity.ToString(System.Globalization.CultureInfo.InvariantCulture), selectedMovie.Budget, selectedMovie.Revenue, selectedMovie.Id);
                    conn.UpdateCommand(command); // Az összekészített SQL utasítás végrehajtása
                    Main main = new Main();
                    ProgressBar progressBar = new ProgressBar();
                    progressBar.Show();
                    try
                    {
                        await Task.Run(() => main.Loader()); // Futtatás aszinkron módban a fagyás kiküszöbölésének érdekében
                    }
                    finally
                    {
                        progressBar.Visible = false;
                    }
                }
            }
        }
        /// <summary>
        /// Egy címke megjelenítése ha az egér a textBoxGenre-en áll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxGenre_MouseEnter(object sender, EventArgs e)
        {
            // Amikor az egér a TextBox fölé ér, megjelenítjük a label-t
            labelGenreHint.Visible = true;
        }

        /// <summary>
        /// A címke eltüntetése ha az egér már nem áll a textBoxGenre-ön
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxGenre_MouseLeave(object sender, EventArgs e)
        {
            // Amikor az egér elhagyja a TextBox-ot, elrejtjük a label-t
            labelGenreHint.Visible = false;
        }

        private void textBoxGenderOfTheProtagonist_MouseEnter(object sender, EventArgs e)
        {
            labelGenderOfProtagonistHint.Visible = true;
        }

        private void textBoxGenderOfTheProtagonist_MouseLeave(object sender, EventArgs e)
        {
            labelGenderOfProtagonistHint.Visible = false;
        }

        private void textBoxKeywords_MouseEnter(object sender, EventArgs e)
        {
            labelKeywordHint.Visible = true;
        }

        private void textBoxKeywords_MouseLeave(object sender, EventArgs e)
        {
            labelKeywordHint.Visible = false;
        }

        private void textBoxDirector_MouseEnter(object sender, EventArgs e)
        {
            labelDirectorHint.Visible = true;
        }

        private void textBoxDirector_MouseLeave(object sender, EventArgs e)
        {
            labelDirectorHint.Visible = false;
        }

        private void textBoxLanguage_MouseEnter(object sender, EventArgs e)
        {
            labelLanguageHint.Visible = true;
        }

        private void textBoxLanguage_MouseLeave(object sender, EventArgs e)
        {
            labelLanguageHint.Visible = false;

        }

        private void textBoxCountries_MouseEnter(object sender, EventArgs e)
        {
            labelCountriesHint.Visible = true;
        }

        private void textBoxCountries_MouseLeave(object sender, EventArgs e)
        {
            labelCountriesHint.Visible = false;
        }

        private void textBoxTmdb_MouseEnter(object sender, EventArgs e)
        {
            labelTmdbHint.Visible = true;
        }

        private void textBoxTmdb_MouseLeave(object sender, EventArgs e)
        {
            labelTmdbHint.Visible = false;

        }

        private void textBoxPopularity_MouseEnter(object sender, EventArgs e)
        {
            labelPopularityHint.Visible = true;
        }

        private void textBoxPopularity_MouseLeave(object sender, EventArgs e)
        {
            labelPopularityHint.Visible = false;

        }

        private async void buttonAdd_Click(object sender, EventArgs e)
        {

            Movie temp = new Movie();
            if (IsEmpty() == false)
            {
                GetFromTextboxes(ref temp);
                temp.Id = moviesForModify[moviesForModify.Count - 1].Id + 1;
                if (inputError == false)
                {

                    SqlConnector conn = new SqlConnector(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "movies.db"));
                    string command;
                    command = string.Format("INSERT INTO Movies (ID, Title, Genre, Released, Runtime, Gender_of_the_protagonist," +
                        " Main_actor, Keywords, Director, Language, Production_countries, Tmdb_score, Number_of_ratings, Popularity, Budget, Revenue)" +
                        " VALUES( {0},\"{1}\", \"{2}\", \"{3}\", {4}, {5}, \"{6}\", \"{7}\", \"{8}\", \"{9}\", \"{10}\", {11}, {12}, {13}, {14}, {15})",
                       moviesForModify[moviesForModify.Count - 1].Id + 1, temp.Title, temp.GenreStringWithCommas, temp.Released, temp.Runtime,
                       temp.GenderOfProtagonist, temp.MainActor, temp.KeywordStringWithCommas, temp.DirectorStringWithCommas, temp.LanguageStringWithCommas,
                       temp.CountryStringWithCommas, temp.TmdbScore.ToString(System.Globalization.CultureInfo.InvariantCulture), temp.NumberOfRatings,
                       temp.Popularity.ToString(System.Globalization.CultureInfo.InvariantCulture), temp.Budget, temp.Revenue, temp.Id);
                    moviesForModify.Add(temp);
                    conn.UpdateCommand(command);
                    Main main = new Main();
                    ProgressBar progressBar = new ProgressBar();
                    progressBar.Show();
                    cboxTitle.DataSource = null;
                    HomeScreen();
                    try
                    {
                        await Task.Run(() => main.Loader());
                    }
                    finally
                    {
                        progressBar.Visible = false;
                    }

                }
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < moviesForModify.Count; i++)
            {
                if (moviesForModify[i].Id == selectedMovie.Id)
                {
                    try
                    {

                        moviesForModify.RemoveAt(i);


                    }
                    catch
                    {
                        MessageBox.Show("Check the input data!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


            SqlConnector conn = new SqlConnector(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "movies.db"));
            SqlConnectorTI connTI = new SqlConnectorTI(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "movies.db"));
            FillUpsTI fillUps = new FillUpsTI();
            connTI.ExecuteInserts(fillUps.UpdateDB());
            string command;
            command = string.Format("DELETE FROM Movies WHERE ID={0}", selectedMovie.Id);
            conn.UpdateCommand(command);
            Main main = new Main();
            ProgressBar progressBar = new ProgressBar();
            progressBar.Show();
            cboxTitle.DataSource = null;
            cboxTitle.DataSource = moviesForModify;
            cboxTitle.DisplayMember = "Title";
            cboxTitle.ValueMember = "Id";
            try
            {
                await Task.Run(() => main.Loader());
            }
            finally
            {
                progressBar.Visible = false;
            }
        }

        /// <summary>
        /// A módosító felület átalakítása új film beszúrásához
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            cboxTitle.Visible = false;
            buttonAdd.Visible = true;
            buttonAddNew.Visible = false;
            buttonDelete.Visible = false;
            buttonModify.Visible = false;
            buttonBack.Visible = true;
            labelQuestion.Visible = false;
            labelAddNew.Visible = true;

            textBoxTitle.Text = String.Empty; // A textboxok tartalmának kiürítése
            textBoxGenre.Text = String.Empty;
            textBoxReleased.Text = String.Empty;
            textBoxRuntime.Text = String.Empty;
            textBoxGenderOfTheProtagonist.Text = String.Empty;
            textBoxMainActor.Text = String.Empty;
            textBoxKeywords.Text = String.Empty;
            textBoxDirector.Text = String.Empty;
            textBoxLanguage.Text = String.Empty;
            textBoxCountries.Text = String.Empty;
            textBoxTmdbScore.Text = String.Empty;
            textBoxNumberOfRatings.Text = String.Empty;
            textBoxPopularity.Text = String.Empty;
            textBoxBudget.Text = String.Empty;
            textBoxRevenue.Text = String.Empty;


        }

        /// <summary>
        /// Az adatok kiolvasása a textboxokból
        /// </summary>
        /// <param name="selectedMovie">A kiolvasott adatokat a selectedMovie-ban tároljuk el</param>
        public void GetFromTextboxes(ref Movie selectedMovie)
        {
            inputError = false;
            if (IsEmpty() == false)
            {
                try
                {
                    selectedMovie.Title = textBoxTitle.Text;
                    selectedMovie.GenreStringWithCommas = textBoxGenre.Text;
                    selectedMovie.Released = int.Parse(textBoxReleased.Text);
                    selectedMovie.Runtime = int.Parse(textBoxRuntime.Text);
                    selectedMovie.GenderOfProtagonist = int.Parse(textBoxGenderOfTheProtagonist.Text);
                    selectedMovie.MainActor = textBoxMainActor.Text;
                    selectedMovie.KeywordStringWithCommas = textBoxKeywords.Text;
                    selectedMovie.DirectorStringWithCommas = textBoxDirector.Text;
                    selectedMovie.LanguageStringWithCommas = textBoxLanguage.Text;
                    selectedMovie.CountryStringWithCommas = textBoxCountries.Text;
                    selectedMovie.TmdbScore = double.Parse(textBoxTmdbScore.Text);
                    selectedMovie.NumberOfRatings = int.Parse(textBoxNumberOfRatings.Text);
                    selectedMovie.Popularity = double.Parse(textBoxPopularity.Text);
                    selectedMovie.Budget = long.Parse(textBoxBudget.Text);
                    selectedMovie.Revenue = long.Parse(textBoxRevenue.Text);
                }
                catch
                {
                    MessageBox.Show("Check the input data!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inputError = true;
                }

            }

        }

        /// <summary>
        /// A textboxok tartalmának ellenőrzése abból a szempontból, hogy üres-e bármelyik
        /// </summary>
        /// <returns>Az ellenőrzés eredményét adja vissza: igaz esetén van üres, hamis esetén nincs</returns>
        public bool IsEmpty()
        {
            bool status = false;
            if (string.IsNullOrEmpty(textBoxTitle.Text) || string.IsNullOrEmpty(textBoxGenre.Text) || string.IsNullOrEmpty(textBoxReleased.Text) || string.IsNullOrEmpty(textBoxRuntime.Text)
                || string.IsNullOrEmpty(textBoxGenderOfTheProtagonist.Text) || string.IsNullOrEmpty(textBoxMainActor.Text) || string.IsNullOrEmpty(textBoxKeywords.Text)
                || string.IsNullOrEmpty(textBoxDirector.Text) || string.IsNullOrEmpty(textBoxLanguage.Text) || string.IsNullOrEmpty(textBoxCountries.Text)
                || string.IsNullOrEmpty(textBoxTmdbScore.Text) || string.IsNullOrEmpty(textBoxNumberOfRatings.Text) || string.IsNullOrEmpty(textBoxPopularity.Text)
                || string.IsNullOrEmpty(textBoxBudget.Text) || string.IsNullOrEmpty(textBoxRevenue.Text))
            {
                status = true;
                MessageBox.Show("There are empty fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            HomeScreen();

        }

        /// <summary>
        /// A ManageMovie osztály ablakának visszaállítása megnyitáskori állapotára
        /// </summary>
        public void HomeScreen()
        {
            SetCboxDetails();
            FillupTextboxes();
            cboxTitle.Visible = true;
            buttonModify.Visible = true;
            buttonBack.Visible = false;
            buttonDelete.Visible = true;
            buttonAddNew.Visible = true;
            buttonAdd.Visible = false;
            labelQuestion.Visible = true;
            labelAddNew.Visible = false;
        }

    }
}
