using UnityEngine;
using UnityEngine.InputSystem;

public class ActionsManager : MonoBehaviour
{
    [SerializeField] Transform _spawnAttackPosition;
    [SerializeField] Weapon _weaponPrefab;
    private InputActions _controls;

    // ################# INITIALISATION ####################

    private void Awake()
    {
        _controls = new InputActions();
        _controls.Player.Shoot.performed += Shoot;
    }


    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    // #################### UPDATE ###############################"

    // ################### METHODS #############################"

    private void Shoot(InputAction.CallbackContext obj)
    {
        Debug.Log("We shot");
        Coins weapon = Instantiate(_weaponPrefab, _spawnAttackPosition.position, Quaternion.identity) as Coins;
        weapon.GetComponent<Rigidbody2D>().AddForce(new Vector2(weapon.ForceX,weapon.ForceY));
        Debug.Log("Damage " + weapon.Damage);
        Destroy(weapon.gameObject, 3f);
    }

}