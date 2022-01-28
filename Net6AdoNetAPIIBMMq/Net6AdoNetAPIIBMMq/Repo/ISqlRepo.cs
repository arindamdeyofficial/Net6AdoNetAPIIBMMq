namespace Net6AdoNetAPIIBMMq.Repo
{
    public interface ISqlRepo
    {
        public IEnumerable<string> RunQuery();
    }
}
