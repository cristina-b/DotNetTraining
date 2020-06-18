namespace SingleResponsibilityBooksAfter
{
    public class Program
    {
        static void main()
        {
            Book book1 = new Book();
            book1.Title = "Prima carte";
            book1.Author = "Autor";
            book1.Location = 23;

            Book book2 = new Book();
            book2.Title = "A 2-a carte";
            book2.Author = "Another Author";
            book2.Location = 25;

            BookManager<Book> bookManager = new BookManager<Book>();
            bookManager.Add(book1);
            bookManager.Add(book2);

            book1.pageManager.page = 20;
            book1.pageManager.TurnPage();
        }
    }
}