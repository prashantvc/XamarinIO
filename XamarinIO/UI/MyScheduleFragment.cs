using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActionbarSherlock.App;
using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinIO.Provider;

namespace XamarinIO.UI
{
    public class MyScheduleFragment : SherlockListFragment
    {

        class MyScheduleAdapter : CursorAdapter
        {
            public MyScheduleAdapter(Context context)
                : base(context, null, false)
            {

            }

            public override void BindView(View view, Context context, ICursor cursor)
            {
                throw new NotImplementedException();
            }

            public override View NewView(Context context, ICursor cursor, ViewGroup parent)
            {
                var inflater = LayoutInflater.FromContext(context);
                return inflater.Inflate(Resource.Layout.list_item_schedule_block, parent, false);
            }


            String[] PROJECTION = {
                BaseColumns._ID,
                ScheduleContract.Blocks.BLOCK_ID,
                ScheduleContract.Blocks.BLOCK_TITLE,
                ScheduleContract.Blocks.BLOCK_START,
                ScheduleContract.Blocks.BLOCK_END,
                ScheduleContract.Blocks.BLOCK_TYPE,
                ScheduleContract.Blocks.BLOCK_META,
                ScheduleContract.Blocks.SESSIONS_COUNT,
                ScheduleContract.Blocks.NUM_STARRED_SESSIONS,
                ScheduleContract.Blocks.STARRED_SESSION_ID,
                ScheduleContract.Blocks.STARRED_SESSION_TITLE,
                ScheduleContract.Blocks.STARRED_SESSION_ROOM_NAME,
                ScheduleContract.Blocks.STARRED_SESSION_ROOM_ID,
                ScheduleContract.Blocks.STARRED_SESSION_HASHTAGS,
                ScheduleContract.Blocks.STARRED_SESSION_URL,
                ScheduleContract.Blocks.STARRED_SESSION_LIVESTREAM_URL,
        };
        }
    }
}