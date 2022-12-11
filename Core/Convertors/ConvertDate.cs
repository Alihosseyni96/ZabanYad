using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Convertors
{
	public static class ConvertDate
	{
		public static string ToShamsi(this DateTime dateTime)
		{
			PersianCalendar pc = new PersianCalendar();
			string persianDate = pc.GetYear(dateTime) + "/" + pc.GetMonth(dateTime).ToString("00") + "/" +
				pc.GetDayOfMonth(dateTime).ToString("00");

            return persianDate;

		}
	}
}
