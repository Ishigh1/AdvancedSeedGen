using AdvancedWorldGen.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ID.NPCID;

namespace AdvancedWorldGen.SpecialOptions.Halloween.NPCs
{
	public class HalloweenGlobalNPC : GlobalNPC
	{
		public override bool PreAI(NPC npc)
		{
			return !ModifiedWorld.OptionsContains("Spooky") || EyeOfCthulhu.PreAI(npc) && BrainOfCthulhu.PreAI(npc);
		}

		public override void AI(NPC npc)
		{
			if (!ModifiedWorld.OptionsContains("Spooky")) return;
			EyeOfCthulhu.AI(npc);
		}

		public override void PostAI(NPC npc)
		{
			if (!ModifiedWorld.OptionsContains("Spooky")) return;
			BrainOfCthulhu.PostAI(npc);
		}

		public override void OnKill(NPC npc)
		{
			if (!ModifiedWorld.OptionsContains("Spooky")) return;
			if (Main.netMode == NetmodeID.MultiplayerClient && (npc.friendly ||
			                                                    npc.type != Ghost && npc.type != Wraith &&
			                                                    Main.rand.Next(20) == 0))
			{
				NPC newNPC = Main.npc[NPC.NewNPC(0, 0, Ghost)];
				newNPC.position.X = npc.position.X;
				newNPC.position.Y = npc.position.Y;
				newNPC.netUpdate = true;
			}

			BrainOfCthulhu.OnKill(npc);
		}

		public override void BossHeadSlot(NPC npc, ref int index)
		{
			if (!ModifiedWorld.OptionsContains("Spooky")) return;
			EyeOfCthulhu.BossHeadSlot(npc, ref index);
		}
	}
}