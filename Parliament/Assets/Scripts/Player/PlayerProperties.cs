using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerProperties : MonoBehaviour
    {
        public string PlayerName = "Billy";	
	
        private const int debugWidth = 500;
        private const int debugHeight = 250;
	
        public bool _isDebug = true;
	
        public int MaxHealth = 100;
        public int Health = 100;
	
        private Transform PlayerTransform;
	

        // Use this for initialization
        void Start ()
        {
            PlayerTransform = transform;
        }
	
        // Update is called once per frame
        void Update ()
        {
            PlayerTransform = transform;
        }
	
        public Transform GetPlayerTransform()
        {
            return transform;
        }
	
	
        void OnGUI()
        {		
            /*
		if(_isDebug)
		{
			Rect DebugRect = new Rect((Screen.width - (debugWidth - 5)), (Screen.height - (debugHeight - 5)), debugWidth, debugHeight);
			string str1 = "";
			
			str1 += "Player Position: " + PlayerTransform.position.ToString() + "\n" +
					"          Local: " + PlayerTransform.localPosition.ToString() + "\n\n" +
					"Player Rotation: " + PlayerTransform.rotation.ToString() + "\n" +
					"          Local: " + PlayerTransform.rotation.ToString() + "\n\n" +
					"             Up: " + PlayerTransform.up.ToString();
			
			
			GUI.Box(DebugRect, str1);
			
		}*/
        }
    }
}

