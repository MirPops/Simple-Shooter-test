using UnityEngine;

public class InputsManager : MonoBehaviour
{
    public static event System.Action OnShoot;
    public static event System.Action OnReload;
    public static event System.Action<float> OnSwapWeapon;
    public static event System.Action<Vector3> OnCharacterMove;
    public static event System.Action<int> OnPressNumber;
    public static event System.Action<float> OnRotateCharacterY;
    public static event System.Action<float> OnRotateCharacterX;

    private Vector3 movement;

    private void Update()
    {
        // Передвижение по wsda или стрелкам
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        OnCharacterMove?.Invoke(movement);

        // Движения мыши
        OnRotateCharacterY(Input.GetAxis("Mouse X"));
        OnRotateCharacterX(Input.GetAxis("Mouse Y"));
        
        // Нажатия отдельных клавиш
        if (Input.GetKey(KeyCode.Mouse0))
        {
            OnShoot?.Invoke();
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            OnSwapWeapon?.Invoke(Input.GetAxis("Mouse ScrollWheel"));
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnReload?.Invoke();
        }

        // Свап оружия по кнопкам
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnPressNumber?.Invoke(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnPressNumber?.Invoke(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            OnPressNumber?.Invoke(2);
        }
    }
}