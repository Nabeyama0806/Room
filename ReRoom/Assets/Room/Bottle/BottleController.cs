using UnityEngine;

public class BottleController : MonoBehaviour
{
    [SerializeField] GameObject[] m_bottles;

    public void SetBottle()
    {
        //全て非表示
        foreach (var bottle in m_bottles)
        {
            bottle.SetActive(false);
        }

        //ランダムな数だけ表示
        m_bottles[0].SetActive(true);
    }
}
