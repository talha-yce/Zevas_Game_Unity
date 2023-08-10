using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kalpkontrol : MonoBehaviour
{
    public Image heartPrefab;
    public Transform canvasTransform;
    public float heartSpacing = 80f;
    private Oyun_Yonetim healthManager; // Oyun_Yonetim sýnýfýndan referans
    private List<Image> heartImages = new List<Image>();

    private void Start()
    {
        healthManager = FindObjectOfType<Oyun_Yonetim>(); // Oyun_Yonetim sýnýfýndan referansý bulun
        InitializeHearts();
    }

    private void InitializeHearts()
    {
        int initialHearts = healthManager.can; // Baþlangýçta can sayýsýný al
        for (int i = 0; i < initialHearts; i++)
        {
            CreateHeart(i);
        }
    }

    private void CreateHeart(int index)
    {
        Image heartImage = Instantiate(heartPrefab, canvasTransform);
        heartImage.rectTransform.anchorMin = new Vector2(1, 1);
        heartImage.rectTransform.anchorMax = new Vector2(1, 1);
        heartImage.rectTransform.pivot = new Vector2(1, 1);
        heartImage.rectTransform.anchoredPosition = new Vector2(-index * heartSpacing, 0);
        heartImages.Add(heartImage);
    }

    private void Update()
    {
        UpdateHearts(healthManager.can); // Oyun_Yonetim sýnýfýndan can durumunu al
    }

    public void UpdateHearts(int newHearts)
    {
        if (newHearts > heartImages.Count)
        {
            int heartsToAdd = newHearts - heartImages.Count;
            for (int i = 0; i < heartsToAdd; i++)
            {
                CreateHeart(heartImages.Count + i); // Yeni kalbi ekleyin
            }
        }
        else if (newHearts < heartImages.Count)
        {
            int heartsToRemove = heartImages.Count - newHearts;
            for (int i = 0; i < heartsToRemove; i++)
            {
                if (heartImages.Count > 0)
                {
                    Image heartImage = heartImages[heartImages.Count - 1];
                    Destroy(heartImage.gameObject);
                    heartImages.Remove(heartImage);
                }
            }
        }
    }
}
