using UnityEngine;

public class PropsCreate : MonoBehaviour
{
    private void Awake()
    {
        //�q�I�u�W�F�N�g�����ׂĔ�\���ɂ���
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        //�����_����1�����\������
        int randomIndex = Random.Range(0, transform.childCount);
        transform.GetChild(randomIndex).gameObject.SetActive(true);
    }
}
