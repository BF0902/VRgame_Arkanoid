using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FT_InteractableRay : MonoBehaviour
{
    public bool isActive = true;

    public UnityEvent OnRayEnter;
    public UnityEvent OnRayExit;
    public UnityEvent OnRayClick;
    //public GameObject Image;

    public virtual void RayEnter()
    {
        OnRayEnter.Invoke();
        Debug.Log("射線進入:" + name);
    }

    public virtual void RayExit()
    {
        OnRayExit.Invoke();
        Debug.Log("射線離開:" + name);
    }

    public virtual void RayClick()
    {
        OnRayClick.Invoke();
        //Debug.Log("射線點擊:" + name);
        //Image.SetActive(true);
        /*if (GameObject.FindWithTag("Numbers0"))
        {
            Debug.Log("0");
        }
        else if (GameObject.FindWithTag("Numbers3"))
        {
            Debug.Log("3");
        }
        else if (GameObject.FindWithTag("Numbers5"))
        {
            Debug.Log("5");
        }
        else if (GameObject.FindWithTag("Numbers7"))
        {
            Debug.Log("7");
        }
        else if (GameObject.FindWithTag("Numbers8"))
        {
            Debug.Log("8");
        }*/
    }

   // public void StartGame()
   // {
        //InputText.text = InputText.text + "StartButton";
        // Debug.Log("StartButton1");
        //SceneManager.LoadScene("gaming");
        /*Letter.SetActive(true);
        StartUI.SetActive(false);
        Destroy(player);
        Destroy(cube);*/


    //}
}
