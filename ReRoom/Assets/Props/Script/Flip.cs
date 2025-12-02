using UnityEngine;

public class Flip : Props
{
    [SerializeField] Rotate m_rotate;

    protected override void StartExecute()
    {
        //オブジェクトを反転させる
        switch (m_rotate)
        {
            case Rotate.X:
                transform.Rotate(180f, 0f, 0f);
                break;

            case Rotate.Y:
                transform.Rotate(0f, 180f, 0f);
                break;

            case Rotate.Z:
                transform.Rotate(0f, 0f, 180f);
                break;
        }
    }
}
