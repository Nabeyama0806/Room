using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    static GameSceneManager m_instance;

    private const int MaxFakeAmount = 6;  //¶¬‚·‚é‹U•¨‚ÌÅ‘å”

    private int m_fakeAmount;       //¶¬‚·‚é‹U•¨‚Ì”
    private int m_deleteAmount;     //íœ‚µ‚½‹U•¨‚Ì”

    static public GameSceneManager Instance => m_instance;

    private void Awake()
    {
        //ƒVƒ“ƒOƒ‹ƒgƒ“
        if (m_instance == null) m_instance = this;
    }

    private void Start()
    {
        //Å‰‚Ì•”‰®‚ð¶¬
        SetRoom();
    }

    private void SetRoom()
    {
        //‹U•¨‚Ì”‚ðƒ‰ƒ“ƒ_ƒ€‚ÉŒˆ’è
        m_fakeAmount = Random.Range(1, MaxFakeAmount + 1);

        //•”‰®‚ð¶¬
        RoomGenerator.Instance.Create(m_fakeAmount);
    }

    public void DeleteFake()
    {
        //íœ‚µ‚½‹U•¨‚Ì”‚ð‰ÁŽZ
        m_deleteAmount++;

        //‘S‚Ä‚Ì‹U•¨‚ðíœ‚µ‚½‚ç”à‚ðŠJ‚¯‚ÄŽŸ‚Ì•”‰®‚Ö
        if (m_deleteAmount >= m_fakeAmount)
        {
            m_deleteAmount = 0;
            SetRoom();

            Debug.Log("ŽŸ‚Ì•”‰®‚Ö");
        }
    }
}