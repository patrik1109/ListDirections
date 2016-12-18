using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace ListDirections.Models
{
    public enum ProcState { HaveToRun, Running, Success, Fail, Unknown }

    public class MainProcess 
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        
        public string WorkingDir { get; set; }
        
        public string FinalScript { get; set; }

        private Schedule[] _schedules = null;
        public Schedule[] Process_Schedule
        {
            get
            {
                if (_schedules == null) _schedules = ContextProcess.Object.Schedules.Where(s => s.ProcessID == ID).ToArray();
                return _schedules; 
            }
        }

        private History[] _history = null;
        public History[] Process_History
        {
            get
            {
                if (_history == null) _history = ContextProcess.Object.Historys.Where(s => s.ProcessID == ID).ToArray();
                return _history;
            }
        }

        private PreRequisite[] _steps = null;
        public PreRequisite[] StepsToRun
        {
            get
            {
                if (_steps == null) _steps = ContextProcess.Object.PreRequisites.Where(p => p.ProcessID == ID).ToArray();
                return _steps;
            }
        }

        public DateTime PlanDate
        {
            get
            {
                if (Process_Schedule.Length == 0) return DateTime.Now;

                List<DateTime> dates = new List<DateTime>();
                foreach (Schedule sch in Process_Schedule)
                {
                    if (sch.DayOfMonth.HasValue)
                    {
                        DateTime dt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, sch.DayOfMonth.Value, sch.Hour, sch.Minute, 0);
                        if (dt > DateTime.Now) dt = dt.AddMonths(-1);
                        dates.Add(dt);
                    }
                    if (sch.DayOfWeek.HasValue)
                    {
                        DateTime dt = DateTime.Today.AddDays(sch.DayOfWeek.Value - (int)DateTime.Today.DayOfWeek).AddHours(sch.Hour).AddMinutes(sch.Minute);
                        if (dt > DateTime.Now) dt = dt.AddDays(-7);
                        dates.Add(dt);
                    }
                }
                return dates.Max();
            }
        }

        private History[] _current_state = null;
        public History[] Current_State
        {
            get
            {
                if (_current_state == null) _current_state = ContextProcess.Object.Historys.Where(h => h.TimeStart > PlanDate && h.ProcessID == ID).ToArray();
                return _current_state;
            }
        }
        
        public ProcState CurrentStateName
        {
            get
            {
                History procState = Current_State.FirstOrDefault(h => h.EventID == 0);
                if (procState == null) return ProcState.HaveToRun;
                if (procState.TimeFinish.HasValue)
                {
                    if (procState.Success.HasValue)
                    {
                        return procState.Success.Value ? ProcState.Success : ProcState.Fail;
                    }
                    return ProcState.Unknown;
                }
                return ProcState.Running;
            }
        }

        public PreRequisite CurrentStep
        {
            get
            {
                switch (CurrentStateName)
                {
                    case ProcState.HaveToRun:
                        return StepsToRun.OrderBy(p => p.StepOrder).FirstOrDefault();
                    case ProcState.Running:
                        throw new NotImplementedException();
                    default:
                        return null;
                }  
            }
        }

        public History CurrentResult
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}