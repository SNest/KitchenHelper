using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using SupportToolBar = Android.Support.V7.Widget.Toolbar;
using Android.Graphics;
using RestSharp;
using Fudger.Models;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Fudger;

namespace ToolbarOverlay_Tutorial
{
	[Activity (Label = "ToolbarOverlay_Tutorial", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/Theme.MyTheme")]
	public class MainActivity : ActionBarActivity, ViewTreeObserver.IOnScrollChangedListener
	{
		private const int FULLY_VISIBLE_AT = 2;
		private SupportToolBar mToolbar;
		private ScrollView mScrollView;
		private int mScreenHeight;



		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			mToolbar = FindViewById<SupportToolBar>(Resource.Id.toolbar);
			mScrollView = FindViewById<ScrollView>(Resource.Id.scrollView);

			SetSupportActionBar(mToolbar);

			Point size = new Point();
			Display display = WindowManager.DefaultDisplay;
			display.GetSize(size);
			mScreenHeight = size.Y;

			mScrollView.ViewTreeObserver.AddOnScrollChangedListener(this);


			string localPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Fudger");

			//Directory with your DB3 file
			var dirx = Android.OS.Environment.ExternalStorageDirectory.ToString();

			// DB File 
			var dbfile = dirx + "/Fudger/kh_sql_lite.db";



			if (File.Exists(dbfile))
			{

				File.Copy(dbfile, localPath, true);
				Toast.MakeText(this, "SQLiteDB copied successfully!", ToastLength.Long).Show();


			}
			else
			{
				Toast.MakeText(this, "copy from " + System.Environment.NewLine + "to " + localPath + " failed or source file is missing!", ToastLength.Long).Show();
			}
		}

		public float GetOpacity()
		{
			float fullVisibleAtPx = mScreenHeight /FULLY_VISIBLE_AT;

			float alpha = mScrollView.ScrollY / fullVisibleAtPx;

			if (alpha > 1)
			{
				return 1;
			}

			else if (alpha < 0)
			{
				return 0;
			}

			return alpha;
		}

		public void OnScrollChanged()
		{
			mToolbar.SetBackgroundColor(Color.Argb((int)(GetOpacity() * 255), 255, 0, 0));
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.action_menu, menu);
			return base.OnCreateOptionsMenu (menu);
		}
	}
}


