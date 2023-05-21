using UnityEngine;

namespace Common
{
	public class CameraFollow : MonoBehaviour {

		public Transform player;

		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
			this.transform.position = new Vector3(player.position.x, 
				player.position.y, 
				this.transform.position.z);
		}
	}
}
