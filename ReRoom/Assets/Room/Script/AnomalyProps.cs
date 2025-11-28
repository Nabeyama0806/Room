using UnityEngine;

public enum AnomalyType
{
    Enlarged,       //‹‘å‰»
    StrangeSound,   //ˆÙ‰¹
    Duplicate,      //‘‰Á
    Shaking,        //U“®
    Flicker,        //“_–Å
    Floating,       //•‚—V

    Length,
}

public abstract class AnomalyProps : Props
{
    [SerializeField] AnomalyType m_anomalyType;

    //ˆÙ•Ï‚Ìí—Ş‚É‰‚¶‚½ˆ—‚ğ”h¶æ‚Å’è‹`
    public abstract void Execute();
}   
          