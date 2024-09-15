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
    public partial class QuestionsControl : UserControl
    {
        private List<PriorityListItem> receivedList;
        private List<Movie> movies;
        public QuestionsControl()
        {
            InitializeComponent();
        }

        public void SetPriorityList( List<PriorityListItem> list)
        {
            receivedList = list;

        }

        public void SetMoviesList(List<Movie> moviesFromRecSys)
        {
            movies = moviesFromRecSys;

        }

        private void QuestionsControl_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < receivedList.Count; i++)
            {
                Console.WriteLine(receivedList[i].Title);
            }
            for (int i = 0;i < movies.Count;i++)
            {
                Console.WriteLine(movies[i].Title);
            }
        }
    }
}
