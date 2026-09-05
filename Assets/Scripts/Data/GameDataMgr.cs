using UnityEngine;

public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;

    //音乐相关数据
    public MusicData musicData;

    //排行榜数据
    public RankData rankData;

    //角色数据
    public RoleData roleData;

    //当前选择的角色 编号
    public int nowSelHeroIndex = 0;

    private GameDataMgr() 
    {
        //获取本地硬盘中存储的音乐数据
        musicData = XmlDataMgr.Instance.LoadData(typeof(MusicData), "MusicData") as MusicData;
        //一开始就读取本地的排行榜数据
        rankData = XmlDataMgr.Instance.LoadData(typeof(RankData), "RankData") as RankData;
        //一开始就读取角色数据
        roleData = XmlDataMgr.Instance.LoadData(typeof(RoleData), "RoleData") as RoleData;
    }

    #region 音乐、音效相关
    //保存音乐相关数据方法
    public void SaveMusicData()
    {
        XmlDataMgr.Instance.SaveData(musicData, "MusicData");
    }

    //开关背景音乐的方法
    public void SetMusicIsOpen(bool isOpen)
    {
        //改数据
        musicData.musicIsOpen = isOpen;
        //真正改变背景音乐开关
        BKMusic.Instance.SetBKMusicIsOpen(isOpen);
    }

    //开关背景音效的方法
    public void SetSoundIsOpen(bool isOpen)
    {
        //改数据
        musicData.SoundIsOpen = isOpen;
        //真正改变背景音效开关
    }

    //设置背景音乐音量
    public void SetMusicValue(float value)
    {
        //改数据
        musicData.musicValue = value;
        //真正改变背景音乐大小
        BKMusic.Instance.SetBKMusicValue(value);
    }

    public void SetSoundValue(float value)
    {
        //改数据
        musicData.SoundValue = value;
    }
    #endregion

    #region 排行榜相关
    /// <summary>
    /// 添加排行榜数据
    /// </summary>
    /// <param name="name">玩家名</param>
    /// <param name="time">通关时间</param>
    public void AddRankData(string name, int time)
    {
        //单条数据
        RankInfo rankInfo = new RankInfo();
        rankInfo.name = name;
        rankInfo.time = time;
        rankData.rankList.Add(rankInfo);

        //排序
        rankData.rankList.Sort((a , b) =>
        {
            if (a.time > b.time)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        });

        //移除大于20条的内容
        if (rankData.rankList.Count > 20)
            rankData.rankList.RemoveAt(20);
        //rankData.rankList.RemoveRange(20, rankData.rankList.Count - 20);

        //保存数据
        XmlDataMgr.Instance.SaveData(rankData, "RankData");
    }
    #endregion

    #region 玩家数据相关
    /// <summary>
    /// 提供给外部 获取当前选择的英雄数据
    /// </summary>
    /// <returns></returns>
    public RoleInfo GetNowSelHeroInfo()
    {
        return roleData.roleList[nowSelHeroIndex];
    }
    #endregion
}
