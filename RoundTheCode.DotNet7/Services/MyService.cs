namespace RoundTheCode.DotNet7.Services
{
    public class MyService : IMyService
    {
        public DateTime MyTime { get; }
        public MyService()
        {
            MyTime = DateTime.UtcNow;
        }
    }
}
