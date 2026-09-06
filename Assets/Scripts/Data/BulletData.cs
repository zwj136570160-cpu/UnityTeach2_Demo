using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

/// <summary>
/// 子弹数据集合
/// </summary>
public class BulletData
{
    public List<BulletInfo> BulletInfoList = new List<BulletInfo>();
}

/// <summary>
/// 子弹单条数据
/// </summary>
public class BulletInfo
{
    [XmlAttribute]
    public int type;    //子弹的移动规则 1~5代表不同的移动规则
    [XmlAttribute]
    public float forwordSpeed;  //正朝向 移动速度
    [XmlAttribute]
    public float rightSpeed;    //横向移动速度
    [XmlAttribute]
    public float roundSpeed;    //旋转速度
    [XmlAttribute]
    public string resName;  //子弹特效资源路径
    [XmlAttribute]
    public string deadEffRes;   //子弹销毁时 创建的死亡特效
    [XmlAttribute]
    public float lifeTime;  //子弹出生到销毁的生命周期时间
    [XmlAttribute]
    public int id;  //子弹数据的ID  方便我们配置的时候 修改数据
}
