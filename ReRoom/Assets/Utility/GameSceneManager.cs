using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    static GameSceneManager m_instance;

    private const int MaxFakeAmount = 6;  //��������U���̍ő吔

    private int m_fakeAmount;       //��������U���̐�
    private int m_deleteAmount;     //�폜�����U���̐�

    static public GameSceneManager Instance => m_instance;

    private void Awake()
    {
        //�V���O���g��
        if (m_instance == null) m_instance = this;
    }

    private void Start()
    {
        //�ŏ��̕����𐶐�
        SetRoom();
    }

    private void SetRoom()
    {
        //�U���̐��������_���Ɍ���
        m_fakeAmount = Random.Range(1, MaxFakeAmount + 1);

        //�����𐶐�
        RoomGenerator.Instance.Create(m_fakeAmount);
    }

    public void DeleteFake()
    {
        //�폜�����U���̐������Z
        m_deleteAmount++;

        //�S�Ă̋U�����폜����������J���Ď��̕�����
        if (m_deleteAmount >= m_fakeAmount)
        {
            m_deleteAmount = 0;
            SetRoom();

            Debug.Log("���̕�����");
        }
    }
}