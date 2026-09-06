using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

/// <summary>
/// 开火点数据集合
/// </summary>
public class FireData
{
    public List<FireInfo> fireInfoList = new List<FireInfo>();
}

/// <summary>
/// 单条开火点数据
/// </summary>
public class FireInfo
{
    [XmlAttribute]
    public int id;  //开火点ID 方便配置
    [XmlAttribute]
    public int type;    //开火点类型 是散弹还是按顺序 1顺序 2散弹
    [XmlAttribute]
    public int num; //数量 该组子弹 有多少颗
    [XmlAttribute]
    public float cd;    //每个子弹的间隔时间
    [XmlAttribute]
    public string ids;  //关联子弹ID 1,10 代表的就是在1~10ID的子弹数据中去随机
    [XmlAttribute]
    public float delay; //组间 间隔时间
}
