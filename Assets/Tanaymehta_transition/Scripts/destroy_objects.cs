using UnityEngine;
using System.Collections;

public class destroy_objects : MonoBehaviour {
		
	void OnCollisionEnter (Collision col) 
	{ 
		Destroy(col.gameObject);  
	}
}

