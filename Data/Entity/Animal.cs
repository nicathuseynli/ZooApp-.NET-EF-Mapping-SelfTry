namespace ZooApp_EF.Data.Entity;
public class Animal:BaseEntity<int>
{
    public string Name { get; set; }=string.Empty;
    public string Type { get; set; }=string.Empty ;
    //nav
    public virtual Cage Cage { get; set; }
}
