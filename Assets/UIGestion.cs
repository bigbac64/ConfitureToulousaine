using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGestion : MonoBehaviour
{
    public GameObject resume;
    public GameObject mixerPanel;
    public GameObject runPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showRun()
    {
        runPanel.SetActive(true);
    }

    public void closeRun()
    {
        runPanel.SetActive(false);
    }

    public void showMixer()
    {
        mixerPanel.SetActive(true);
    }

    public void closeMixer()
    {
        mixerPanel.SetActive(false);
    }

    public void showResume()
    {
        resume.SetActive(true);
    }

    public void writeResume(int i, string titre, string count)
    {
        Transform childTransform = resume.transform.Find("Rec" + i);
        if (childTransform != null)
        {
            childTransform.Find("txt").GetComponent<TextMeshProUGUI>().text = titre;
            childTransform.Find("count").GetComponent<TextMeshProUGUI>().text = count;
            childTransform.gameObject.SetActive(true);
        }
    }

    public void closeResume()
    {
        for (int i = 1; i <= 3; i++)
        {
            resume.transform.Find("Rec" + i).gameObject.SetActive(false);
        }
        resume.SetActive(false);
    }
}
