﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Uli
{
    public partial class Form1 : Form
    {
        private Queen queen;
        public Form1()
        {
            InitializeComponent();
            workerBeeJob.SelectedIndex = 0;
            Worker[] workers = new Worker[4];
            workers[0] = new Worker(new string[] { "Zbieranie nektaru", "Wytwarzanie miodu" });
            workers[1] = new Worker(new string[] { "Pielęgnacja jaj", "Nauczanie pszczółek" });
            workers[2] = new Worker(new string[] { "Utrzymanie ula", "Patrol z żądłami" });
            workers[3] = new Worker(new string[] { "Zbieranie nektaru", "Wytwarzanie miodu","Pielęgnacja jaj", "Nauczanie pszczółek", "Utrzymanie ula", "Patrol z żądłami" });
            queen = new Queen(workers);
        }

        private void assignJob_Click(Object sender, EventArgs e)
        {
            if (queen.AssignWork(workerBeeJob.Text, (int)shifts.Value) == false)
                MessageBox.Show("Nie ma dostępnych robotnic do wykonania zadania '" + workerBeeJob.Text + "'", "Królowa pszczół mówi...");
            else
                MessageBox.Show("Zadanie '" + workerBeeJob.Text + "' będzie ukończone za " + shifts.Value + " zmiany", " Królowa pszczół mówi...");

        }

        private void nextShift_Click(Object sender, EventArgs e)
        {
            report.Text = queen.WorkTheNextShift();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
