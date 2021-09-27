using Sandbox.UI;

namespace SciFiPack.UI {
	public partial class Hud : Sandbox.HudEntity<RootPanel> {
		public Hud() {
			if (IsClient) {
				RootPanel.SetTemplate("/ui/hud/hud.html");
			}
		}
	}
}
