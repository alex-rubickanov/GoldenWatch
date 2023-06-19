using UnityEngine;



public class IsometricAiming : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] Transform anchor;
    [SerializeField] Transform targetSight;
    [SerializeField] Transform playerBody;
    [SerializeField] float smoothRotationSpeed = 5f;

    private Camera mainCamera;


    private void Start()
    {
        Cursor.visible = false;
        // Cache the camera, Camera.main is an expensive operation.
        mainCamera = Camera.main;
    }

    private void Update()
    {
        RotateKB();
    }


    private void Aim()
        {
        var (success, position) = GetMousePosition();
        if (success) {
            // Calculate the direction
            var direction = position - transform.position;

            // You might want to delete this line.
            // Ignore the height difference.
            direction.y = 0;

            // Make the transform look in the direction.
            transform.forward = direction;
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask)) {
            // The Raycast hit something, return with the position.
             return (success: true, position: hitInfo.point);
        } else {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }


    private void RotateKB()
    {
        Vector3 mousePos = GetMousePosition().position;

        Vector3 faceDirection = new Vector3(mousePos.x, 0, mousePos.z);
        faceDirection.Normalize();

        float currentRotationY = anchor.transform.localEulerAngles.y;
        if (currentRotationY > 180f) {
            currentRotationY -= 360f;
        }
        if (faceDirection != Vector3.zero) {
            anchor.transform.forward = faceDirection;
        }

        if (currentRotationY > 90f || currentRotationY < -90f) {
            if (mousePos.x != 0 && mousePos.y != 0) {
                Vector3 directionToTarget = targetSight.position - playerBody.position;
                directionToTarget.y = 0; // Set Y axis to 0
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                playerBody.rotation = Quaternion.Slerp(playerBody.rotation, targetRotation, smoothRotationSpeed * Time.deltaTime);
            }
        }
    }
}
