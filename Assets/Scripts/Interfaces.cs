public interface IDamagable
{
    void GetDamage(int damage);
}

public interface IDoDamage
{
    System.Collections.IEnumerator DoDamage(HealthManager healthManager, Bullet bullet);
}
