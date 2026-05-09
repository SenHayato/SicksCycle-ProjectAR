using Unity.VisualScripting;
using UnityEngine;

public class ObjectInteractions : MonoBehaviour
{
    public Animator anim;
    public PopUpManager PopUp;

    public void Interactions()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    GameObject clickedObject = hit.transform.gameObject;
                    anim = clickedObject.GetComponentInParent<Animator>();
                    PopUp = clickedObject.GetComponentInParent<PopUpManager>();

                    if (clickedObject.GetComponent<Collider>().isTrigger)
                    {
                        Debug.Log("Clicked on trigger " + clickedObject.name);
                        anim.SetBool("Touch", true);
                        Invoke(nameof(ResetAnim), 1.1f);

                        if (PopUp.isEnabled == true)
                        {
                            PopUp.isEnabled = false;
                        }
                        else
                        {
                            PopUp.isEnabled = true;
                        }
                    }
                    else
                    {
                        Debug.Log("Clicked on non-trigger " + clickedObject.name);
                    }
                }
            }
        }
    } 
    public void InteractionsMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject clickedObject = hit.transform.gameObject;
                anim = clickedObject.GetComponentInParent<Animator>();
                PopUp = clickedObject.GetComponentInParent<PopUpManager>();

                if (clickedObject.GetComponent<Collider>().isTrigger)
                {
                    Debug.Log("Clicked on trigger " + clickedObject.name);
                    anim.SetBool("Touch", true);
                    Invoke(nameof(ResetAnim), 1.1f);

                    if (PopUp.isEnabled == true)
                    {
                        PopUp.isEnabled = false;
                    }
                    else
                    {
                        PopUp.isEnabled = true;
                    }
                }
                else
                {
                    Debug.Log("Clicked on non-trigger " + clickedObject.name);
                }
            }
        }
    }
    private void ResetAnim()
    {
        anim.SetBool("Touch", false);
    }

    public void Update()
    {
        Interactions();
        InteractionsMouse();
    }
}
