using UnityEngine;

public class ColorSwap : Props
{
    [SerializeField] Renderer m_renderer;
    [SerializeField] Material m_anomalyMaterial;

    protected override void StartExecute()
    {
        //ƒ}ƒeƒŠƒAƒ‹‚ğİ’è
        m_renderer.material = m_anomalyMaterial;
    }
}
