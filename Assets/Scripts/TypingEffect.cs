using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    public float typingInterval;

    TMP_Text textbox;
    string originalText;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<TMP_Text>();
        originalText = textbox.text;
        textbox.text = "";

        //Typing();
        StartCoroutine(Typing());
    }


    IEnumerator Typing()
    {
        foreach (char c in originalText)
        {
            textbox.text += c;


            yield return new WaitForSeconds(typingInterval);
        }
    }
}
