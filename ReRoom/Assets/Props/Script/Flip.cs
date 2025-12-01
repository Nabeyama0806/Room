public class Flip : AnomalyProps
{
    public override void StartExecute()
    {
        //オブジェクトを反転させる
        transform.Rotate(0f, 180f, 0f);
    }
}
