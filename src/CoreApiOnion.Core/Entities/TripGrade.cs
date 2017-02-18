using System;

namespace CoreApiOnion.Core.Entities
{
    public class TripGrade
    {
        public Guid CustomerId { get; set; }
        public Guid StaffId { get; set; }
        public string LetterScore { get; set; }
        public decimal NumericalScore { get; set; }
        public string ParameterName { get; set; }
        public DateTime Date { get; set; }
    }
}
