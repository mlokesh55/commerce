using commerce.Models;
namespace commerce.Exceptions
{
    public class CartAlreadyExistsException : ApplicationException
    {
        public CartAlreadyExistsException() { }
        public CartAlreadyExistsException(string msg) : base(msg) { }
    }
}
