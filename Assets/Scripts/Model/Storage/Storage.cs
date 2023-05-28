public abstract class Storage : IService
{
    public abstract void Write(LeaderboardData data);
    public abstract LeaderboardData Read();
}
