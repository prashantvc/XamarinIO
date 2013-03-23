using System;
using Android.Runtime;
using Android.Text.Format;
using Uri = Android.Net.Uri;

namespace XamarinIO.Provider
{
    public class ScheduleContract
    {



    }

    public class BlocksColumns
    {
        [Register("_ID")]
        public const string Id = "_id";

        [Register("_COUNT")]
        public const string Count = "_count";

        /** Unique string identifying this block of time. */
        public static String BLOCK_ID = "block_id";
        /** Title describing this block of time. */
        public static String BLOCK_TITLE = "block_title";
        /** Time when this block starts. */
        public static String BLOCK_START = "block_start";
        /** Time when this block ends. */
        public static String BLOCK_END = "block_end";
        /** Type describing this block. */
        public static String BLOCK_TYPE = "block_type";
        /** Extra string metadata for the block. */
        public static String BLOCK_META = "block_meta";
    }

    public class Blocks : BlocksColumns
    {

        private static String PATH_BLOCKS = "blocks";
        private static String PATH_AT = "at";
        private static String PATH_BETWEEN = "between";
        private static String PATH_TRACKS = "tracks";
        private static String PATH_ROOMS = "rooms";
        private static String PATH_SESSIONS = "sessions";
        private static String PATH_WITH_TRACK = "with_track";
        private static String PATH_STARRED = "starred";
        private static String PATH_SPEAKERS = "speakers";
        private static String PATH_VENDORS = "vendors";
        private static String PATH_ANNOUNCEMENTS = "announcements";
        private static String PATH_SEARCH = "search";
        private static String PATH_SEARCH_SUGGEST = "search_suggest_query";

        public static String CONTENT_AUTHORITY = "com.google.android.apps.iosched";

        public static Uri BASE_CONTENT_URI = Uri.Parse("content://" + CONTENT_AUTHORITY);


        public static Uri CONTENT_URI =
              BASE_CONTENT_URI.BuildUpon().AppendPath(PATH_BLOCKS).Build();

        public static String CONTENT_TYPE =
                "vnd.android.cursor.dir/vnd.iosched.block";
        public static String CONTENT_ITEM_TYPE =
                "vnd.android.cursor.item/vnd.iosched.block";

        /** Count of {@link Sessions} inside given block. */
        public static String SESSIONS_COUNT = "sessions_count";

        /**
         * Flag indicating the number of sessions inside this block that have
         * {@link Sessions#SESSION_STARRED} set.
         */
        public static String NUM_STARRED_SESSIONS = "num_starred_sessions";

        /**
         * The {@link Sessions#SESSION_ID} of the first starred session in this
         * block.
         */
        public static String STARRED_SESSION_ID = "starred_session_id";

        /**
         * The {@link Sessions#SESSION_TITLE} of the first starred session in
         * this block.
         */
        public static String STARRED_SESSION_TITLE = "starred_session_title";

        /**
         * The {@link Sessions#SESSION_LIVESTREAM_URL} of the first starred
         * session in this block.
         */
        public static String STARRED_SESSION_LIVESTREAM_URL =
                "starred_session_livestream_url";

        /**
         * The {@link Rooms#ROOM_NAME} of the first starred session in this
         * block.
         */
        public static String STARRED_SESSION_ROOM_NAME = "starred_session_room_name";

        /**
         * The {@link Rooms#ROOM_ID} of the first starred session in this block.
         */
        public static String STARRED_SESSION_ROOM_ID = "starred_session_room_id";

        /**
         * The {@link Sessions#SESSION_HASHTAGS} of the first starred session in
         * this block.
         */
        public static String STARRED_SESSION_HASHTAGS = "starred_session_hashtags";

        /**
         * The {@link Sessions#SESSION_URL} of the first starred session in this
         * block.
         */
        public static String STARRED_SESSION_URL = "starred_session_url";

        /** Default "ORDER BY" clause. */
        public static String DEFAULT_SORT = BlocksColumns.BLOCK_START + " ASC, "
                + BlocksColumns.BLOCK_END + " ASC";

        public static String EMPTY_SESSIONS_SELECTION = "(" + BLOCK_TYPE
                + " = '" + ParserUtils.BLOCK_TYPE_SESSION + "' OR " + BLOCK_TYPE
                + " = '" + ParserUtils.BLOCK_TYPE_CODE_LAB + "') AND "
                + SESSIONS_COUNT + " = 0";

        /** Build {@link Uri} for requested {@link #BLOCK_ID}. */
        public static Uri BuildBlockUri(String blockId)
        {
            return CONTENT_URI.BuildUpon().AppendPath(blockId).Build();
        }

        /**
         * Build {@link Uri} that references any {@link Sessions} associated
         * with the requested {@link #BLOCK_ID}.
         */
        public static Uri BuildSessionsUri(String blockId)
        {
            return CONTENT_URI.BuildUpon().AppendPath(blockId).AppendPath(PATH_SESSIONS).Build();
        }

        /**
         * Build {@link Uri} that references starred {@link Sessions} associated
         * with the requested {@link #BLOCK_ID}.
         */
        public static Uri BuildStarredSessionsUri(String blockId)
        {
            return CONTENT_URI.BuildUpon().AppendPath(blockId).AppendPath(PATH_SESSIONS)
                    .AppendPath(PATH_STARRED).Build();
        }

        /**
         * Build {@link Uri} that references any {@link Blocks} that occur
         * between the requested time boundaries.
         */
        public static Uri BuildBlocksBetweenDirUri(long startTime, long endTime)
        {
            return CONTENT_URI.BuildUpon().AppendPath(PATH_BETWEEN).AppendPath(
                    startTime.ToString()).AppendPath(endTime.ToString()).Build();
        }

        /** Read {@link #BLOCK_ID} from {@link Blocks} {@link Uri}. */
        public static String getBlockId(Uri uri)
        {
            return uri.PathSegments[1];
        }

        /**
         * Generate a {@link #BLOCK_ID} that will always match the requested
         * {@link Blocks} details.
         */
        public static String GenerateBlockId(long startTime, long endTime)
        {
            startTime /= DateUtils.SecondInMillis;
            endTime /= DateUtils.SecondInMillis;
            return ParserUtils.SanitizeId(startTime + "-" + endTime);
        }
    }

}