using System;

namespace ChaosWorld_Debug{
    public class DEBUG_MODE{
        public static DEBUG_MODE instance;

        public static bool isDEBUG = false;
        public static DEBUG_MODE Instance{
            get{
                if(instance == null){
                    instance = new DEBUG_MODE();
                }
                return instance;
            }
        }

        private DEBUG_MODE(){
            
        }

        public void Log(string message){
            if(!isDEBUG){
                return;
            }
            UnityEngine.Debug.Log(message);
        }
    }
 }