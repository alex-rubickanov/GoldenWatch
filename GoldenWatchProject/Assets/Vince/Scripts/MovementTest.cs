using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] Transform anchor;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform target;
    [SerializeField] float smoothRotationSpeed = 5f;
    [SerializeField] Transform playerPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
    }

    private void Movement()
    {
        float x = Input.GetAxis("RightHorizontal");
        float y = Input.GetAxis("RightVertical");

        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");

        Vector3 faceDirection = new Vector3(x, 0, y);
        faceDirection.Normalize();

        Vector3 movement = new Vector3(xMovement, 0, yMovement);
        movement.Normalize();
        playerPos.transform.Translate(movement * Time.deltaTime * speed);

        float currentRotationY = anchor.transform.localEulerAngles.y;
        if (currentRotationY > 180f)
        {
            currentRotationY -= 360f;
        }
        if (faceDirection != Vector3.zero)
        {
            anchor.transform.forward = faceDirection;
        }

        if (currentRotationY > 90f || currentRotationY < -90f)
        {
            if(y != 0 && x != 0) {
                Vector3 directionToTarget = target.position - transform.position;
                directionToTarget.y = 0; // Set Y axis to 0
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothRotationSpeed * Time.deltaTime);
            }
            
        }
        //print(currentRotationY);
    }

    void Shoot()
    {
        if (Input.GetAxis("Fire") > 0){
            GameObject bulletObj = Instantiate(bullet, anchor.transform.position, Quaternion.identity);
            bulletObj.GetComponent<Rigidbody>().velocity = anchor.transform.forward * 100f;
        }
     
    }
}
