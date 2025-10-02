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
                SceneController.Transition(SceneType.Game, SceneType.Result);
                break;

            case ObjectType.Fake:
                GameSceneManager.Instance.DeleteFake();
                break;
        }

        //オブジェクトを非表示にする
        gameObject.SetActive(false);
    }
}
