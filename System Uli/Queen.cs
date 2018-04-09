using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace System_Uli
{
    class Queen
    {
        #region Konstruktor

        public Queen(Worker[] workers)
        {
            this.workers = workers; 
        }

        #endregion

        #region Pola
        private Worker[] workers;
        private int shiftNumber = 0;  //numer zmiany
        #endregion

        #region Metody

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

        #endregion


    }
}