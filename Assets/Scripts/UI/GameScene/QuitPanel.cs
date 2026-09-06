using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    //确定
    public UIButton btnSure;
    //关闭
    public UIButton btnClose;


    public override void Init()
    {
        btnSure.onClick.Add(new EventDelegate(() =>
        {
            SceneManager.LoadScene("BeginScene");
        }));

        btnClose.onClick.Add(new EventDelegate(() =>
        {
            HideMe();
        }));

        HideMe();
    }

    
}
