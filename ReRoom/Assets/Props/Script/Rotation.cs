using UnityEngine;

public class Rotation : Props
{
    [SerializeField] Rotate m_rotate;
    [SerializeField] float m_speed = 9;

    protected override void UpdateExecute()
    {
        Vector3 axis = Vector3.zero;

        // enum ‚Ì’l‚É‰‚¶‚Ä‰ñ“]²‚ğ‘I‘ğ
        switch (m_rotate)
        {
            case Rotate.X:
                axis = Vector3.right;
                break;

            case Rotate.Y:
                axis = Vector3.up;
                break;

            case Rotate.Z:
                axis = Vector3.forward;
                break;
        }

        // ‰ñ“]ˆ—
        transform.Rotate(axis * m_speed * Time.deltaTime);
    }
}
