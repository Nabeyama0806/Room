using UnityEngine;

public class Rotation : Props
{
    [SerializeField] GameObject m_target;
    [SerializeField] Rotate m_rotate;
    [SerializeField] float m_speed = 9;

    protected override void UpdateExecute()
    {
        //‰ñ“]²‚ğ‘I‘ğ
        Vector3 axis = Vector3.zero;
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

        //‰ñ“]ˆ—
        m_target.transform.Rotate(axis * m_speed * Time.deltaTime);
    }
}
