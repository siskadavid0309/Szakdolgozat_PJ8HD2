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
    public enum Features
    {
        Genre, Keyword, Released, Runtime, GenderOfProtagonist, MainActor, Director, Language, Country, TmdbScore, Popularity, Blockbuster

    }
    public partial class SetPriority : UserControl
    {
        public event EventHandler NextButtonClicked;
        private List<PriorityListItem> originalList = new List<PriorityListItem>();
        private List<PriorityListItem> selectedList = new List<PriorityListItem>();
        public SetPriority()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Elem átmozgatása az originalList-ból a selectedList-be
        /// </summary>
        private void MoveSelectedItem()
        {
            if (listBoxOriginal.SelectedItem != null) //Ellenőrizzük hogy van-e kiválasztva elem
            {
                PriorityListItem selectedItem = (PriorityListItem)listBoxOriginal.SelectedItem; //A kiválasztott elem eltárolása
                originalList.Remove(selectedItem); //Az elem törlése korábbi helyéről
                selectedList.Add(selectedItem); //Az elem hozzáadása az új listához
                RefreshListBoxes(); //A listák tartalmait megjelenítő listboxok frissítése a változtatások megjelenítéséhez
            }
        }

        private void RefreshListBoxes()
        {
            listBoxOriginal.DataSource = null;
            listBoxOriginal.DataSource = originalList;

            listBoxSelected.DataSource = null;
            listBoxSelected.DataSource = selectedList;
            UpdatePriorities();
        }

        /// <summary>
        /// Modosítások után az elemek prioritásainak frissítése a sorrend alapján
        /// </summary>
        private void UpdatePriorities()
        {
            for (int i = 0; i < selectedList.Count; i++)
            {
                selectedList[i].Priority = i; // Minél előrébb (a listboxban fentebb) van egy lista, annál alacsonyabb értéket kap, ami pedig magasabb prioritást jelent
            }
        }

        private void SetPriority_Load(object sender, EventArgs e)
        {
            originalList.Add(new PriorityListItem { Id = (int)Features.Genre, Title = "Genres of a movie", Priority = 0 });
            originalList.Add(new PriorityListItem { Id = (int)Features.Keyword, Title = "Keywords of a movie", Priority = 0 });
            originalList.Add(new PriorityListItem { Id = (int)Features.Released, Title = "Release year of a movie", Priority = 0 });
            originalList.Add(new PriorityListItem { Id = (int)Features.Runtime, Title = "Runtime of a movie", Priority = 0 });
            originalList.Add(new PriorityListItem { Id = (int)Features.GenderOfProtagonist, Title = "Gender of the protagonist", Priority = 0 });
            originalList.Add(new PriorityListItem { Id = (int)Features.MainActor, Title = "Main actress/actor of a movie", Priority = 0 });
            originalList.Add(new PriorityListItem { Id = (int)Features.Director, Title = "Director of a movie", Priority = 0 });
            originalList.Add(new PriorityListItem { Id = (int)Features.Language, Title = "Language of a movie", Priority = 0 });
            originalList.Add(new PriorityListItem { Id = (int)Features.TmdbScore, Title = "Tmdb score of a movie", Priority = 0 });
            originalList.Add(new PriorityListItem { Id = (int)Features.Popularity, Title = "Popularity of a movie", Priority = 0 });
            originalList.Add(new PriorityListItem { Id = (int)Features.Country, Title = "Production country of a movie", Priority = 0 });
            originalList.Add(new PriorityListItem { Id = (int)Features.Blockbuster, Title = "The movie should be a blockbuster", Priority = 0 });

            listBoxOriginal.DataSource = new BindingSource(originalList, null);
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            MoveSelectedItem();
        }

        private void MoveAllItems()
        {
            selectedList.AddRange(originalList);
            originalList.Clear();
            RefreshListBoxes();
        }

        private void MoveBackAllItems()
        {
            originalList.AddRange(selectedList);
            selectedList.Clear();
            RefreshListBoxes();
        }

        private void MoveBackSelectedItem()
        {
            if (listBoxSelected.SelectedItem != null)
            {
                PriorityListItem selectedItem = (PriorityListItem)listBoxSelected.SelectedItem;
                selectedList.Remove(selectedItem);
                originalList.Add(selectedItem);
                RefreshListBoxes();
            }
        }
        /// <summary>
        /// A kiválasztott elem felfelé mozgatása a listboxban a magasabb prioritás érdekében
        /// </summary>
        private void MoveUp()
        {
            int selectedIndex = listBoxSelected.SelectedIndex; //A kiválasztott elem indexét eltároljuk
            if (selectedIndex > 0) //Ellenőrizzük hogy nem e 0, hiszen ha igen, akkor az azt jelenti hogy a lista tetején van, tehát nem lehet fentebb mozgatni
            {
                var item = selectedList[selectedIndex]; //Egy átmeneti változóban tároljuk a mozgatni kívánt elemet
                selectedList.RemoveAt(selectedIndex); //A listából töröljük az elemet a korábbi helyéről
                selectedList.Insert(selectedIndex - 1, item); //Beszúrjuk az átmenetileg eltárolt elemet eggyel kisebb index használatával, így a listboxban eggyel feljebb kerül
                RefreshListBoxes(); // A listboxok frissítése
                listBoxSelected.SelectedIndex = selectedIndex - 1; // Miután az elem megjelent eggyel feljebb a listboxban, átvisszük rá a kijelölést is, hogy ne az alatta lévő elem maradjon kijelölve.
            }
        }

        private void MoveDown()
        {
            int selectedIndex = listBoxSelected.SelectedIndex;
            if (selectedIndex < selectedList.Count - 1)
            {
                var item = selectedList[selectedIndex];
                selectedList.RemoveAt(selectedIndex);
                selectedList.Insert(selectedIndex + 1, item);
                RefreshListBoxes();
                listBoxSelected.SelectedIndex = selectedIndex + 1;
            }
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            MoveUp();
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            MoveDown();
        }

        private void buttonMoveAll_Click(object sender, EventArgs e)
        {
            MoveAllItems();
        }

        private void buttonMoveBack_Click(object sender, EventArgs e)
        {
            MoveBackSelectedItem();
        }

        private void buttonMoveBackAll_Click(object sender, EventArgs e)
        {
            MoveBackAllItems();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (NextButtonClicked != null && selectedList.Count != 0)
            {
                NextButtonClicked(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Select at least one item from the list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<PriorityListItem> GetSelectedList()
        {
            return selectedList;
        }
    }
}
