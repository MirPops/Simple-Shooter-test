using UnityEngine;

// ������� ����� ��� ������� ��������
public abstract class ShootingSystem : MonoBehaviour
{
    [SerializeField] protected Transform startPointBullet;

    protected abstract void Shoot();
    protected abstract void Reload();
}