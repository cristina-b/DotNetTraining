using System.Collections.Generic;

namespace SingleResponsibilityBooksAfter
{
    public class PageManager
    {        
        public int page { get; set; }        

        public PageManager()
        {
            this.page = 0;
        }

        public string BookFinished(int page)
        {
            return "Finished reading the book";
        }

        public void TurnPage()
        {
            ++this.page;
        }
    }
}