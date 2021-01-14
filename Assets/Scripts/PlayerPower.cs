using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPower : MonoBehaviour
{
    [SerializeField] private int numOfKeys = 0;
    [SerializeField] private int numOfSwords = 0;

    [SerializeField] private TMP_Text keysText = null;
    [SerializeField] private TMP_Text swordText = null;

    private void Update()
    {
        UpdateUIText();
    }

    private void UpdateUIText()
    {
        keysText.text = numOfKeys.ToString();
        swordText.text = numOfSwords.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            numOfKeys++;
        }

        if (collision.gameObject.CompareTag("Sword"))
        {
            Destroy(collision.gameObject);
            numOfSwords++;
        }
    }
}
