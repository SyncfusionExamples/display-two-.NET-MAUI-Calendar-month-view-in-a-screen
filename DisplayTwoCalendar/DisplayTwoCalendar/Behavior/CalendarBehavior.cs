using Syncfusion.Maui.Calendar;

namespace DisplayTwoCalendar
{
    public class CalendarBehavior : Behavior<ContentPage>
    {
        private SfCalendar calendar1, calendar2;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            calendar1 = bindable.FindByName<SfCalendar>("calendar1");
            calendar2 = bindable.FindByName<SfCalendar>("calendar2");
            calendar1.ViewChanged += Calendar1_ViewChanged;
            calendar2.ViewChanged += Calendar2_ViewChanged;
        }

        private void Calendar2_ViewChanged(object sender, CalendarViewChangedEventArgs e)
        {
            calendar1.DisplayDate = calendar2.DisplayDate.AddMonths(-1);
        }

        private void Calendar1_ViewChanged(object sender, CalendarViewChangedEventArgs e)
        {
            calendar2.DisplayDate = calendar1.DisplayDate.AddMonths(1);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.calendar1 != null)
            {
                calendar1.ViewChanged -= Calendar1_ViewChanged;
            }
            
            if (this.calendar2 != null)
            {
                calendar2.ViewChanged -= Calendar2_ViewChanged;
            }

            this.calendar1 = this.calendar2 = null;
        }
    }
}
