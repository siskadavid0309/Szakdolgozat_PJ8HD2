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

namespace MovieRecommendationSystem
{
    public partial class Main : Form
    {
        private List<Movie> movies=new List<Movie>();
        private List<Language> movie=new List<Language>();
        public List<int> tableID = new List<int>();
        public List<string> tableData = new List<string>();
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
            PropertiesForDecTree properties =new PropertiesForDecTree();
            movies = conn.collectMovie();
            alg.InitLists(ref movies);
            alg.InitFillContains( ref properties, movies);
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
            dataGridView1.DataSource= movies;
            tree.Show();
            tree.MainJson();
            //createTree.BuildTree(movies);
            DecTreeForLanguage dectree= new DecTreeForLanguage();
            DecTreeForGender gender= new DecTreeForGender();
            DecTreeForDirector director= new DecTreeForDirector();
            DecTreeForTmdb tmdb= new DecTreeForTmdb();
            //gender.BuildTree(movies, properties);
            alg.FillContains(ref properties, movies);
            //gender.BuildTree(movies, properties);
            //director.BuildTree(movies, properties);
            tmdb.BuildTree(movies, properties);
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
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }
}
