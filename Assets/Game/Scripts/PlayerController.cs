using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 9.8f;

    [SerializeField] private GameObject _muzzleFlash;


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        Movement();
        CursorManager();
        FireWeapon();
        
    }

    void CursorManager()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Cursor.visible && Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;

        velocity = transform.TransformDirection(velocity);
        _agent.Move(velocity * Time.deltaTime);
    }

    void FireWeapon()
    {
        //Left click? cast ray from center point of mc

        if (Input.GetMouseButtonDown(0))
        {
            _muzzleFlash.SetActive(true);
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            if(Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log($"Raycast hit {hitInfo.transform.name}");
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _muzzleFlash.SetActive(false);
        }
    }

    
}
