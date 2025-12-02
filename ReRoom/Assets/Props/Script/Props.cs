using UnityEngine;

public enum ObjectType
{
    Normal,     //通常
    Anomaly,    //異常
    Lock,       //固定

    Length,
}

public enum Rotate
{
    X,
    Y,
    Z,

    Length,
}

public class Props : MonoBehaviour
{
    [SerializeField] ObjectType m_type = ObjectType.Normal;

    public ObjectType Type
    {
        get { return m_type; }
        set { m_type = value; }
    }

    private void Start()
    {
        //異変オブジェクトでなければ処理を行わない
        if (Type != ObjectType.Anomaly) return;

        //異変の種類に応じた処理を実行
        StartExecute();
    }

    private void FixedUpdate()
    {
        //異変オブジェクトでなければ処理を行わない
        if (Type != ObjectType.Anomaly) return;

        //異変の種類に応じた処理を更新
        UpdateExecute();
    }

    //異変の種類に応じた処理を派生先で定義
    protected virtual void StartExecute() { }

    protected virtual void UpdateExecute() { }

    //ヒットしたときの共通処理
    public virtual void Hit()
    {
        //自身が削除されることを通知
        GameSceneManager.Instance.DeleteObject(m_type);

        //オブジェクトを非表示にする
        gameObject.SetActive(false);
    }
}