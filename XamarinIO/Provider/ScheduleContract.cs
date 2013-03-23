using System;

namespace XamarinIO.Provider
{
    public class ScheduleContract
    {
        public static class BlocksColumns
        {
            /** Unique string identifying this block of time. */
            String BLOCK_ID = "block_id";
            /** Title describing this block of time. */
            String BLOCK_TITLE = "block_title";
            /** Time when this block starts. */
            String BLOCK_START = "block_start";
            /** Time when this block ends. */
            String BLOCK_END = "block_end";
            /** Type describing this block. */
            String BLOCK_TYPE = "block_type";
            /** Extra string metadata for the block. */
            String BLOCK_META = "block_meta";
        }

        public static class Blocks : BlocksColumns
        {

        }
    }
}