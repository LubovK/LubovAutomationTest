using Twitter.Maps;


namespace Twitter.Common
{
    public class MapFactories
    {
        /// <summary>
        /// Properties
        /// </summary>
        public HomePageMap HomePage;
        public FeedMap Feed;
        public LoginMap LoginPage;
        public SettingsMap Settings;
        
        /// <summary>
        /// Constructor to initialize all maps
        /// </summary>
        public MapFactories()
        {
            SetMaps();
        }

        /// <summary>
        /// Set/initialize all maps
        /// </summary>
        private void SetMaps()
        {
            HomePage = new HomePageMap();
            Feed = new FeedMap();
            LoginPage = new LoginMap();
            Settings = new SettingsMap();
        }
    }
}
