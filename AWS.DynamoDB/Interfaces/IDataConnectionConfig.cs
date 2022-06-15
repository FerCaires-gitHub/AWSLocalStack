namespace AWS.DynamoDB.Interfaces{

    public interface IDataConnectionConfig<T>
    {
        T GetSettings();
    }
}