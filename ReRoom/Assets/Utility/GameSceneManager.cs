using TMPro;
using UnityEngine;

enum TextType
{ 
    DeleteCount,
    RoomCount,
    PlayTime,

    Length,
}

public class GameSceneManager : MonoBehaviour
{
    static GameSceneManager m_instance;

    [SerializeField] PlayData m_playData;
    [SerializeField] TextMeshProUGUI[] m_texts = new TextMeshProUGUI[(int)TextType.Length];

    private const int MaxFakeAmount = 6;  //��������U���̍ő吔

    private int m_fakeAmount;       //��������U���̐�
    private int m_deleteAmount;     //�폜�����U���̐�

    private int m_totalDeleteAmount;      //�폜�����U���̑���
    private int m_totalRoomNumber;        //�i�񂾕����̑���
    private float m_totalPlayTime;        //�v���C����

    static public GameSceneManager Instance => m_instance;

    private void Awake()
    {
        //�V���O���g��
        if (m_instance == null) m_instance = this;

        //������
        m_fakeAmount = 0;
        m_deleteAmount = 0;

        m_totalDeleteAmount = 0;
        m_totalRoomNumber = 0;
        m_totalPlayTime = 0.0f;
    }

    private void Start()
    {
        //�ŏ��̕����𐶐�
        SetRoom();
    }

    private void Update()
    {
        //�v���C���Ԃ����Z
        m_totalPlayTime += Time.deltaTime;

        //UI�̍X�V
        m_texts[(int)TextType.DeleteCount].text = $"Delete: {m_totalDeleteAmount}";
        m_texts[(int)TextType.RoomCount].text = $"Room: {m_totalRoomNumber}";
        m_texts[(int)TextType.PlayTime].text = $"Time: {m_totalPlayTime:F1}s";
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
        m_totalDeleteAmount++;

        //�S�Ă̋U�����폜����������J���Ď��̕�����
        if (m_deleteAmount >= m_fakeAmount)
        {
            m_deleteAmount = 0;
            m_totalRoomNumber++;
            SetRoom();

            Debug.Log("���̕�����");
        }
    }

    public void GameOver()
    {
        //���U���g�̏㏑��
        m_playData.deleteFakeCount = m_totalDeleteAmount;
        m_playData.roomNumber = m_totalRoomNumber;
        m_playData.playTime = m_totalPlayTime;

        //���U���g��ʂ֑J��
        SceneController.Transition(SceneType.Game, SceneType.Result);
    }
}