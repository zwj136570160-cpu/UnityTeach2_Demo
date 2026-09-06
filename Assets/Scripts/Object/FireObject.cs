using UnityEngine;

/// <summary>
/// 表示开火点位置的类型
/// </summary>
public enum E_Pos_Type
{
    TopLeft,
    TopRight,
    Top,

    Left,
    Right,

    BottomLeft,
    BottomRight,
    Bottom,
}

public class FireObject : MonoBehaviour
{
    public E_Pos_Type type;
    //屏幕上的点
    private Vector3 screenPos;
    //初始发射子弹的方向  主要用于作为散弹的初始方向 用于计算
    private Vector3 initDir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //用于测试玩家 转屏幕坐标后 横截面的z轴值
        //print(Camera.main.WorldToScreenPoint(PlayerObject.Instance.transform.position));
        //更新位置
        UpdatePos();
    }

    private void UpdatePos()
    {
        //设置为和主玩家位置转屏幕坐标后的 Z位置一样  目的是让点和玩家 所在的横截面是一致的
        screenPos.z = 193.46f;
        switch (type)
        {
            case E_Pos_Type.TopLeft:
                screenPos.x = 0;
                screenPos.y = Screen.height;
                initDir = Vector3.right;
                break;
            case E_Pos_Type.TopRight:
                screenPos.x = Screen.width;
                screenPos.y = Screen.height;
                initDir = Vector3.left;
                break;
            case E_Pos_Type.Top:
                screenPos.x = Screen.width / 2;
                screenPos.y = Screen.height;
                initDir = Vector3.right;
                break;
            case E_Pos_Type.Left:
                screenPos.x = 0;
                screenPos.y = Screen.height / 2;
                initDir = Vector3.right;
                break;
            case E_Pos_Type.Right:
                screenPos.x = Screen.width;
                screenPos.y = Screen.height / 2;
                initDir = Vector3.left;
                break;
            case E_Pos_Type.BottomLeft:
                screenPos.x = 0;
                screenPos.y = 0;
                initDir = Vector3.right;
                break;
            case E_Pos_Type.BottomRight:
                screenPos.x = Screen.width;
                screenPos.y = 0;
                initDir = Vector3.left;
                break;
            case E_Pos_Type.Bottom:
                screenPos.x = Screen.width / 2;
                screenPos.y = 0;
                initDir = Vector3.right;
                break;
        }
        //再把屏幕点 转成世界坐标点 得到的就是需要的坐标
        this.transform.position = Camera.main.ScreenToWorldPoint(screenPos);
    }
}
