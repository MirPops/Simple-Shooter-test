// Для обьектов которые могут получать дэмэдж
public interface IDamagable
{
    void GetDamage(int damage);
}

// Для оружия которое наносит урон нетипичным образом (например на протяжении времени)
public interface IDoDamage
{
    System.Collections.IEnumerator DoDamage(HealthManager healthManager, Bullet bullet);
}
