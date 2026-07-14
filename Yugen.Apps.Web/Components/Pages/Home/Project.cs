namespace Yugen.Apps.Web.Components.Pages.Home;

public partial class Home
{
    public class Project
    {
		public int Id { get; set; }
        
        public string ImageSrc { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public Link[] Links { get; set; }
    }

}
