using UnityEngine;

public class BottleController : MonoBehaviour
{
    [SerializeField] GameObject[] m_bottles;

    public void SetBottle(int bottleAmount)
    {
        //全て非表示
        foreach (var bottle in m_bottles)
        {
            bottle.SetActive(false);
        }

        //指定の数だけ表示
        for(int i = 0; i < bottleAmount; ++i)
        {
            m_bottles[i].SetActive(true);
        }
    }
}
