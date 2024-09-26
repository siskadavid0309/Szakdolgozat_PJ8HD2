using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem
{
    internal class LoadQuestions
    {
        public List<Question> questionsList = new List<Question>();
        

        public void AddToQuestionsList(Question question)
        {
            questionsList.Add(question);
        }
    }
}
