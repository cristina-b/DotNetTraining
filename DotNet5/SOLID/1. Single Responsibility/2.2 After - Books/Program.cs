namespace SingleResponsibilityBooksAfter
{
    public class Program
    {
        static void main()
        {
            Book book1 = new Book();
            book.Title = "Prima carte";
            book.Author = "Autor";
            book.Location = "Libraria din colt";

            BookManager<Books> bookManager = new BookManager<Books>();
            bookManager.Add(book1);

            book.page = 180;
            book.TurnPages();
        }
    }
}