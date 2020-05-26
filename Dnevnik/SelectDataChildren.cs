using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiDiaryLibrary;
using Dnevnik.DnevnikClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dnevnik
{
    public partial class SelectDataChildren : Form
    {
        readonly List<List<int[]>> timeTable = new List<List<int[]>>()
        {
            new List<int[]>{ new int[] {9, 10, -1, -1}, new int[] { 11, 12, -1, -1}, new int[] {1,3,0,0 }, new int[] {4,5,0,0 } },
            new List<int[]>{ new int[] {9, 11, -1, -1}, new int[] { 12, 2, -1, 0}, new int[] {3,5,0,0 } },
            new List<int[]>{ new int[] {9, 12, -1, -1}, new int[] { 1, 5,0,0} }
        };

        readonly List<string> selectPeriodList = new List<string>()
        {
            { "Четверть"},
            { "Триместр"},
            { "Семестр" }
        };

        private bool updateDataBool = true;
        public bool closeWindow = false;
        public int indexChild = -1;
        public int indexGroup = -1;
        List<List<Persons>> persons;

        public SelectDataChildren(List<List<Persons>> persons, List<Groups> groups)
        {
            InitializeComponent();

            SetChildrens(persons, groups);
        }

        private void SelectList()
        {
            updateDataBool = false;

            int index = SelectPeriod.SelectedIndex;

            if (TypeYearList.SelectedIndex >= 0 && TypeYearList.SelectedIndex <= 2)
            {
                SelectPeriod.Enabled = true;
                SelectPeriod.Items.Clear();

                for (int i = 0; i < 4 - TypeYearList.SelectedIndex; i++)
                {
                    SelectPeriod.Items.Add($"{i + 1} {selectPeriodList[TypeYearList.SelectedIndex]}");
                }

                if (index == -1)
                    SelectPeriod.SelectedIndex = 0;
                else
                    SelectPeriod.SelectedIndex = index;

                int[] date = timeTable[TypeYearList.SelectedIndex][SelectPeriod.SelectedIndex];

                StartDate.Value = new DateTime(DateTime.UtcNow.Year + date[2], date[0], 1);

                try
                {
                    if (date[1] != 2)
                    {
                        if (date[1] % 2 == 0)
                            EndDate.Value = new DateTime(DateTime.UtcNow.Year + date[3], date[1], 31);
                        else
                            EndDate.Value = new DateTime(DateTime.UtcNow.Year + date[3], date[1], 30);
                    }
                    else
                    {
                        EndDate.Value = new DateTime(DateTime.UtcNow.Year + date[3], date[1], 28);
                    }
                }
                catch
                {
                    var dateTimeMax = DateTime.UtcNow;

                    EndDate.MaxDate = dateTimeMax;
                    EndDate.Value = dateTimeMax;
                }
            }
            else
            {
                SelectPeriod.Items.Clear();
                SelectPeriod.Enabled = false;
            }

            updateDataBool = true;
        }

        private void SetChildrens(List<List<Persons>> persons, List<Groups> groups)
        {
            foreach (Persons person in persons[persons.Count-1])
                Childrens.Items.Add(person.userName);

            foreach (Groups group in groups)
                studyYear.Items.Add($"{group.year}/{group.year + 1} {group.name}");

            Childrens.SelectedIndex = 0;
            studyYear.SelectedIndex = studyYear.Items.Count-1;

            this.persons = persons;
        }

        private void SelectDataChildren_Shown(object sender, EventArgs e)
        {
            TypeYearList.SelectedIndex = 0;
            SelectList();

            EndDate.MaxDate = DateTime.UtcNow;
        }

        private void TimetableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectPeriod.Enabled)
                SelectPeriod.SelectedIndex = 0;

            if (updateDataBool)
                SelectList();
        }

        private void SelectPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updateDataBool)
                SelectList();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            closeWindow = true;
            indexChild = Childrens.SelectedIndex;
            indexGroup = studyYear.SelectedIndex;
            this.Close();
        }

        private void StudyYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Childrens.Items.Clear();

            foreach (Persons person in persons[studyYear.SelectedIndex])
                Childrens.Items.Add(person.userName);
        }
    }
}
