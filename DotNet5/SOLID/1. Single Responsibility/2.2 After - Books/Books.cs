namespace SingleResponsibilityBooksAfter
{
    public class Book
   {
        public PageManager page = new PageManager();

        public string Title { get; set; }

        public string Author { get; set; }

        public int Location { get; set; }
        
    }
}