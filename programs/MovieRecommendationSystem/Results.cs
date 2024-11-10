using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRecommendationSystem
{
    public partial class Results : UserControl
    {
        private List<Movie> movies = new List<Movie>();
        public Results(List<Movie> moviesWithScores)
        {
            InitializeComponent();
            movies = moviesWithScores;
        }

        public void Sorting()
        {
            movies = movies.OrderByDescending(movie => movie.Score).Take(5).ToList();

        }

        private void Results_Load(object sender, EventArgs e)
        {
            Sorting();
            for (int i = 0; i < 5; i++)
            {
                this.Controls["textBoxMovie" + (i + 1)].Text = movies[i].Title;
            }
        }
    }
}
