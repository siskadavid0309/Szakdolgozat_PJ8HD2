using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MovieRecommendationSystem
{
    public partial class HandmadeLanguageDecTree : Form
    {
        public HandmadeLanguageDecTree()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Rekurzív metódus, amellyel a JSON fájlból a döntési fa csomópontonként kerül feldolgozásra
        /// </summary>
        /// <param name="dot">A string lista, amiből majd a dot fájl készül</param>
        /// <param name="node">Az éppen aktuálisan feldolgozott csomópont</param>
        /// <param name="parentName">Az adott csomópont szülője</param>
        static void ParseNode(List<string> dot, JToken node, string parentName)
        {
            if (node.Type == JTokenType.Object)
            {
                var conditionArray = node["condition"] as JArray;
                if (conditionArray != null)
                {
                    foreach (var conditionObject in conditionArray)
                    {
                        var condition = conditionObject["condition"]?.ToString(); // Lekéri a feltétel szövegét
                        var outcome = conditionObject["outcome"]; // Lekéri a kimeneti objektumot

                        if (condition != null && outcome != null)
                        {
                            if (outcome.Type == JTokenType.Object) // Ha a kimenetel objektum, akkor egy új csomópont
                            {
                                string nodeName = Guid.NewGuid().ToString();
                                dot.Add($"    \"{parentName}\" -> \"{nodeName}\" [label=\"{condition}\"];");
                                dot.Add($"    \"{nodeName}\" [label=\"{outcome["node"]}\"];");
                                ParseNode(dot, outcome, nodeName);
                            }
                            else if (outcome.Type == JTokenType.Array) // Ha a kimenet egy tömb, akkor minden elemet külön kezel
                            {
                                foreach (var item in outcome)
                                {
                                    string leafName = Guid.NewGuid().ToString();
                                    dot.Add($"    \"{parentName}\" -> \"{leafName}\" [label=\"{condition}\"];");
                                    dot.Add($"    \"{leafName}\" [label=\"{item}\", shape=box];");
                                }
                            }
                            else
                            {
                                string leafName = Guid.NewGuid().ToString();
                                dot.Add($"    \"{parentName}\" -> \"{leafName}\" [label=\"{condition}\"];");
                                dot.Add($"    \"{leafName}\" [label=\"{outcome}\", shape=box];");
                            }
                        }
                    }
                }
            }
            else if (node.Type == JTokenType.Array) //Ha az aktuális csomópont tömb, akkor szintén minden elemet külön dolgoz fel
            {
                foreach (var item in node)
                {
                    ParseNode(dot, item, parentName);
                }
            }
            else
            {
                string leafName = Guid.NewGuid().ToString();
                dot.Add($"    \"{parentName}\" -> \"{leafName}\" [label=\"\"];");
                dot.Add($"    \"{leafName}\" [label=\"{node}\", shape=box];");
            }
        }

        /// <summary>
        /// A döntési fa felépítéséhez szükséges változók létrehozása, föggvények meghívása
        /// </summary>
        public void MainJson()
        {

            string json = CreateJsonPath();
            json = File.ReadAllText(json);


            JObject jsonObj = JObject.Parse(json);

            var dot = new List<string>
            {
                "digraph DecisionTree {"
            };

            dot.Add($"    \"root\" [label=\"{jsonObj["decision_tree"]["root"]["node"]}\"];");
            ParseNode(dot, jsonObj["decision_tree"]["root"], "root");

            dot.Add("}");

            File.WriteAllLines("decision_tree.dot", dot); //A dot string lista tartalmából készít egy .dot fájlt

            ProcessStartInfo startInfo = new ProcessStartInfo //Graphviz parancsok amelyek segítségével a .dot fájlból .png kép készül
            {
                FileName = "dot",
                Arguments = "-Tpng decision_tree.dot -o decision_tree.png",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo)) //A folyamat indítása
            {
                process.WaitForExit();
            }

            PictureBox pictureBox = new PictureBox //PictureBox használata a kép megjelenítéséhez
            {
                Dock = DockStyle.Fill,
                Image = Image.FromFile("decision_tree.png"),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            this.Controls.Add(pictureBox);
        }


        public string CreateJsonPath()
        {

            string jsonFileName = "decision_tree_language.json";
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string jsonPath = Path.Combine(currentDirectory, jsonFileName);
            return jsonPath;

        }
    }
}