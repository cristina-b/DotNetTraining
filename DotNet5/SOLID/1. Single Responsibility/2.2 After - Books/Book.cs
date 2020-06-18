namespace SingleResponsibilityBooksAfter
{
    public class Book
   {
        public PageManager pageManager = new PageManager();

        public string Title { get; set; }

        public string Author { get; set; }

        public int Location { get; set; }        
    }
}