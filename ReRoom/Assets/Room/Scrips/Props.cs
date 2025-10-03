using UnityEngine;

public enum ObjectType
{
    Real,
    Fake,

    Length,
}

public class Props : MonoBehaviour
{
    [SerializeField] ObjectType m_type;

    public ObjectType Type => m_type;

    public void Hit()
    { 
        switch(m_type)
        {
            case ObjectType.Real:
               GameSceneManager.Instance.GameOver();
                break;

            case ObjectType.Fake:
                GameSceneManager.Instance.DeleteFake();
                break;
        }

        //オブジェクトを非表示にする
        gameObject.SetActive(false);
    }
}
