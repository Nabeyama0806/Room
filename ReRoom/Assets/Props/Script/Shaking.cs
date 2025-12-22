using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Shaking : Props
{
    [SerializeField] float amplitude = 0.05f;       //Šî–{—h‚ê•
    [SerializeField] float speed = 1.2f;            //‹K‘¥“I—h‚ê‘¬“x
    [SerializeField] float noiseSpeed = 3.5f;       //•s‹K‘¥—h‚ê‘¬“x
    [SerializeField] float jitter = 0.02f;          //“Ë”­“I‚ÈƒKƒ^‚Â‚«
    [SerializeField] float rotationAmount = 3f;     //Z‰ñ“]‚Ì—h‚ê

    [SerializeField] float minHeight = 0f;          //’n–Ê‚ÌÅ’á‚‚³

    private Vector3 basePos;

    void Start()
    {
        basePos = transform.localPosition;  //‰ŠúˆÊ’u‚ğ•Û
    }

    protected override void UpdateExecute()
    {
        float t = Time.time;

        //‹K‘¥“I‚È—h‚ê
        float pingX = Mathf.PingPong(t * speed, amplitude * 2) - amplitude;
        float pingY = Mathf.PingPong(t * speed * 0.8f, amplitude * 2) - amplitude;

        //•s‹K‘¥‚È—h‚ê
        float noiseX = (Mathf.PerlinNoise(t * noiseSpeed, 0) - 0.5f) * amplitude * 2;
        float noiseY = (Mathf.PerlinNoise(0, t * noiseSpeed) - 0.5f) * amplitude * 2;

        //“Ë”­“I‚ÈƒKƒ^‚Â‚«
        float jitterX = (Random.value - 0.5f) * jitter;
        float jitterY = (Random.value - 0.5f) * jitter;

        //‡¬
        float x = pingX * 0.5f + noiseX * 0.7f + jitterX;
        float y = pingY * 0.5f + noiseY * 0.7f + jitterY;

        //‰ºŒÀ‚ğ’´‚¦‚È‚¢‚æ‚¤‚É•â³
        float finalY = Mathf.Max(basePos.y + y, minHeight);

        //Z‰ñ“]‚Ì•s‹K‘¥‚È—h‚ê
        float rot = Mathf.Sin(t * speed * 1.3f) * rotationAmount;
        rot += (Mathf.PerlinNoise(t * noiseSpeed, t * noiseSpeed) - 0.5f) * rotationAmount;

        //“K—p
        transform.localPosition = basePos + new Vector3(x, finalY - basePos.y, 0);
        transform.localRotation = Quaternion.Euler(0, 0, rot);
    }
}
