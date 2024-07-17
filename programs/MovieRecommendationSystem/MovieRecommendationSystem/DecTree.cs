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
    public partial class DecTree : Form
    {
        public DecTree()
        {
            InitializeComponent();
        }

        static void ParseNode(List<string> dot, JToken node, string parentName)
        {
            if (node.Type == JTokenType.Object)
            {
                var conditionArray = node["condition"] as JArray;
                if (conditionArray != null)
                {
                    foreach (var conditionObject in conditionArray)
                    {
                        var condition = conditionObject["condition"]?.ToString();
                        var outcome = conditionObject["outcome"];

                        if (condition != null && outcome != null)
                        {
                            if (outcome.Type == JTokenType.Object)
                            {
                                string nodeName = Guid.NewGuid().ToString();
                                dot.Add($"    \"{parentName}\" -> \"{nodeName}\" [label=\"{condition}\"];");
                                dot.Add($"    \"{nodeName}\" [label=\"{outcome["node"]}\"];");
                                ParseNode(dot, outcome, nodeName);
                            }
                            else if (outcome.Type == JTokenType.Array)
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
            else if (node.Type == JTokenType.Array)
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

        public void MainJson()
        {
            
            string json =  CreateJsonPath();
            json=File.ReadAllText( json );

            
            JObject jsonObj = JObject.Parse(json);

            var dot = new List<string>
            {
                "digraph DecisionTree {"
            };

            dot.Add($"    \"root\" [label=\"{jsonObj["decision_tree"]["root"]["node"]}\"];");
            ParseNode(dot, jsonObj["decision_tree"]["root"], "root");

            dot.Add("}");

            File.WriteAllLines("decision_tree.dot", dot);

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "dot",
                Arguments = "-Tpng decision_tree.dot -o decision_tree.png",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                process.WaitForExit();
            }

            PictureBox pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = Image.FromFile("decision_tree.png"),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            this.Controls.Add(pictureBox);
        }

        private void DecTree_Load(object sender, EventArgs e)
        {
            MainJson();
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