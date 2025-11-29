using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : AnomalyProps
{
    private GameObject m_player;

    private void Start()
    {
        //ヒエラルキー上のプレイヤーを取得
        m_player = GameObject.FindWithTag("Player");
    }

    public override void UpdateExecute()
    {
        //常にプレイヤーの方を向く
        Vector3 dir = m_player.transform.position - transform.position;
        dir.y = 0;
        dir.Normalize();
        Quaternion lookRot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, 0.05f);
    }
}
