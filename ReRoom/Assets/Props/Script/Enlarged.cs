
public class Enlarged : AnomalyProps
{
    private const float Scale = 3.0f;

    public override void StartExecute()
    {
        //オブジェクトの巨大化
        transform.localScale *= Scale;
    }
}
