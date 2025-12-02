public enum AnomalyType
{
    Enlarged,       //巨大化
    StrangeSound,   //異音
    Duplicate,      //増加
    Shaking,        //振動
    Flicker,        //点滅
    Floating,       //浮遊
    Look,           //凝視

    Length,
}

public enum Rotate
{
    X,
    Y,
    Z,

    Length,
}

public class AnomalyProps : Props
{
    private void Start()
    {
        //異変オブジェクトでなければ処理を行わない
        if (Type != ObjectType.Anomaly) return;

        //異変の種類に応じた処理を実行
        StartExecute();
    }

    private void FixedUpdate()
    {
        //異変オブジェクトでなければ処理を行わない
        if (Type != ObjectType.Anomaly) return;

        //異変の種類に応じた処理を更新
        UpdateExecute();
    }

    //異変の種類に応じた処理を派生先で定義
    public virtual void StartExecute() { }

    public virtual void UpdateExecute() { }
}   