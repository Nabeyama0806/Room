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

        //進んだ部屋の数だけ表示
        for(int i = 0; i < GameSceneManager.Instance.CurrentRoomIndex; ++i)
        {
            m_bottles[i].SetActive(true);
        }
    }
}
