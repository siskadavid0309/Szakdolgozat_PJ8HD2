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
        public void CreateData(List<int> id, List<string> list_ok, List<Movie> movies, ref List<int> finalID, ref List<int> finalData, int mode)
        {
            List<string> tempData = new List<string>();
            Copy(movies, ref tempData, mode);
            for (int i = 0; i < tempData.Count; i++)
            {
                for (int j = 0; j < id.Count; j++)
                {

                    if (tempData[i].Equals(list_ok[j]) || tempData[i].StartsWith(list_ok[j] + ",") || tempData[i].Contains(", " + list_ok[j] + ",") || tempData[i].EndsWith(" " + list_ok[j]))
                    {
                        finalID.Add(Convert.ToInt32(movies[i].Id));
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



        public static void Copy(List<Movie> movies, ref List<string> tempData, int mode)
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
