using System.Collections.Generic;

namespace PatientPortal.API.SPA.ViewModels
{
    public class ScheduleUserViewModel
    {
        public UserViewModel UserViewModel { get; set; }
        public List<ScheduleViewModel> lstScheduleViewModel { get; set; }
    }
}