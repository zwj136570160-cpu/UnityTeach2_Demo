using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosePanel : BasePanel<ChoosePanel>
{
    //左
    public UIButton btnLeft;
    //右
    public UIButton btnRight;
    //关闭
    public UIButton btnClose;
    //开始
    public UIButton btnStart;
    //模型父对象
    public Transform heroPos;

    //下方属性相关对象
    public List<GameObject> hpObjs;
    public List<GameObject> speedObjs;
    public List<GameObject> volumeObjs;

    //当前显示的飞机模型对象
    private GameObject airPlaneObj;

    public override void Init()
    {
        //选择角色后，点击开始切场景
        btnStart.onClick.Add(new EventDelegate(() =>
        {
            SceneManager.LoadScene("GameScene");
        }));

        btnLeft.onClick.Add(new EventDelegate(() =>
        {
            //左按钮 减索引
            --GameDataMgr.Instance.nowSelHeroIndex;
            //如果小于最小的索引 直接等于最后一个索引
            if (GameDataMgr.Instance.nowSelHeroIndex < 0)
            {
                GameDataMgr.Instance.nowSelHeroIndex = GameDataMgr.Instance.roleData.roleList.Count - 1;
            }
            ChangeNowHero();
        }));

        btnRight.onClick.Add(new EventDelegate(() =>
        {   //左按钮 减索引
            ++GameDataMgr.Instance.nowSelHeroIndex;
            //如果小于最小的索引 直接等于最后一个索引
            if (GameDataMgr.Instance.nowSelHeroIndex >= GameDataMgr.Instance.roleData.roleList.Count)
            {
                GameDataMgr.Instance.nowSelHeroIndex = 0;
            }
            ChangeNowHero();
        }));

        btnClose.onClick.Add(new EventDelegate(() =>
        {
            //隐藏自己
            HideMe();
            //显示开始页面
            BeginPanel.Instance.ShowMe();
        }));

        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        //每次显示的时候  都从第一个开始选择
        GameDataMgr.Instance.nowSelHeroIndex = 0;
        ChangeNowHero();
    }

    public override void HideMe()
    {
        base.HideMe();
        //删除当前的模型
        DestroyObj();
    }

    private void ChangeNowHero()
    {
        RoleInfo info = GameDataMgr.Instance.GetNowSelHeroInfo();

        //更新模型
        //先删除上一次的飞机模型
        DestroyObj();
        //再创建当前的飞机模型
        airPlaneObj = Instantiate(Resources.Load<GameObject>(info.resName));
        //设置父对象
        airPlaneObj.transform.SetParent(heroPos, false);
        //设置角度和位置 以及缩放
        airPlaneObj.transform.localPosition = Vector3.zero;
        airPlaneObj.transform.localRotation = Quaternion.identity;
        airPlaneObj.transform.localScale = Vector3.one * info.scale;
        //修改层级
        airPlaneObj.layer = LayerMask.NameToLayer("UI");
        //更新属性
        for (int i = 0; i < 10; i++)
        {
            hpObjs[i].SetActive(i < info.hp);
            speedObjs[i].SetActive(i < info.speed);
            volumeObjs[i].SetActive(i < info.volume);
        }
    }

    /// <summary>
    /// 用于删除上一次选择的模型对象
    /// </summary>
    private void DestroyObj()
    {
        if (airPlaneObj != null)
        {
            Destroy(airPlaneObj);
            airPlaneObj = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
