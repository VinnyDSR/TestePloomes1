using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePloomes
{

    public class RespostaDoCriarNovaTask
    {
        public string odatacontext { get; set; }
        public TasksGET[] value { get; set; }
    }
    public class TasksGET
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public object DealId { get; set; }
        public object RepeatIntervalLength { get; set; }
        public int RepeatIntervalUnitId { get; set; }
        public object EmailReminderId { get; set; }
        public DateTime DateTime { get; set; }
        public object EndTime { get; set; }
        public bool NoTime { get; set; }
        public object Length { get; set; }
        public bool Finished { get; set; }
        public bool Editable { get; set; }
        public bool Finishable { get; set; }
        public bool CreatesGoogleCalendarEvent { get; set; }
        public object Address { get; set; }
        public object Latitude { get; set; }
        public object Longitude { get; set; }
        public object InteractionRecordId { get; set; }
        public object OriginTaskId { get; set; }
        public int CreatorId { get; set; }
        public object UpdaterId { get; set; }
        public object FinisherId { get; set; }
        public object FinishDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

    }



}