namespace MedInfoSystem.Services.Exceptions
{
    public class NotFoundUser : Exception
    {
        public NotFoundUser(string message) : base(message) { }
    }
}
