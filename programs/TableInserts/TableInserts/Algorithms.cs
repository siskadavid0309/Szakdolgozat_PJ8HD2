using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableInserts;

namespace TableInserts
{
    public enum Mode
    {
        Genre,
        Keyword,
        Language,
        Director,
        Country
    }
    internal class Algorithms
    {
        public void CreateData(List<int> id, List<string> filteredList, List<Movie> movies, ref List<int> finalId, ref List<int> finalData, int mode)
        {
            List<string> tempData = new List<string>();
            CopyForCreateData(movies, ref tempData, mode);
            for (int i = 0; i < tempData.Count; i++)
            {
                for (int j = 0; j < id.Count; j++)
                {

                    if (tempData[i].Equals(filteredList[j]) || tempData[i].StartsWith(filteredList[j] + ",") || tempData[i].Contains(", " + filteredList[j] + ",") || tempData[i].EndsWith(" " + filteredList[j]))
                    {
                        finalId.Add(Convert.ToInt32(movies[i].Id));
                        finalData.Add(Convert.ToInt32(id[j]));
                    }
                }
            }
        }


        public List<string> Matches(List<string> list)
        {
            List<string> list_ok = new List<string>();
            bool match = false;
            for (int i = 0; i < list.Count; i++)
            {
                match = false;
                for (int j = 0; j < list_ok.Count; j++)
                {
                    if (list[i] == list_ok[j])
                    {
                        match = true;
                    }
                }
                if (match == false)
                {
                    list_ok.Add(list[i]);
                }

            }
            return list_ok;
        }

        public void GenerateId(ref List<int> id, List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                id.Add(i + 1);
            }
        }



        public static void CopyForCreateData(List<Movie> movies, ref List<string> tempData, int mode)
        {

            switch (mode)
            {
                case (int)Mode.Genre:
                    for (int i = 0; i < movies.Count; i++)
                    {
                        tempData.Add(movies[i].Genre);
                    }
                    break;
                case (int)Mode.Keyword:
                    for (int i = 0; i < movies.Count; i++)
                    {
                        tempData.Add(movies[i].Keywords);
                    }
                    break;
                case (int)Mode.Language:
                    for (int i = 0; i < movies.Count; i++)
                    {
                        tempData.Add(movies[i].Language);
                    }
                    break;
                case (int)Mode.Director:
                    for (int i = 0; i < movies.Count; i++)
                    {
                        tempData.Add(movies[i].Director);
                    }
                    break;
                case (int)Mode.Country:
                    for (int i = 0; i < movies.Count; i++)
                    {
                        tempData.Add(movies[i].Country);
                    }
                    break;

            }

        }
    }
}
