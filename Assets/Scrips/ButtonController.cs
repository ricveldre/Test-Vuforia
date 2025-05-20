using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _buttons;
    [SerializeField]
    private string _appearAnimationName;
    [SerializeField]
    private string _disappearAnimationName;
    [SerializeField]
    private float _buttonsAppearDelay;
    public void Showbuttons(){
        StartCoroutine(ShowButtonsWithDelay());
    }
    private IEnumerator ShowButtonsWithDelay() {
        foreach(GameObject button in _buttons) {
        button.GetComponent<Animator>().Play(_appearAnimationName);
        yield return new WaitForSeconds(_buttonsAppearDelay);
        }
    }
    public void HideButtons(){
        foreach(GameObject button in _buttons){
            button.GetComponent<Animator>().Play(_disappearAnimationName);
        }
    }
}
