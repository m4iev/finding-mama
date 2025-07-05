using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TMP_Text textDialog;
    public string[] kalimat;
    [SerializeField] private GameObject textbox;
    [SerializeField] private GameObject buttonJawaban;
    public int indexPertanyaan;
    public float textSpeed;

    public int index;

    private void Start()
    {
        textDialog.text = string.Empty;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameState.isPlaying == false && GameState.onQuestion == false)
        {
            if (textDialog.text == kalimat[index])
            {
                NextLine();
            }
            else 
            {
                StopAllCoroutines();
                textDialog.text = kalimat[index];
            }
        }
    }

    public void StartDialogue()
    {
        textbox.SetActive(true);
        GameState.isPlaying = false;
        index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in kalimat[index].ToCharArray())
        {
            textDialog.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < kalimat.Length - 1)
        {
            if (index == indexPertanyaan)
            {
                GameState.onQuestion = true;
                buttonJawaban.SetActive(true);
            } else
            {
                GameState.onQuestion = false;
                index++;
                textDialog.text = string.Empty;
                StartCoroutine(TypeLine());
            }
        }
        else
        {
            GameState.isPlaying = true;
            GameState.canMove = true;
            textDialog.text = string.Empty;
            textbox.SetActive(false);

            if (GameState.lose == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (SceneManager.GetActiveScene().name == "Rooftop")
            {
                new WaitForSeconds(5f);
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
