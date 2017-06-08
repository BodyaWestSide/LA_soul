using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour {

	public static SaveManager instance = null;



	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(this.gameObject);
	}


	public void DeleteProgress()
	{
		File.Delete(Application.persistentDataPath + "/waveInfo.dat");
	}


	public void SaveProgress(int score)
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/waveInfo.dat");

		Score data = new Score();
		data.number = score;

		bf.Serialize(file, data);
		file.Close();
	}

	public int LoadBestScore()
	{
		if (File.Exists(Application.persistentDataPath + "/waveInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/waveInfo.dat", FileMode.Open);
			Score data = (Score)bf.Deserialize(file);
			file.Close();

			return data.number;
		}
		return 1;
	}


	[System.Serializable]
	class Score
	{
		public int number; 
	}
}
