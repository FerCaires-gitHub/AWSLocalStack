namespace  AWS.DynamoDB.Interfaces{
    public interface IDataConnectionFactory<T>
    {
        T GetConnection();
    } 
}