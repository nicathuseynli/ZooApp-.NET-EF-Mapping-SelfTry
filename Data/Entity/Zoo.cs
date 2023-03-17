namespace ZooApp_EF.Data.Entity;
public class Zoo:BaseEntity<int>
{
    public string Name { get; set; }=string.Empty;
    public int CageId { get; set; }
    public virtual ICollection<Cage> Cages { get; set; }
}
