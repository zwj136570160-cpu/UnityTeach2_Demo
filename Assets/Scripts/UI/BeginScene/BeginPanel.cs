using UnityEngine;

/// <summary>
/// 开始界面
/// </summary>
public class BeginPanel : BasePanel<BeginPanel>
{
    public UIButton btnBegin;
    public UIButton btnRank;
    public UIButton btnSetting;
    public UIButton btnQuit;

    public override void Init()
    {
        //监听按钮事件
        btnBegin.onClick.Add(new EventDelegate(() =>
        {
            //显示选角面板
            //隐藏自己
            HideMe();
        }));
        btnRank.onClick.Add(new EventDelegate(() =>
        {
            //显示排行榜面板
            RankPanel.Instance.ShowMe();
        }));
        btnSetting.onClick.Add(new EventDelegate(() =>
        {
            //显示设置面板
            SettingPanel.Instance.ShowMe();
        }));
        btnQuit.onClick.Add(new EventDelegate(() =>
        {
            //退出游戏
            Application.Quit();
        }));
    }
}
