using UnityEngine;

public class CameraDolly2D : MonoBehaviour
{
    public Transform target;

    // The Y coordinate that the camera will sit on
    [SerializeField] private float dollyHeight = 0f;
    
    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, dollyHeight, -5f);
    }
}
