using UnityEngine;
using UnityEngine.UI;

namespace CzernyStudio.OculusHandTracking.UI {
    /// <summary>
    /// This debug script is placed on a Debug Canvas to show in VR
    /// </summary>
    public class VisualDebuggerTool : MonoBehaviour {
        [SerializeField] private Text textA;
        [SerializeField] private Text textB;
        [SerializeField] private Text textC;
        [SerializeField] private Text textD;
        [SerializeField] private Text textE;
        [SerializeField] private Text textF;
        [SerializeField] private Text fpsCounter;

        private float _fps;

        protected void Update() {
            _fps = 1 / Time.unscaledDeltaTime;
            fpsCounter.text = "" + (int)_fps;
        }

        public void AssignTextA(string messageOutput) {
            textA.text += "/n" + messageOutput;
        }
        
        public void AssignTextB(string messageOutput) {
            textB.text = messageOutput;
        }
        
        public void AssignTextC(string messageOutput) {
            textC.text = messageOutput;
        }
        
        public void AssignTextD(string messageOutput) {
            textD.text = messageOutput;
        }
        
        public void AssignTextE(string messageOutput) {
            textE.text = messageOutput;
        }        
        
        public void AssignTextF(string messageOutput) {
            textF.text = messageOutput;
        }

        public void Log(string text) {
            textB.text += "\n" + text;
        }

        public void ClearAll() {
            var texts = GetComponentsInChildren<Text>();
            foreach (var t in texts) {
                t.text = "";
            }
        }
    }
}