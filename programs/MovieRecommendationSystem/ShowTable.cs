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
           
            DataGridView dataGridView1 = new DataGridView
            {
                AutoGenerateColumns = true, // Automatikusan generálja az oszlopokat az adatforrás alapján
                Dock = DockStyle.Fill // Kitölti a teljes formot
            };
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource= moviesToShow;
            Controls.Add(dataGridView1);
            Console.WriteLine(moviesToShow[0].Title);
            ChangeFieldName(dataGridView1);
            dataGridView1.ReadOnly = true;


        }

        public void ChangeFieldName(DataGridView dataGridView)
        {
            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[2].HeaderText = "Year of release";
            dataGridView.Columns[3].HeaderText = "Runtime (Minutes)";
            dataGridView.Columns[4].HeaderText = "Gender of the protagonist (1 is female, 2 is male)";
            /*dataGridView.Columns[0].HeaderText = "Film Cím";
            dataGridView.Columns[0].HeaderText = "Film Cím";
            dataGridView.Columns[0].HeaderText = "Film Cím";
            dataGridView.Columns[0].HeaderText = "Film Cím";
            dataGridView.Columns[0].HeaderText = "Film Cím";
            dataGridView.Columns[0].HeaderText = "Film Cím";*/
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //dataGridView.Columns["Genre"].HeaderText = "Műfaj";
            //dataGridView.Columns["Runtime"].HeaderText = "Futási Idő (perc)";
        }
    }
}
