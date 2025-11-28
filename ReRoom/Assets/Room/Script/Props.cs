using UnityEngine;

public enum ObjectType
{
    Normal,     //通常
    Anomaly,    //異常
    Lock,       //固定

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
