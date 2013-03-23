using System;
using ActionbarSherlock.App;
using Android.Content;
using Android.Database;
using Android.Provider;
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
                string type = cursor.GetString(BlocksQuery.BLOCK_TYPE);
                string blockId = cursor.GetString(BlocksQuery.BLOCK_ID);
                string blockTitle = cursor.GetString(BlocksQuery.BLOCK_TITLE);
                long blockStart = cursor.GetLong(BlocksQuery.BLOCK_START);
                long blockEnd = cursor.GetLong(BlocksQuery.BLOCK_END);
                string blockMeta = cursor.GetString(BlocksQuery.BLOCK_META);

                //TODO: Fix it 
                //String blockTimeString = UIUtils.FormatBlockTimeString(blockStart, blockEnd,
                //    context);


            }

            public override View NewView(Context context, ICursor cursor, ViewGroup parent)
            {
                var inflater = LayoutInflater.FromContext(context);
                return inflater.Inflate(Resource.Layout.list_item_schedule_block, parent, false);
            }

            private class BlocksQuery
            {
                public static String[] _projection =
                    {
                        BaseColumns.Id,
                        BlocksColumns.BLOCK_ID,
                        BlocksColumns.BLOCK_TITLE,
                        BlocksColumns.BLOCK_START,
                        BlocksColumns.BLOCK_END,
                        BlocksColumns.BLOCK_TYPE,
                        BlocksColumns.BLOCK_META,
                        Blocks.SESSIONS_COUNT,
                        Blocks.NUM_STARRED_SESSIONS,
                        Blocks.STARRED_SESSION_ID,
                        Blocks.STARRED_SESSION_TITLE,
                        Blocks.STARRED_SESSION_ROOM_NAME,
                        Blocks.STARRED_SESSION_ROOM_ID,
                        Blocks.STARRED_SESSION_HASHTAGS,
                        Blocks.STARRED_SESSION_URL,
                        Blocks.STARRED_SESSION_LIVESTREAM_URL
                    };

                public static int _ID = 0;
                public static int BLOCK_ID = 1;
                public static int BLOCK_TITLE = 2;
                public static int BLOCK_START = 3;
                public static int BLOCK_END = 4;
                public static int BLOCK_TYPE = 5;
                public static int BLOCK_META = 6;
                public static int SESSIONS_COUNT = 7;
                public static int NUM_STARRED_SESSIONS = 8;
                public static int STARRED_SESSION_ID = 9;
                public static int STARRED_SESSION_TITLE = 10;
                public static int STARRED_SESSION_ROOM_NAME = 11;
                public static int STARRED_SESSION_ROOM_ID = 12;
                public static int STARRED_SESSION_HASHTAGS = 13;
                public static int STARRED_SESSION_URL = 14;
                public static int STARRED_SESSION_LIVESTREAM_URL = 15;
            }
        }


    }
}