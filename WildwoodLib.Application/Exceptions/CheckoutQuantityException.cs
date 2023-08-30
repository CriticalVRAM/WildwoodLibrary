namespace WildwoodLib.Application.Exceptions
{
    public class CheckoutQuantityException : Exception
    {
        public CheckoutQuantityException()
            : base("Book quantity less then current checkouts.")
        {

        }
    }
}
