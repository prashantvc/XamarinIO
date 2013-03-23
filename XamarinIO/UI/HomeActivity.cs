namespace XamarinIO.UI
{
    public class HomeActivity
    {
        public HomeActivity()
        {
            _tag = LogUtils.MakeLogTag(typeof(HomeActivity));
            
        }

        private string _tag = string.Empty;
        private object syncObserverHandle;
    }
}