using Android.Util;
using Java.Lang;
using String = System.String;

namespace XamarinIO
{
    public class LogUtils
    {
        private static String LOG_PREFIX = "iosched_";
        private static readonly int LogPrefixLength = LOG_PREFIX.Length;
        private static int MAX_LOG_TAG_LENGTH = 23;

        public static string MakeLogTag(string str)
        {
            if (str.Length > MAX_LOG_TAG_LENGTH - LogPrefixLength)
            {
                return LOG_PREFIX + str.Substring(0, MAX_LOG_TAG_LENGTH - LogPrefixLength - 1);
            }
            return LOG_PREFIX + str;
        }


    public static String MakeLogTag(System.Type type) {
        return MakeLogTag(type.Name);
    }

    public static void LogDebug( String tag, String message) {
        if (Log.IsLoggable(tag, LogPriority.Debug)) {
            Log.Debug(tag, message);
        }
    }

    public static void LogDebug( String tag, String message, Throwable cause) {
        if (Log.IsLoggable(tag, LogPriority.Debug)) {
            if (cause != null) Log.Debug(tag, message, cause);
        }
    }

    public static void LogVerbose( String tag, String message) {
        //noinspection PointlessBooleanExpression,ConstantConditions
        if (Config.Debug && Log.IsLoggable(tag, LogPriority.Verbose)) {
            Log.Verbose(tag, message);
        }
    }

    public static void LogVerbose(String tag, String message, Throwable cause)
    {
        //noinspection PointlessBooleanExpression,ConstantConditions
        if ( Config.Debug && Log.IsLoggable(tag, LogPriority.Verbose)) {
            if (cause != null) Log.Verbose(tag, message, cause);
        }
    }

    public static void LogInfo(String tag, String message)
    {
        Log.Info(tag, message);
    }

    public static void LogInfo( String tag, String message, Throwable cause) {
        Log.Info(tag, message, cause);
    }

    public static void LogWarn( String tag, String message) {
        Log.Warn(tag, message);
    }

    public static void LogWarn( String tag, String message, Throwable cause) {
        Log.Warn(tag, message, cause);
    }

    public static void LogError( String tag, String message) {
        Log.Error(tag, message);
    }

    public static void LogError( String tag, String message, Throwable cause) {
        Log.Error(tag, message, cause);
    }

    private LogUtils() {
    }
    }
}