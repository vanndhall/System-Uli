using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Uli
{
    class Worker
    {
        #region BUILDER
        public Worker(string[] jobsICanDo)
        {
            this.jobsICanDo = jobsICanDo;
        }
        #endregion

        #region PROPERTIES
        public int ShiftsLeft //pozostałe zmiany
        { 
            get
                { return shiftsToWork - shiftsWorked; }
        }
        public string CurrentJob
        {
            get
                { return currentJob; }
        }
        


        #endregion

        #region VARIABLES
        private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;
        private string currentJob = "";
        #endregion

        #region METHODS
        //Metoda do przypisywania nowych zadań przez Queen, sprawdza ich pole jobsICanDo aby okreslic,
        //czy dana pszczoła potrafi wykonywać ten rodzaj pracy
        public bool DoThisJob(string job, int numberOfShifts)
        {

            if (!String.IsNullOrEmpty(currentJob)) // guard
                return false;                       //

            for (int i = 0; i < jobsICanDo.Length; i++)
                if(jobsICanDo[i] == job)
                {
                    currentJob = job;
                    this.shiftsToWork = numberOfShifts;
                    shiftsWorked = 0;
                    return true;
                }


            return false;
        }
       

        //Metoda do nakazania im rozpoczecie kolejnej zmian;
        //Zwraca ona true tylko wtedy, gdy jest to naprawdę ostatnia zmiana z przeznaczonych na wykonanie zleconej pracy.
        //Dzięki temu królowa może dodać do rapotu linijkę i poinformować, że pszczoła po tej zmianie zakończy swoją pracę.
        public bool DidYouFinish()
        {
            if (String.IsNullOrEmpty(currentJob))  //Guard
                return false;                       //

            shiftsWorked++;
            if (shiftsWorked > shiftsToWork)
            {
                shiftsWorked = 0;
                shiftsToWork = 0;
                currentJob = "";
                return true;

            }

            else
                return false;
        }



        #endregion


    }
}
