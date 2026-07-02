using UnityEngine;

namespace Assets.MyProject.Script.Manager
{
    public class BotManager : MonoBehaviour
    {
        [SerializeField] private PlayerMove playerMove;
        [SerializeField] private CameraValue cameraValue;

        private BotNavMesh botNavMesh;

        public void StartBotStage(GameObject stageRoot)
        {
            botNavMesh = stageRoot.GetComponentInChildren<BotNavMesh>(true);

            playerMove.enabled = false;
            cameraValue.ShowBotCamera();

            botNavMesh.StartBot();
        }

        public void BotArrived()
        {
            cameraValue.ShowPlayerCamera();

            playerMove.enabled = true;

            botNavMesh.HideBot();
        }
    }
}
