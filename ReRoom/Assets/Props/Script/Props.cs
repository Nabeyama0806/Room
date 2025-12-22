using System.Collections;
using UnityEngine;

public enum ObjectType
{
    Normal,     //通常
    Anomaly,    //異常

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
    [SerializeField] Material[] m_materials;
    [SerializeField] bool m_isLock = false;

    public bool IsLock => m_isLock;

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

    //固定化されたときの共通処理
    public virtual void Lock()
    {
        m_isLock = true;
    }

    //ヒットしたときの共通処理
    public virtual void Hit()
    {
        //自身が削除されることを通知
        GameSceneManager.Instance.DeleteObject(m_type);

        //ディゾルブの開始
        StartCoroutine(Transition());
    }

    //ディゾルブ処理
    private IEnumerator Transition()
    {
        float duration = 0.5f;
        float elapsed = 0f;

        //ディゾルブの実行
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            float value = Mathf.Lerp(0, 1, t);

            foreach (var material in m_materials)
            {
                material.SetFloat("_t", value);
            }

            yield return null;
        }

        //マテリアルを元に戻す
        foreach (var material in m_materials)
        {
            material.SetFloat("_t", 0);
        }

        //自身の削除
        Destroy(gameObject);
    }
}