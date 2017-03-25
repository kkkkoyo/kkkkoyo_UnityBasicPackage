using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController_1 : MonoBehaviour {


	private int ansNumber = 0;
	private int selectNumber = 0;
	[SerializeField] private float posMoveTime = 2;
	[SerializeField] private int rotateNumber = 2;
	[SerializeField] private float rotateMoveTime = 0.2f;
	private bool isRotateChecker = false;
	private int rotateCount = 0;
	[SerializeField] private Image[] AnswerImage = new Image[5];//MAXNUMBER = 5
	[SerializeField] private Image Slame;
	[SerializeField] private Text scoreText;
	private float countTime = 0;
	public static bool isGame = true;
	// Use this for initialization
	[SerializeField] private GameObject stage;
	[SerializeField] private GameObject stageLine;
	[SerializeField] public static int FirstStageNumber = 2;

	void Awake()
	{
		stageLine.transform.localScale = new Vector3(1,1,stage.transform.localScale.z);
		stageLine.transform.position = new Vector3(stage.transform.position.x,stage.transform.position.y,(FirstStageNumber-1)*stageLine.transform.localScale.z);
	}
	
	void Update(){
		if(isGame){
			 countTime += Time.deltaTime; //スタートしてからの秒数を格納
		}

	}

	public void SelectAns(int number){

		if(isRotateChecker){
			return ;
		}
		isRotateChecker = true;
		selectNumber = number;
		iTween.MoveTo (AnswerImage[number].gameObject, iTween.Hash ("x", Slame.transform.position.x,
						"y", Slame.transform.position.y, "time", posMoveTime));
 		//最初の半回転の呼び出し
    	OnCompletionHalfRoundHandler();
		bool isCorrect = false;

		if(number==ansNumber){
			isCorrect = true;
		}
	}
	private void OnCompletionHalfRoundHandler ()
	{
		rotateCount++;
		if(rotateCount>rotateNumber){
			rotateCount = 0;
			StartCoroutine(AnimationEnd());
			return;
		}
		float angle = 179.9f;
		if (AnswerImage[selectNumber].gameObject.transform.localEulerAngles.z == 179.9f)
		{
			AnswerImage[selectNumber].gameObject.transform.rotation = Quaternion.Euler(0, 0, 180.1f);
			angle = 0.0f;
		}

		iTween.RotateTo(AnswerImage[selectNumber].gameObject,
			iTween.Hash(
				"z", angle,
				"time", rotateMoveTime,
				"islocal", true,
				"easetype", iTween.EaseType.linear,
				"oncomplete", "OnCompletionHalfRoundHandler",
				"oncompletetarget",this.gameObject
			)
		);
	}
	private void AnsAnimation(bool isCorrect){
		if(isCorrect){
			Debug.Log("正解");
		}else{
			Debug.Log("不正解");
		}
	}
	private IEnumerator AnimationEnd()
	{
		yield return new WaitForSeconds(0.5f);
		Debug.Log("OK");
		isRotateChecker = false;
	}
}
