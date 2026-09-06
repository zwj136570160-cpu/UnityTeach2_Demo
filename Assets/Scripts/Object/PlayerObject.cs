using Unity.VisualScripting;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    private static PlayerObject instance;
    public static PlayerObject Instance => instance;

    //血量
    public int nowHp;
    public int maxHp;

    //速度
    public int speed;
    //旋转速度
    public int roundSpeed;
    //目标四元数角度
    private Quaternion targeiQ;

    //是否死亡
    public bool isDead;

    //当前世界坐标转屏幕坐标上的点
    private Vector3 nowPos;

    //上一次玩家的位置 就是在位移前 玩家的位置
    private Vector3 frontPos;

    private void Awake()
    {
        instance = this;
    }

    public void Dead()
    {
        isDead = true;
        //显示游戏结束面板
        GameOverPanel.Instance.ShowMe();
    }

    public void Wound()
    {
        if (isDead)
            return;
        //减血
        this.nowHp -= 1;
        GamePanel.Instance.ChangeHp(this.nowHp);
        //是否死亡了
        if (this.nowHp <= 0)
            this.Dead();
    }

    private float hValue;
    private float vValue;
    // Update is called once per frame
    void Update()
    {
        //如果玩家已经死亡了 就没必要再移动了
        if (isDead)
            return;
        //移动 旋转逻辑

        //旋转
        hValue = Input.GetAxisRaw("Horizontal");
        vValue = Input.GetAxisRaw("Vertical");
        //如果没有按AD键 目标角度就是000度
        if (hValue == 0)
            targeiQ = Quaternion.identity;
        //如果按AD键 就是0020 或者00-20 根据按的左右决定
        else
            targeiQ = hValue < 0 ? Quaternion.AngleAxis(20, Vector3.forward) : Quaternion.AngleAxis(-20, Vector3.forward);
        //让飞机朝着目标四元素去旋转
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targeiQ, roundSpeed * Time.deltaTime);

        //在位移之前 记录之前的位置
        frontPos = this.transform.position;

        //移动
        //前后
        this.transform.Translate(Vector3.forward * vValue * speed * Time.deltaTime);
        //左右
        this.transform.Translate(Vector3.right * hValue * speed * Time.deltaTime, Space.World);

        //进行极限判断
        nowPos = Camera.main.WorldToScreenPoint(this.transform.position);
        //左右溢出判断
        if (nowPos.x <= 0 || nowPos.x > Screen.width)
        {
            this.transform.position = new Vector3(frontPos.x, this.transform.position.y, this.transform.position.z);
        }
        //上下溢出判断
        if (nowPos.y <= 0 || nowPos.y > Screen.height)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, frontPos.z);
        }
    }
}
