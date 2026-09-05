using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic instance;
    public static BKMusic Instance => instance;

    private AudioSource bkAudio;
    private void Awake()
    {
        instance = this;
        //得到依附在同一个对象上的音效组件
        bkAudio = this.GetComponent<AudioSource>();

        //第一次初始化 当前是否播放 音量大小是多少
        SetBKMusicIsOpen(GameDataMgr.Instance.musicData.musicIsOpen);
        SetBKMusicValue(GameDataMgr.Instance.musicData.musicValue);
    }

    /// <summary>
    /// 提供给外部开关背景音乐的方法
    /// </summary>
    /// <param name="isOpen"></param>
    public void SetBKMusicIsOpen(bool isOpen)
    {
        bkAudio.mute = !isOpen;
    }

    /// <summary>
    /// 设置背景音乐的大小
    /// </summary>
    /// <param name="value"></param>
    public void SetBKMusicValue(float  value)
    {
        bkAudio.volume = value;
    }
}
