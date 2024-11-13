using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NavegButtons : MonoBehaviour {

	public string scene;
	
	public void LoadScene(){
		SceneManager.LoadScene (scene);	
	}
	
	public void LoadMenu(){
		SceneManager.LoadScene ("Menu");
	}
	
	public void LoadPlayScene(){
		SceneManager.LoadScene ("PlayScene");
	}
	
	public void LoadSports(){
		SceneManager.LoadScene ("SportsScene");
	}
	
	public void LoadTennis(){
		SceneManager.LoadScene ("PlayTennis");
	}
	
	public void LoadSwimming(){
		SceneManager.LoadScene("PlaySwimming");
	}
	
	public void LoadAthletics(){
		SceneManager.LoadScene ("PlayAthletics");
	}

    public void LoadCanoe()
    {
        SceneManager.LoadScene("PlayCanoe");
    }
    public void LoadCanoeCuriosities()
    {
        SceneManager.LoadScene("Canoe_curiosities");
    }
    public void LoadTennisGame(){
		SceneManager.LoadScene("treino");
	}
	
	public void LoadAthleticsGame(){
		SceneManager.LoadScene ("AthleticsGame");
		
	}

	public void LoadAthleticsTutorial(){
		SceneManager.LoadScene ("AthleticsTutorial");
		
	}
	
	public void LoadSwimmingGame(){
		SceneManager.LoadScene	("Swimming");
	}
	
	public void LoadQuitGame(){
		Application.Quit();
	}
	
	public void LoadQuiz(){
		SceneManager.LoadScene("QuizGame");
	}
	
	public void LoadTennisCuriosities(){
	
		SceneManager.LoadScene("TennisCuriosities");
	}
	
	public void LoadAthleticsCuriosities(){
	
		SceneManager.LoadScene("AthleticsCuriosities");
	}
	
	public void LoadSwimmingCuriosities(){

        SceneManager.LoadScene("SwimmingCuriosities");
	}
	
	public void LoadCredits(){

        SceneManager.LoadScene("Credits");
	}
	
	public void LoadAthleticsAthlete(){
        SceneManager.LoadScene("AthleticsAthlete");
	}
	
	public void LoadSwimmingAthlete(){
        SceneManager.LoadScene("SwimmingAthlete");
	}
	
	public void LoadTennisAthlete(){
        SceneManager.LoadScene("TennisAthlete");
	}
	
	public void LoadTennisMainGame(){
        SceneManager.LoadScene("main");
	}
	
	public void LoadTennisGameSelection(){
        SceneManager.LoadScene("TennisGameSelection");
	}
	public void LoadBasquete()
	{        
		SceneManager.LoadScene("Basketball Scene");
    }
    public void LoadBasqueteTutorial()
    {
        SceneManager.LoadScene("TennisGameSelection");
    }
    public void LoadBasqueteSelecte()
    {
        SceneManager.LoadScene("PlayBasquete");
    }
    public void LoadBasqueteFirula()
    {
        SceneManager.LoadScene("BasketballCuriosities");
    }

}
