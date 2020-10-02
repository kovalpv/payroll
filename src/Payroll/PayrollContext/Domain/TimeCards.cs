using System.Collections.Generic;
using System.Linq;

namespace Payroll.PayrollContext.Domain {
    public class TimeCards {
        private readonly List<TimeCard> timeCards;
        public TimeCards (IEnumerable<TimeCard> timeCards) {
            IEnumerable<TimeCard> timeCardsInitial = timeCards != null ? timeCards : Enumerable.Empty<TimeCard> ();
            this.timeCards = new List<TimeCard> (timeCardsInitial);
        }

        private IEnumerable<TimeCard> FilterByPeriod (Period period) {
            return timeCards.Where (timeCard => timeCard.IsIn (period));
        }

        public int RegularWorkHours (Period period) {
            return FilterByPeriod (period)
                .Select (timeCard => timeCard.RegularWorkHours)
                .Sum ();
        }

        public int OvertimeWorkHours (Period period) {
            return FilterByPeriod (period)
                .Select (timeCard => timeCard.OvertimeWorkHours)
                .Sum ();
        }
    }
}