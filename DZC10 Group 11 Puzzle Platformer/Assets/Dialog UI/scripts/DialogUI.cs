using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EasyUI.Dialogs{
public class Dialog{
    //public string Title;
    public string layersTextUI = "your message";
}
    public class DialogUI : MonoBehaviour {
        [SerializeField] GameObject canvas;
        //[SerializeField] Text titleUIText;
        [SerializeField] Text layersText;
        [SerializeField] Text closeUIButton;

        Dialog dialog = new Dialog(); 

        //Singleton pattern
        public static DialogUI Instance;

        void Awake(){
            Instance = this;

            // Add close event lisener
            closeUIButton.onClick.RemoveAllListeners();
            closeUIButton.onClick.AddListener( Hide);


        }
        // set dialog message
        public DialogUI SetMessage(string message){
        dialog.layersTextUI = message;
        return Instance;
        }

        public void Show(){
            layersText.text = dialog.layersTextUI;
            // reset dialog
            dialog = new Dialog();

            canvas.SetActive ( true);
        }

        public void Hide(){
            canvas.SetActive( false);

            //reset dialog
            dialog = new Dialog();
        }


   }
}
