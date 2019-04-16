using Microsoft.LightSwitch;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace LightSwitchApplication
{
    public partial class cfr_issuedLetter
    {
        static private int _InternalCounter = 0;
        partial void cfr_issuedLetter_Created()
        {
            this.letterGuid = UniqueID();
        }
        private string UniqueID()
        {
            var now = DateTime.Now;
            var days = (int)(now - new DateTime(2018, 01, 01)).TotalDays;
            var seconds = (int)(now - DateTime.Today).TotalSeconds;
            var counter = _InternalCounter++ % 100;
            return days.ToString("00000") + seconds.ToString("00000") + counter.ToString("00");
        }
    }
}