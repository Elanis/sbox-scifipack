using Sandbox;

namespace SciFiPack.Ships {
	[Library("ent_ship_aurora", Title = "Aurora", Spawnable = true)]
	public partial class Aurora : Prop, IUse {
		public override void Spawn() {
			base.Spawn();

			SetModel("models/ships/aurora/aurora.vmdl");
		}

		public bool IsUsable(Entity user) {
			return true;
		}

		public bool OnUse(Entity user) {
			if (user is Player player) {
				player.Health += 10;

				Delete();
			}

			return false;
		}
	}
}