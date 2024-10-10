using MovieRecommendation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableInsertsLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MovieRecommendationSystem
{
    public partial class Main : Form
    {

        private List<Movie> movies=new List<Movie>();
       // private List<Language> movie=new List<Language>();
        public List<int> tableID = new List<int>();
        public List<string> tableData = new List<string>();
        private List<MovieTI> moviesTI = new List<MovieTI>();
        private PropertiesForDecTree properties = new PropertiesForDecTree();
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Az ablak megnyílásakor lefutó metódushívások
        /// </summary>
        private void Main_Load(object sender, EventArgs e)
        {
            string databasePath = CreatePath();
            SqlConnector conn = new SqlConnector(databasePath);
            Algorithms alg = new Algorithms();
            HandmadeLanguageDecTree tree = new HandmadeLanguageDecTree();
            //PropertiesForDecTree properties =new PropertiesForDecTree();
            MeasureAccuracy measure= new MeasureAccuracy();
            //alg.LoadTableInserts(ref moviesTI, databasePath);
            movies = conn.collectMovie();
            alg.InitLists(ref movies);
            alg.InitListsForFillContains( ref properties);
            conn.FillupGenre(ref movies);
            conn.FillupKeywords(ref movies);
            conn.FillupDirector(ref movies);
            conn.FillupLanguage(ref movies);
            conn.FillupCountry(ref movies);

            conn.GetGenre(ref movies, tableID, tableData,ref properties);
            conn.GetKeyword(ref movies, tableID, tableData, ref properties);
            conn.GetDirector(ref movies, tableID, tableData, ref properties);
            conn.GetLanguage(ref movies, tableID, tableData, ref properties);
            conn.GetCountry(ref movies, tableID, tableData, ref properties);
            alg.InitArraysForFillContains(ref properties, movies);
            alg.IsBlockbuster(ref movies);
            alg.IsPopular(ref movies);
            tree.Show();
            tree.MainJson();
            //createTree.BuildTree(movies);
            DecTreeForLanguage dectree= new DecTreeForLanguage();
            DecTreeForGender gender= new DecTreeForGender();
            DecTreeForDirector director= new DecTreeForDirector();
            DecTreeForTmdb tmdb= new DecTreeForTmdb();
            //gender.BuildTree(movies, properties);
            alg.FillContains(ref properties, movies);

            //dectree.CompareToHandmadeDecTree(movies);

            //gender.BuildTree(movies, properties);
            //director.BuildTree(movies, properties);
            tmdb.BuildTree(movies, properties);
            //méréses cucc measure.MeasureAll(movies, properties);

            //gender.BuildTree(movies, properties);
            //director.BuildTree(movies, properties);

            //SetPriority setPriority= new SetPriority();
            //setPriority.Show();



        }
        /// <summary>
        /// A táblák, listák értékeinek újragenerálását és feltöltését végzi abban az esetben, ha módosul az adatbázis
        /// </summary>
        public void Loader()
        {
            movies.Clear();
            string databasePath = CreatePath();
            SqlConnector conn = new SqlConnector(databasePath);
            Algorithms alg = new Algorithms();
            HandmadeLanguageDecTree tree = new HandmadeLanguageDecTree();
           // PropertiesForDecTree properties = new PropertiesForDecTree();
            alg.LoadTableInserts(ref moviesTI, databasePath); // A TableInserts program metódushívásait összefogó metódus meghívása
            movies = conn.collectMovie(); // a filmeket tároló lista újra feltöltése már naprakész adatokkal
            alg.InitLists(ref movies);
            alg.InitListsForFillContains(ref properties);
            conn.FillupGenre(ref movies); // A korábbiakban már részletezett metódusok meghívása
            conn.FillupKeywords(ref movies);
            conn.FillupDirector(ref movies);
            conn.FillupLanguage(ref movies);
            conn.FillupCountry(ref movies);

            conn.GetGenre(ref movies, tableID, tableData, ref properties);
            conn.GetKeyword(ref movies, tableID, tableData, ref properties);
            conn.GetDirector(ref movies, tableID, tableData, ref properties);
            conn.GetLanguage(ref movies, tableID, tableData, ref properties);
            conn.GetCountry(ref movies, tableID, tableData, ref properties);
            alg.InitArraysForFillContains(ref properties, movies);
            alg.IsBlockbuster(ref movies);
            alg.IsPopular(ref movies);
            // tree.Show();
            //tree.MainJson();
            //createTree.BuildTree(movies);
            DecTreeForLanguage dectree = new DecTreeForLanguage();
            DecTreeForGender gender = new DecTreeForGender();
            DecTreeForDirector director = new DecTreeForDirector();
            DecTreeForTmdb tmdb = new DecTreeForTmdb();
            //gender.BuildTree(movies, properties);
            alg.FillContains(ref properties, movies);
            
            //gender.BuildTree(movies, properties);
            //director.BuildTree(movies, properties);
           // tmdb.BuildTree(movies, properties);
            //dectree.Build(movies);
            //dectree.Build2(movies);
        }

        public string CreatePath()
        {

            string databaseFileName = "movies.db";
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string databasePath = Path.Combine(currentDirectory, databaseFileName);
            return databasePath;

        }
        

        /// <summary>
        /// A Table gomb megnyomásakor lefutó metódus   
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowTable_Click(object sender, EventArgs e)
        {
            ShowTable showTable = new ShowTable(movies);
            showTable.Show();
        }

        /// <summary>
        /// A Change Database gomb megnyomásának hatására lefutó metódus, ez végzi el az adatbázis cseréjét
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ChangeDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // Fájltallózó intéző ablak létrehozása
            openFileDialog.Title = "Select the database file";
            DialogResult result = openFileDialog.ShowDialog(); // A létrehozott ablak megjelenítése
            if (result == DialogResult.OK) // Ha a felhasználó kiválasztja az adott betallózandó fájlt
            {
                string source=openFileDialog.FileName; // Eltárolja a választott fájl elérési útvonalát
                string destination = AppDomain.CurrentDomain.BaseDirectory;
                string destinationFilePath = Path.Combine(destination, "movies.db"); //Beállítja célútvonalnak a program saját könyvtárát, és a bemásolandó fájl nevét movies.db-re
                try
                {
                    File.Copy(source, destinationFilePath, true); // A betallózott fájlt eredeti helyéről a program saját könyvtárába másolja, ezzel lecserélve a régi movies.db fájlt
                }
                catch 
                {
                    MessageBox.Show("Error");
                }

                ProgressBar progressBar = new ProgressBar();
                progressBar.Show(); // Progress bar megjelenítése ami jelzi a felhasználó felé, hogy az adatbázis frissítése történik
                try
                {
                    await Task.Run(() => Loader()); // Aszinkron módban futtatva meghívja az osztály Loader() metódusát annak érdekében, hogy a feltöltés alatt ne fagyjon meg a program
                }
                finally
                {
                    
                    progressBar.Visible = false; //Ha lefutott a Loader metódus, tehát lényegében a lista és adatbázis frissítés, akkor a progress bar eltűnik
                }

            }
        }

        private void ManageMoviesButton_Click(object sender, EventArgs e)
        {
            ManageMovie manageMovie = new ManageMovie(movies);
            manageMovie.Show();
        }

        private void buttonRecommendationSystem_Click(object sender, EventArgs e)
        {
            RecommendationSystem recommendationSystem = new RecommendationSystem(movies, properties);
            recommendationSystem.Show();
        }
    }
}
