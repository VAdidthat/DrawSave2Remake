using UnityEngine;

public class RotateBehavior : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(eulers: Vector3.forward * -600f * Time.deltaTime);
    }
}
