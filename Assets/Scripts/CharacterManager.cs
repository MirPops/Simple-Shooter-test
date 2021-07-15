using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;

    private void Start()
    {
        healthManager.OnDead += Die;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
