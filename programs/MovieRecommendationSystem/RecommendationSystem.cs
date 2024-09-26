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
    public partial class RecommendationSystem : Form
    {
        private List<Movie> movies = new List<Movie>();
        private PropertiesForDecTree properties = new PropertiesForDecTree();
        public RecommendationSystem(List<Movie> moviesFromMain, PropertiesForDecTree propertiesFromMain)
        {
            movies=moviesFromMain;
            properties=propertiesFromMain;
            InitializeComponent();
            LoadPriorityControl();
        }

        private void LoadPriorityControl()
        {
            // Töröljük a korábbi tartalmat
            panelContainer.Controls.Clear();

            // Létrehozzuk a prioritási vezérlőt
            //PriorityControl priorityControl = new PriorityControl();
            SetPriority priorityControl = new SetPriority();
            priorityControl.Dock = DockStyle.Fill; // Teljesen kitölti a panelt

            // Hozzáadjuk a panelhez
            panelContainer.Controls.Add(priorityControl);

            // Ha van gomb a prioritási felületen, ami tovább visz
            priorityControl.NextButtonClicked += PriorityControl_NextButtonClicked;
        }

        private void PriorityControl_NextButtonClicked(object sender, EventArgs e)
        {
            // Amikor a felhasználó a következő gombra kattint
            SetPriority priorityControl = (SetPriority)sender;
            List<PriorityListItem> selectedList = priorityControl.GetSelectedList();
           // questionsControl.SetPriorityList(selectedList);
            LoadQuestionsControl(selectedList);
        }

        private void LoadQuestionsControl(List<PriorityListItem> selectedList)
        {
            // Töröljük a korábbi tartalmat
            panelContainer.Controls.Clear();

            // Létrehozzuk a kérdések vezérlőt
            QuestionsControl questionsControl = new QuestionsControl();
            questionsControl.Dock = DockStyle.Fill; // Teljesen kitölti a panelt

            questionsControl.SetLists(selectedList, movies, properties);
            // Hozzáadjuk a panelhez
            panelContainer.Controls.Add(questionsControl);

            questionsControl.FinishButtonClicked += QuestionsControl_FinishButtonClicked;
        }

        private void LoadResults()
        {
            panelContainer.Controls.Clear();
            Results results = new Results(movies);
            results.Dock = DockStyle.Fill; // Teljesen kitölti a panelt
            panelContainer.Controls.Add(results);

        }
        private void QuestionsControl_FinishButtonClicked(object sender, EventArgs e)
        {
            // Amikor a felhasználó a következő gombra kattint
            QuestionsControl questionsControl = (QuestionsControl)sender;
            LoadResults();
        }
    }
}
