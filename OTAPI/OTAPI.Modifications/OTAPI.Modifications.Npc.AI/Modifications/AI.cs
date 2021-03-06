﻿using OTAPI.Patcher.Engine.Extensions;
using OTAPI.Patcher.Engine.Modification;

namespace OTAPI.Patcher.Engine.Modifications.Hooks.Npc
{
	public class AI : ModificationBase
	{
		public override System.Collections.Generic.IEnumerable<string> AssemblyTargets => new[]
		{
			"TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null",
			"Terraria, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null","TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null" // TML
		};
		public override string Description => "Hooking NPC.AI()...";
		public override void Run()
		{
			var vanilla = this.Method(() => (new Terraria.NPC()).AI());

			var cbkBegin = this.Method(() => OTAPI.Callbacks.Terraria.Npc.AIBegin(null));
			var cbkEnd = this.Method(() => OTAPI.Callbacks.Terraria.Npc.AIEnd(null));

			vanilla.Wrap
			(
				beginCallback: cbkBegin,
				endCallback: cbkEnd,
				beginIsCancellable: true,
				noEndHandling: false,
				allowCallbackInstance: true
			);
		}
	}
}
