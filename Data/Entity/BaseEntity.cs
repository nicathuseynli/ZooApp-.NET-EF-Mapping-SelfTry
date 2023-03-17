namespace ZooApp_EF.Data.Entity;
public class BaseEntity<T>
{
    public virtual T Id { get; set; }
}
