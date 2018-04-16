using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace System_Uli
{
    class Queen : Bee
    {
        #region BUILDER

        public Queen(Worker[] workers,double weightMg): base(weightMg)
        {
            this.workers = workers;
            
        }

        #endregion

        #region VERIABLES
        private Worker[] workers;
        private int shiftNumber = 0;  //numer zmiany
        #endregion

        #region METHODS

            //przypisz pracę(praca , numer zmiany)
        public bool AssignWork(string job, int numberOfShifts) 
        {
            for(int i = 0; i< workers.Length; i++)
            {
                if (workers[i].DoThisJob(job, numberOfShifts))
                    return true;
            }
            return false;
        }

        //pracować na następnej zmianie


        //Metoda WorkTheNextShift() obiektu Queen nakazuje każdej robotnicy pracować przez jedną zmianę i dodać wiersz do raportu w zależności do jej statusu.
        public string WorkTheNextShift()
        {
            double honeyConsumed = HoneyConsumptionRate();
            shiftNumber++;
            string report = "Raport zmiany numer " + shiftNumber + "\r\n";
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].DidYouFinish())
                    report += "Robotnica numer " + (i + 1) + " zakończyła swoje zadanie\r\n";
                if (String.IsNullOrEmpty(workers[i].CurrentJob))
                    report += "Robotnica numer" + (i + 1) + "nie pracuje\r\n";
                else
                    if (workers[i].ShiftsLeft > 0)
                    report += "Robotnica numer " + (i + 1) + "robi '" + workers[i].CurrentJob
                        + "' jeszcze przez " + workers[i].ShiftsLeft + " zmiany\r\n";
                else
                    report += "Robotnica numer " + (i + 1) + " zakończy '" + workers[i].CurrentJob + "' po tej zmianie\r\n";

            }
            report += "Całkowite spożycie miodu: " + honeyConsumed + " jednostek\r\n";
            return report;
        }
        #endregion


    }
}