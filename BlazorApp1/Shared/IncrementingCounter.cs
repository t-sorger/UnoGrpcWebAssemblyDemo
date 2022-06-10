namespace BlazorApp1.Shared
{
    public class IncrementingCounter
    {
        public int Count { get; private set; }

        public void Increment(int amount)
        {
            Count += amount;
        }
    }
}