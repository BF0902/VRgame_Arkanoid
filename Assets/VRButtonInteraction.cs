using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRButtonInteraction : MonoBehaviour
{
    public Transform controllerTransform; // VR控制器的Transform

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 按下触发按钮时发射射线
        if (Input.GetButtonDown("Button")) // 根据您的设置修改按钮名称
        {
            RaycastHit hit;
            if (Physics.Raycast(controllerTransform.position, controllerTransform.forward, out hit))
            {
                if (hit.collider.CompareTag("StartButton"))
                {
                    // 射线击中了按钮
                    ChangeScene(); // 调用场景转换方法
                }
            }
        }
    }

    private void ChangeScene()
    {
        // 在这里处理场景转换逻辑
        SceneManager.LoadScene("gaming"); // 将"NextScene"替换为您要加载的目标场景名称
    }
}
