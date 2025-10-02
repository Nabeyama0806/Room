using UnityEngine;

public class BottleController : MonoBehaviour
{
    [SerializeField] GameObject[] m_bottles;

    public void SetBottle(int amount)
    {
        //�S�Ĕ�\��
        foreach (var bottle in m_bottles)
        {
            bottle.SetActive(false);
        }

        //�����_���Ȑ������\��
        for (int i = 0; i < amount; ++i)
        {
            m_bottles[i].SetActive(true);
        }
    }
}
