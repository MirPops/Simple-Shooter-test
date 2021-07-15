using UnityEngine;

// Контейнер для хранения инфы о оружие
[CreateAssetMenu(fileName = "New Weapon Stats", menuName = "WeaponStats", order = 51)]
public class WeaponStats : ScriptableObject
{
    [SerializeField] private int baseDamage;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float timeReload;
    [SerializeField] private float rateOfFire;
    [SerializeField] private float range;
    [SerializeField] private float spread;
    [SerializeField] private int maxClipAmount;
    [SerializeField] private float speedOfBullet;
    [SerializeField] private Color color;

    public int BaseDamage { get => baseDamage; }
    public int MaxClipAmount { get => maxClipAmount; }
    public float TimeReload { get => timeReload; }
    public float RateOfFire { get => rateOfFire; }
    public float Range { get => range; }
    public float Spread { get => spread; }
    public float SpeedOfBullet { get => speedOfBullet; }
    public GameObject Bullet { get => bullet; }
    public Color Color { get => color; }
}
