using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       05-01-2023 12:38:44
================================================*/ 
public abstract class Bullet : MonoBehaviour {

	[SerializeField]
	protected BulletDataSO bulletData;

	public virtual BulletDataSO BulletData
	{
		get { return bulletData; }
		set { bulletData = value; }
	}

}