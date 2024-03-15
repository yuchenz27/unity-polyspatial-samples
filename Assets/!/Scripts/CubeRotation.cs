using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField] private float m_Speed = 30f;

    private void Update()
    {
        transform.Rotate(0f, m_Speed * Time.deltaTime, 0f, Space.Self);
    }
}
