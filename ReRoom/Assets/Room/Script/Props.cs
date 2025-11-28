using UnityEngine;

public enum ObjectType
{
    Real, 
    Fake,
    Lock,

    Length,
}

public class Props : MonoBehaviour
{
    [SerializeField] ObjectType m_type;

    public ObjectType Type
    {
        get { return m_type; }
        set { m_type = value; }
    }

    public void Hit()
    {
        //自身が削除されることを通知
        GameSceneManager.Instance.DeleteObject(m_type);

        //オブジェクトを非表示にする
        gameObject.SetActive(false);
    }
}
