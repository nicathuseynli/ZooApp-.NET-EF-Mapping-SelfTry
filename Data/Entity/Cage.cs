namespace ZooApp_EF.Data.Entity;
public class Cage:BaseEntity<int>
{
    public int Code { get; set; }
    public int Capacity { get; set; }
    public int AnimalId { get; set; }
    //nav
    public virtual Zoo Zoo { get; set; }
    public virtual ICollection<Animal> Animals { get; set; }
}
