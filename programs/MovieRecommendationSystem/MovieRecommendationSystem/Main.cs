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
            CreateTree createTree = new CreateTree();
            movies = conn.collectMovie();
            alg.InitLists(ref movies);
            conn.FillupGenre(ref movies);
            conn.FillupKeywords(ref movies);
            conn.FillupDirector(ref movies);
            conn.FillupLanguage(ref movies);
            conn.FillupCountry(ref movies);

            conn.GetGenre(ref movies, tableID, tableData);
            conn.GetKeyword(ref movies, tableID, tableData);
            conn.GetDirector(ref movies, tableID, tableData);
            conn.GetLanguage(ref movies, tableID, tableData);
            conn.GetCountry(ref movies, tableID, tableData);
            dataGridView1.DataSource= movies;
            tree.Show();
            tree.MainJson();

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
