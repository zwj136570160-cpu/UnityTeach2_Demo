using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    //退出按钮
    public UIButton btnBack;
    //时间
    public UILabel labTime;
    public List<GameObject> hpObjs;
    //当前游戏运行的时间
    public float nowTime = 0;


    public override void Init()
    {
        btnBack.onClick.Add(new EventDelegate(() =>
        {
            //点击退出按钮后 显示确定退出面板
            QuitPanel.Instance.ShowMe();
        }));
        ChangeHp(5);

    }

    /// <summary>
    /// 提供给外部 改变血量的方法
    /// </summary>
    /// <param name="hp"></param>
    public void ChangeHp(int hp)
    {
        for (int i = 0; i < hpObjs.Count; i++)
        {
            hpObjs[i].SetActive(i < hp);
        }
    }

    private void Update()
    {
        nowTime += Time.deltaTime;
        labTime.text = "";

        //更新时间显示
        if ((int)nowTime / 3600 > 0)
            labTime.text += $"{(int)nowTime / 3600}h";
        if ((int)nowTime % 3600 / 60 > 0 || labTime.text != null)
        {
            labTime.text += $"{(int)nowTime % 3600 / 60}m";
        }
        labTime.text += (int)nowTime % 60 + "s";
    }

}
