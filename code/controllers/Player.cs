using Sandbox;

using SciFiPack.Ships;

namespace SciFiPack.Controllers {
	partial class Player : Sandbox.Player {
		public override void Respawn() {
			SetModel("models/citizen/citizen.vmdl");

			//
			// Use WalkController for movement (you can make your own PlayerController for 100% control)
			//
			Controller = new WalkController();

			//
			// Use StandardPlayerAnimator  (you can make your own PlayerAnimator for 100% control)
			//
			Animator = new StandardPlayerAnimator();

			//
			// Use ThirdPersonCamera (you can make your own Camera for 100% control)
			//
			Camera = new ThirdPersonCamera();

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			base.Respawn();
		}

		/// <summary>
		/// Called every tick, clientside and serverside.
		/// </summary>
		public override void Simulate(Client cl) {
			base.Simulate(cl);

			SimulateActiveChild(cl, ActiveChild);

			if (IsServer && Input.Pressed(InputButton.Attack2)) {
				var aurora = new Aurora();
				aurora.Position = EyePos + EyeRot.Forward * 40;
				aurora.Rotation = Rotation.LookAt(Vector3.Random.Normal);
				aurora.SetupPhysicsFromModel(PhysicsMotionType.Dynamic, false);
				aurora.PhysicsGroup.Velocity = EyeRot.Forward * 1000;
			}
		}

		public override void OnKilled() {
			base.OnKilled();

			EnableDrawing = false;
		}
	}
}

