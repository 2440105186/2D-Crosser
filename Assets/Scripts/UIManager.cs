using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button WoodButton;
    public Button StoneButton;
    public Button MetalButton;
    public BarCreator barCreator;

    public Slider BudgetSlider;
    public Text BudgetText;
    public Gradient myGradient;

    private void Start()
    {
        StoneButton.onClick.Invoke();
    }

    public void Play()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

    public void ChangeBar(int myBarType)
    {
        if (myBarType == 0)
        {
            WoodButton.GetComponent<Outline>().enabled = false;
            StoneButton.GetComponent<Outline>().enabled = true;
            MetalButton.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.StoneBar;
        }
        if (myBarType == 1)
        {
            WoodButton.GetComponent<Outline>().enabled = true;
            StoneButton.GetComponent<Outline>().enabled = false;
            MetalButton.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.WoodBar;
        }
        if (myBarType == 2)
        {
            WoodButton.GetComponent<Outline>().enabled = false;
            StoneButton.GetComponent<Outline>().enabled = false;
            MetalButton.GetComponent<Outline>().enabled = true;
            barCreator.BarToInstantiate = barCreator.MetalBar;
        }

    }

    public void UpdateBudgetUI(float CurrentBudget, float LevelBudget)
    {
        BudgetText.text = Mathf.FloorToInt(CurrentBudget).ToString() + "$";
        BudgetSlider.value = CurrentBudget / LevelBudget;
        BudgetSlider.fillRect.GetComponent<Image>().color = myGradient.Evaluate(BudgetSlider.value);
    }
}
