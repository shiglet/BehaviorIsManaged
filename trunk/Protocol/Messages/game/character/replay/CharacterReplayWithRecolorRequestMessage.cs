// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'CharacterReplayWithRecolorRequestMessage.xml' the '27/06/2012 15:54:59'
using System;
using BiM.Core.IO;
using System.Collections.Generic;
using System.Linq;

namespace BiM.Protocol.Messages
{
	public class CharacterReplayWithRecolorRequestMessage : CharacterReplayRequestMessage
	{
		public const uint Id = 6111;
		public override uint MessageId
		{
			get
			{
				return 6111;
			}
		}
		
		public int[] indexedColor;
		
		public CharacterReplayWithRecolorRequestMessage()
		{
		}
		
		public CharacterReplayWithRecolorRequestMessage(int characterId, int[] indexedColor)
			 : base(characterId)
		{
			this.indexedColor = indexedColor;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUShort((ushort)indexedColor.Count());
			foreach (var entry in indexedColor)
			{
				writer.WriteInt(entry);
			}
		}
		
		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			int limit = reader.ReadUShort();
			indexedColor = new int[limit];
			for (int i = 0; i < limit; i++)
			{
				(indexedColor as int[])[i] = reader.ReadInt();
			}
		}
	}
}
