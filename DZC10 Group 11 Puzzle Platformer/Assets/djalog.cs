// Commented this out because of the errors
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EasyUI.Dialogs{
public class Dialog{
    //public string Title;
    public string Message = "your message";
}
    public class DialogUI : MonoBehaviour {
        [SerializeField] GameObject canvas;
        //[SerializeField] Text titleUIText;
        [SerializeField] Text messageUIText;
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
        dialog.Message = message;
        return Instance;
        }

        public void Show(){
            messageUIText.text = dialog.Message;
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
*/