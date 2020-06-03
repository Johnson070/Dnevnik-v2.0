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
        //readonly List<List<int[]>> timeTable = new List<List<int[]>>()
        //{
        //    new List<int[]>{ new int[] {9, 10, -1, 0}, new int[] { 11, 12, -1, 0}, new int[] {1,3,0,1 }, new int[] {4,5,0,1 } },
        //    new List<int[]>{ new int[] {9, 11, -1, 0}, new int[] { 12, 2, -1, 1}, new int[] {3,5,0,1 } },
        //    new List<int[]>{ new int[] {9, 12, -1, 0}, new int[] { 1, 5,0,1} }
        //};

        readonly List<string> selectPeriodList = new List<string>()
        {
            { "Другое"},
            { "Семестр"},
            { "Триместр" },
            { "Четверть"  }
        };

        private bool updateDataBool = true;
        private bool updateSchoolmates = false;
        private int incYearType = 0;
        public bool closeWindow = false;
        public int indexChild = -1;
        public int indexChildGroup = -1;
        public int indexGroup = -1;
        public bool updateYear = false;
        List<List<Persons>> persons;
        List<List<Groups>> groups;
        List<List<Persons>> members;

        public SelectDataChildren(List<List<Persons>> persons, List<List<Persons>> members, List<List<Groups>> groups)
        {
            InitializeComponent();

            SetChildrens(persons, members, groups);
        }

        private void SelectList()
        {
            updateDataBool = false;

            int index = SelectPeriod.SelectedIndex;

            if (TypeYearList.SelectedIndex >= 1 && TypeYearList.SelectedIndex <= 3)
            {
                SelectPeriod.Enabled = true;
                //SelectPeriod.Items.Clear();

                //for (int i = 0; i < 4 - TypeYearList.SelectedIndex; i++)
                //{
                //    SelectPeriod.Items.Add($"{i + 1} {selectPeriodList[TypeYearList.SelectedIndex]}");
                //}

                //if (index == -1)
                //    SelectPeriod.SelectedIndex = 0;
                //else
                //    SelectPeriod.SelectedIndex = index;

                //int[] date = timeTable[TypeYearList.SelectedIndex][SelectPeriod.SelectedIndex];

                //StartDate.Value = new DateTime((groups[Childrens.SelectedIndex][studyYear.SelectedIndex].year + date[3]), date[0], 1, 0, 0, 1);

                //try
                //{
                //    if (date[1] != 2)
                //    {
                //        if (date[1] % 2 == 0)
                //            EndDate.Value = new DateTime(groups[Childrens.SelectedIndex][studyYear.SelectedIndex].year + date[3], date[1], 31);
                //        else
                //            EndDate.Value = new DateTime(groups[Childrens.SelectedIndex][studyYear.SelectedIndex].year + date[3], date[1], 30);
                //    }
                //    else
                //    {
                //        EndDate.Value = new DateTime(groups[Childrens.SelectedIndex][studyYear.SelectedIndex].year - date[3], date[1], 28);
                //    }
                //}
                //catch
                //{
                //    var dateTimeMax = DateTime.UtcNow;

                //    EndDate.MaxDate = dateTimeMax;
                //    EndDate.Value = dateTimeMax;
                //}

                UpdateTypeYear();

                TypeYearList.SelectedIndex = groups[Childrens.SelectedIndex][studyYear.SelectedIndex].subGroups.Count- incYearType;
                SelectPeriod.Items.Clear();

                foreach (SubGroups subGroup in groups[Childrens.SelectedIndex][studyYear.SelectedIndex].subGroups)
                    SelectPeriod.Items.Add(subGroup.name);

                if (index is -1 || SelectPeriod.Items.Count - 1 < index)
                    SelectPeriod.SelectedIndex = 0;
                else
                    SelectPeriod.SelectedIndex = index;

                DateTime maxDate = groups[Childrens.SelectedIndex][studyYear.SelectedIndex].subGroups[SelectPeriod.SelectedIndex].endTime;
                DateTime minDate = groups[Childrens.SelectedIndex][studyYear.SelectedIndex].subGroups[SelectPeriod.SelectedIndex].startDate;

                if (maxDate > DateTime.UtcNow)
                    maxDate = DateTime.UtcNow;

                try
                {
                    StartDate.MinDate = minDate;
                    StartDate.MaxDate = maxDate;
                    EndDate.MinDate = minDate;
                    EndDate.MaxDate = maxDate;
                }
                catch
                {
                    StartDate.MaxDate = maxDate;
                    StartDate.MinDate = minDate;
                    EndDate.MaxDate = maxDate;
                    EndDate.MinDate = minDate;
                }

                StartDate.Value = minDate;
                EndDate.Value = maxDate;
            }
            else
            {
                StartDate.MinDate = new DateTime(2000, 01, 01);
                StartDate.MaxDate = DateTime.UtcNow;
                EndDate.MinDate = new DateTime(2000, 01, 01);
                EndDate.MaxDate = DateTime.UtcNow;
                SelectPeriod.Items.Clear();
                SelectPeriod.Enabled = false;
            }

            updateDataBool = true;
        }

        private void UpdateTypeYear()
        {
            TypeYearList.Items.Clear();

            for (int i = 0; i < selectPeriodList.Count; i++)
                if (i == groups[Childrens.SelectedIndex][studyYear.SelectedIndex].subGroups.Count - 1)
                {
                    incYearType = i;
                    TypeYearList.Items.Add(selectPeriodList[i]);
                }
                else if (i is 0)
                    TypeYearList.Items.Add(selectPeriodList[i]);
        }

        private void SetChildrens(List<List<Persons>> persons, List<List<Persons>> members, List<List<Groups>> groups)
        {
            foreach (Persons person in members[members.Count - 1])
                Childrens.Items.Add(person.userName);

            foreach (Persons person in persons[persons.Count - 1])
                schoolmates.Items.Add(person.userName);

            foreach (Groups group in groups[0])
                studyYear.Items.Add($"{group.year}/{group.year + 1} {group.name}");

            schoolmates.SelectedIndex = 0;
            Childrens.SelectedIndex = 0;
            studyYear.SelectedIndex = studyYear.Items.Count - 1;

            this.persons = persons;
            this.groups = groups;
            this.members = members;

            UpdateTypeYear();

            updateYear = true;
            updateSchoolmates = true;
        }

        private void SelectDataChildren_Shown(object sender, EventArgs e)
        {
            TypeYearList.SelectedIndex = 1;
            SelectList();
        }

        private void TimetableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (SelectPeriod.Enabled)
            //    SelectPeriod.SelectedIndex = 0;

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
            indexChild = schoolmates.SelectedIndex;
            indexGroup = studyYear.SelectedIndex;
            indexChildGroup = Childrens.SelectedIndex;
            this.Close();
        }

        private void StudyYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updateYear)
            {
                schoolmates.Items.Clear();

                foreach (Persons person in persons[studyYear.SelectedIndex])
                    schoolmates.Items.Add(person.userName);

                schoolmates.SelectedIndex = 0;

                //SelectPeriod.SelectedIndex = 0;

                SelectList();
            }
        }

        private void Childrens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updateSchoolmates)
            {
                foreach (Persons person in members[Childrens.SelectedIndex])
                    schoolmates.Items.Add(person.userName);

                schoolmates.SelectedIndex = 0;
            }

        }
    }
}
