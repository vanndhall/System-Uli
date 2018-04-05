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
        public int ShiftsLeft
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
        public bool DoThisJob(string job, int numberOfShifts)
        {

            if (!String.IsNullOrEmpty(currentJob)) // guard
                return false;
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
       



        #endregion


    }
}
