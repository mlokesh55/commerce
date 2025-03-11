namespace commerce.Aspects
{
    public class CartNotFoundException : ApplicationException
    {
        public CartNotFoundException() { }
        public CartNotFoundException(string msg) : base(msg) { }
    }
}
