using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCrawler : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 20f;
    void Update()
    {
        transform.Translate(Camera.main.transform.up * scrollSpeed * Time.deltaTime);
    }
}
