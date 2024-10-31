using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using TableInsertsLibrary;

namespace MovieRecommendationSystem
{
    public partial class ShowTable : Form
    {

        private List<Movie> moviesToShow;

        /// <summary>
        /// Az osztály konstruktora, amely elfogad egy Movies példányt
        /// </summary>
        /// <param name="movies"></param>
        public ShowTable(List<Movie> movies)
        {
            InitializeComponent();
            moviesToShow = movies;
        }
        public ShowTable()
        {
            InitializeComponent();
        }

            
        /// <summary>
        /// A ShowTable osztály példányosításakor, tehát az ablak megnyílásakor lefutó metódus 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowTable_Load(object sender, EventArgs e)
        {
           
            DataGridView MovieDetailsTable = new DataGridView
            {
                AutoGenerateColumns = true, // Automatikusan generálja az oszlopokat az adatforrás alapján
                Dock = DockStyle.Fill // Kitölti a teljes formot
            };
           // MovieDetailsTable.AutoGenerateColumns = true;
            MovieDetailsTable.DataSource= moviesToShow;
            Controls.Add(MovieDetailsTable);
            ChangeFieldName(MovieDetailsTable);
            MovieDetailsTable.ReadOnly = true;


        }

        public void ChangeFieldName(DataGridView dataGridView)
        {
            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[2].HeaderText = "Year of release";
            dataGridView.Columns[3].HeaderText = "Runtime (Minutes)";
            dataGridView.Columns[4].HeaderText = "Gender of the protagonist (1 is female, 2 is male)";
            dataGridView.Columns[5].HeaderText = "Main actor";
            dataGridView.Columns[6].HeaderText = "TMDB Score";
            dataGridView.Columns[7].HeaderText = "Number of ratings";
            dataGridView.Columns[8].HeaderText = "Popularity";
            dataGridView.Columns[9].HeaderText = "Budget";
            dataGridView.Columns[10].HeaderText = "Revenue";
            dataGridView.Columns[11].HeaderText = "Is it a blockbuster?";
            dataGridView.Columns[11].HeaderText = "Is it a blockbuster?";
            dataGridView.Columns[12].HeaderText = "Is it popular?";
            dataGridView.Columns[14].HeaderText = "Genres";
            dataGridView.Columns[15].HeaderText = "Keywords";
            dataGridView.Columns[16].HeaderText = "Languages";
            dataGridView.Columns[17].HeaderText = "Directors";
            dataGridView.Columns[18].HeaderText = "Production countries";

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
    }
}
