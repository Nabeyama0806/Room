using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Shaking : Props
{
    [SerializeField] Material m_material;
    [SerializeField] float amplitude = 0.05f;       //基本揺れ幅
    [SerializeField] float speed = 1.2f;            //規則的揺れ速度
    [SerializeField] float noiseSpeed = 3.5f;       //不規則揺れ速度
    [SerializeField] float jitter = 0.02f;          //突発的なガタつき
    [SerializeField] float rotationAmount = 3f;     //Z回転の揺れ

    [SerializeField] float minHeight = 0f;          //地面の最低高さ

    private Vector3 basePos;

    void Start()
    {
        basePos = transform.localPosition;  //初期位置を保持
    }

    protected override void UpdateExecute()
    {
        float t = Time.time;

        //規則的な揺れ
        float pingX = Mathf.PingPong(t * speed, amplitude * 2) - amplitude;
        float pingY = Mathf.PingPong(t * speed * 0.8f, amplitude * 2) - amplitude;

        //不規則な揺れ
        float noiseX = (Mathf.PerlinNoise(t * noiseSpeed, 0) - 0.5f) * amplitude * 2;
        float noiseY = (Mathf.PerlinNoise(0, t * noiseSpeed) - 0.5f) * amplitude * 2;

        //突発的なガタつき
        float jitterX = (Random.value - 0.5f) * jitter;
        float jitterY = (Random.value - 0.5f) * jitter;

        //合成
        float x = pingX * 0.5f + noiseX * 0.7f + jitterX;
        float y = pingY * 0.5f + noiseY * 0.7f + jitterY;

        //下限を超えないように補正
        float finalY = Mathf.Max(basePos.y + y, minHeight);

        //Z回転の不規則な揺れ
        float rot = Mathf.Sin(t * speed * 1.3f) * rotationAmount;
        rot += (Mathf.PerlinNoise(t * noiseSpeed, t * noiseSpeed) - 0.5f) * rotationAmount;

        //適用
        transform.localPosition = basePos + new Vector3(x, finalY - basePos.y, 0);
        transform.localRotation = Quaternion.Euler(0, 0, rot);
    }

    public override void Hit()
    {
        //自身が削除されることを通知
        GameSceneManager.Instance.DeleteObject(Type);

        //ディゾルブの開始
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            float value = Mathf.Lerp(0, 1, t);
            m_material.SetFloat("_t", value);

            yield return null;
        }

        //マテリアルを元に戻す
        m_material.SetFloat("_t", 0);

        //自身の削除
        Destroy(gameObject);
    }

}
