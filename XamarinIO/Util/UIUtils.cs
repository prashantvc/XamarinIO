using System;
using Zone = Java.Util.TimeZone;
using Android.OS;

namespace XamarinIO
{
	public class UIUtils
	{
		public static Zone ConferenceTimeZone = Zone.GetTimeZone("America/Los_Angeles");

		public static bool HasICS() {
			return	Build.VERSION.SdkInt >= BuildVersionCodes.IceCreamSandwich;
		}
	}
}

