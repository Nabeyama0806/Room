using UnityEngine;

public class BottleController : MonoBehaviour
{
    [SerializeField] GameObject[] m_bottles;

    public void SetBottle(int amount)
    {
        //全て非表示
        foreach (var bottle in m_bottles)
        {
            bottle.SetActive(false);
        }

        //ランダムな数だけ表示
        for (int i = 0; i < amount; ++i)
        {
            m_bottles[i].SetActive(true);
        }
    }
}
