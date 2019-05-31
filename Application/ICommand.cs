namespace Application
{
    public interface ICommand<TRequest, TResult>
    {
        TResult Execute(TRequest request);
    }
}