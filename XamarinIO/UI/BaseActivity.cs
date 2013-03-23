
using System;
using ActionbarSherlock.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Content;
using Uri = Android.Net.Uri;

namespace XamarinIO
{
	public class BaseActivity:SherlockFragmentActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			//TODO: Add Google tracker
			//TODO: ADD beam functionality

			SupportActionBar.SetHomeButtonEnabled(true);
		}

		public override bool OnOptionsItemSelected (ActionbarSherlock.View.IMenuItem item)
		{
			switch (item.ItemId) {
			case Android.Resource.Id.Home:
				if (this is HomeActivity) {
					return false;
				}

				NavUtils.NavigateUpFromSameTask(this);
				return true;
			}

			return base.OnOptionsItemSelected(item);
		}


		/// <summary>
		/// Sets the color of the action bar.
		/// </summary>
		/// <param name="color">Color.</param>
		protected void SetActionBarColor(Color color)
		{
			Resources res = this.Resources;
			var maskDrawable = res.GetDrawable(Resource.Drawable.actionbar_icon_mask) as BitmapDrawable;
			if (maskDrawable == null) {
				return;
			}

			var maskBitmap = maskDrawable.Bitmap;
			int width = maskBitmap.Width;
			int height = maskBitmap.Height;

			var outBitmap = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
			Canvas canvas = new Canvas(outBitmap);
			canvas.DrawBitmap(maskBitmap, 0,0,null);

			var maskedPaint = new Paint();
			maskedPaint.Color = color;
			maskedPaint.SetXfermode(new PorterDuffXfermode( PorterDuff.Mode.SrcAtop));

			canvas.DrawRect(0,0, width, height, maskedPaint);
			var outDrawable = new BitmapDrawable(res, outBitmap);
			SupportActionBar.SetIcon(outDrawable);
		}

		/// <summary>
		/// Intents to fragment argument.
		/// </summary>
		/// <returns>The to fragment argument.</returns>
		/// <param name="intent">Intent.</param>
		public static Bundle IntentToFragmentArgument(Intent intent)
		{
			Bundle arguments = new Bundle();
			if (intent  == null) {
				return arguments;
			}

			var data = intent.Data;
			if (data!=null) {
				arguments.PutParcelable("_uri", data);
			}

			var extras = intent.Extras;
			if (extras != null) {
				arguments.PutAll(intent.Extras);
			}

			return arguments;
		}

		/// <summary>
		/// Fragments the arguments to intent.
		/// </summary>
		/// <returns>The arguments to intent.</returns>
		/// <param name="arguments">Arguments.</param>
		public static Intent FragmentArgumentsToIntent(Bundle arguments) {
			Intent intent = new Intent();
			if (arguments == null) {
				return intent;
			}
			
			var data = arguments.GetParcelable("_uri") as Uri;
			if (data != null) {
				intent.SetData(data);
			}
			
			intent.PutExtras(arguments);
			intent.RemoveExtra("_uri");
			return intent;
		}

		protected override void OnStart ()
		{
			base.OnStart ();
			//TODO: Add tracker code
		}

		protected override void OnStop ()
		{
			base.OnStop();
			//TODO: Add tracker code
		}
	}
}

