using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public UIButton btnClose;
    public UIScrollView svList;

    public override void Init()
    {
        btnClose.onClick.Add(new EventDelegate(() =>
        {
            HideMe();
        }));
        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        //更新面板上显示的信息
    }
}
